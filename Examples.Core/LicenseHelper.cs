using Aspose.Pdf;
using System;
using System.IO;
using System.Linq;

namespace Examples.Core;

/// <summary>
/// Centralized license management for Aspose.Pdf examples.
/// Mirrors the flexible lookup used in the barcode samples.
/// </summary>
public static class LicenseHelper
{
    private static bool _licenseSet;
    private static readonly object _lockObject = new();

    private static readonly string[] LicenseFilePatterns =
    {
        "Aspose.Pdf.NET.lic",
        "Aspose.Pdf.lic",
        "AsposePdfNet.lic",
        "aspose-pdf.lic",
        "license.lic",
        "*.lic"
    };

    /// <summary>
    /// Attempts to set the Aspose.Pdf license from various locations.
    /// </summary>
    /// <param name="customLicensePath">Optional custom license file path to try first.</param>
    public static void SetLicense(string? customLicensePath = null)
    {
        if (_licenseSet) return;

        lock (_lockObject)
        {
            if (_licenseSet) return;

            try
            {
                var license = new License();

                if (!string.IsNullOrEmpty(customLicensePath) && TrySetLicenseFromFile(license, customLicensePath))
                {
                    return;
                }

                var envLicensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
                if (!string.IsNullOrEmpty(envLicensePath) && TrySetLicenseFromFile(license, envLicensePath))
                {
                    return;
                }

                var searchDirectories = new[]
                {
                    ".",
                    "licenses",
                    "..",
                    "../..",
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
                };

                foreach (var directory in searchDirectories)
                {
                    if (TrySetLicenseFromDirectory(license, directory))
                    {
                        return;
                    }
                }

                if (TrySetLicenseFromEmbeddedResource(license))
                {
                    return;
                }

                ShowNoLicenseMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error setting Aspose.Pdf license: {ex.Message}");
                Console.WriteLine("📝 Running in evaluation mode with limitations");
            }
        }
    }

    private static bool TrySetLicenseFromFile(License license, string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                license.SetLicense(filePath);
                _licenseSet = true;
                Console.WriteLine($"✅ Aspose.Pdf license loaded successfully from: {Path.GetFileName(filePath)}");
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️  Failed to load license from {filePath}: {ex.Message}");
        }
        return false;
    }

    private static bool TrySetLicenseFromDirectory(License license, string directory)
    {
        try
        {
            if (!Directory.Exists(directory)) return false;

            foreach (var pattern in LicenseFilePatterns)
            {
                if (pattern == "*.lic")
                {
                    var licFiles = Directory.GetFiles(directory, "*.lic");
                    foreach (var licFile in licFiles)
                    {
                        if (TrySetLicenseFromFile(license, licFile))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    var filePath = Path.Combine(directory, pattern);
                    if (TrySetLicenseFromFile(license, filePath))
                    {
                        return true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️  Error searching directory {directory}: {ex.Message}");
        }
        return false;
    }

    private static bool TrySetLicenseFromEmbeddedResource(License license)
    {
        try
        {
            foreach (var pattern in LicenseFilePatterns.Take(3))
            {
                license.SetLicense($"Examples.Core.{pattern}");
                _licenseSet = true;
                Console.WriteLine($"✅ Aspose.Pdf license loaded from embedded resource: {pattern}");
                return true;
            }
        }
        catch
        {
            // Embedded resource not found; ignore
        }
        return false;
    }

    private static void ShowNoLicenseMessage()
    {
        Console.WriteLine("⚠️  No Aspose.Pdf license found in any of the expected locations:");
        Console.WriteLine("   • Root folder: Aspose.Pdf.NET.lic (or other .lic files)");
        Console.WriteLine("   • Licenses folder: licenses/Aspose.Pdf.NET.lic");
        Console.WriteLine("   • Environment variable: ASPOSE_LICENSE_PATH");
        Console.WriteLine("   • Embedded resource");
        Console.WriteLine("📝 Running in evaluation mode with limitations");
    }

    /// <summary>
    /// Gets the current license status.
    /// </summary>
    public static bool IsLicenseSet => _licenseSet;

    /// <summary>
    /// Sets license from configuration value (e.g., appsettings.json).
    /// </summary>
    public static void SetLicenseFromConfig(string? licensePath)
    {
        if (!string.IsNullOrEmpty(licensePath))
        {
            SetLicense(licensePath);
        }
        else
        {
            SetLicense();
        }
    }

    /// <summary>
    /// Displays the lookup rules so users know where to place license files.
    /// </summary>
    public static void ShowLicenseInfo()
    {
        Console.WriteLine();
        Console.WriteLine("📄 Supported License File Names:");
        foreach (var pattern in LicenseFilePatterns.Take(LicenseFilePatterns.Length - 1))
        {
            Console.WriteLine($"   • {pattern}");
        }
        Console.WriteLine("   • Any .lic file");
        Console.WriteLine();
        Console.WriteLine("📁 Searched Locations (in order):");
        Console.WriteLine("   1. Custom path (if provided)");
        Console.WriteLine("   2. Environment variable: ASPOSE_LICENSE_PATH");
        Console.WriteLine("   3. Current directory");
        Console.WriteLine("   4. Licenses subfolder: licenses/");
        Console.WriteLine("   5. Parent folders: ../, ../../");
        Console.WriteLine("   6. User home directory");
        Console.WriteLine("   7. Embedded resource in Examples.Core");
        Console.WriteLine();
        Console.WriteLine("💡 Tips:");
        Console.WriteLine("   • Place license file in root folder for simplest setup");
        Console.WriteLine("   • Use licenses/ folder for organized structure");
        Console.WriteLine("   • Set ASPOSE_LICENSE_PATH environment variable for production");
        Console.WriteLine("   • *.lic files are typically excluded from version control");
        Console.WriteLine();
    }
}
