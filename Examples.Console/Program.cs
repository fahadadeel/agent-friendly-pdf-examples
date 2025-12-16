using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Examples.Core;
using Microsoft.Extensions.Configuration;
using ConsoleOut = System.Console;

namespace Examples.Console;

/// <summary>
/// Minimal, reflection-based runner for Aspose.Pdf examples.
/// Usage: dotnet run --project Examples.Console -- AsposePDF/QuickStart/LoadLicenseFromFile
/// </summary>
internal static class Program
{
    private static void Main(string[] args)
    {
        var configuration = BuildConfiguration();

        ConsoleOut.WriteLine("🔎 Aspose.Pdf Examples Runner");
        ConsoleOut.WriteLine("=====================================");

        InitializeLicense(configuration);

        if (args.Length == 0)
        {
            ShowUsage();
            return;
        }

        var category = args[0].Trim();
        RunExample(category);
    }

    private static IConfigurationRoot BuildConfiguration() => new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
        .AddEnvironmentVariables()
        .Build();

    private static void InitializeLicense(IConfiguration configuration)
    {
        var licensePath = configuration["Aspose:LicensePath"] ?? configuration["ASPOSE_LICENSE_PATH"];
        LicenseHelper.SetLicenseFromConfig(licensePath);

        if (!LicenseHelper.IsLicenseSet)
        {
            LicenseHelper.ShowLicenseInfo();
        }
    }

    private static void ShowUsage()
    {
        ConsoleOut.WriteLine("Usage: dotnet run --project Examples.Console -- <CategoryPath>");
        ConsoleOut.WriteLine("Example: dotnet run --project Examples.Console -- AsposePDF/QuickStart/LoadLicenseFromFile");
    }

    private static void RunExample(string category)
    {
        try
        {
            var normalized = NormalizeCategory(category);
            var typeName = $"Examples.Core.{string.Join('.', normalized)}";
            var assembly = typeof(LicenseHelper).Assembly;
            var type = assembly.GetType(typeName, throwOnError: false, ignoreCase: false);

            if (type == null)
            {
                ConsoleOut.WriteLine($"❌ Example type not found: {typeName}");
                return;
            }

            var runMethod = type.GetMethod("Run", BindingFlags.Public | BindingFlags.Static);
            if (runMethod == null)
            {
                ConsoleOut.WriteLine($"❌ Static Run() method not found on {typeName}");
                return;
            }

            runMethod.Invoke(null, null);
            ConsoleOut.WriteLine("✅ Example finished");
        }
        catch (Exception ex)
        {
            ConsoleOut.WriteLine($"❌ Error running example: {ex.Message}");
        }
    }

    private static string[] NormalizeCategory(string raw)
    {
        var cleaned = raw.Trim();

        if (cleaned.EndsWith(".run", StringComparison.OrdinalIgnoreCase))
        {
            cleaned = cleaned[..^4];
        }

        cleaned = cleaned.Replace('\\', '/');
        var segments = cleaned.Split('/', StringSplitOptions.RemoveEmptyEntries);

        return segments
            .Select(s => string.Concat(s
                .Split(new[] { '-', '_', '.', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(ToPascal)))
            .ToArray();
    }

    private static string ToPascal(string value)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;
        return char.ToUpperInvariant(value[0]) + (value.Length > 1 ? value.Substring(1) : string.Empty);
    }
}
