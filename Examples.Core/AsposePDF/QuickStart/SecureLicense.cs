using System;
using System.IO;
using System.IO.Compression; // AUTOFIX

namespace Examples.Core.AsposePDF.QuickStart;

public class SecureLicense
{
    /// <summary>
    /// Demonstrates extracting a license file from a zip archive embedded as a resource.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve the embedded resource stream.
            using Stream zip = new SecureLicense().GetType().Assembly.GetManifestResourceStream("Aspose.Total.lic.zip")
                ?? throw new FileNotFoundException("Embedded resource 'Aspose.Total.lic.zip' not found.");

            // NOTE: System.IO.Compression does not support password‑protected zip files.
            // TODO: If password protection is required, replace this with a library that supports it (e.g., DotNetZip).
            using var archive = new ZipArchive(zip, ZipArchiveMode.Read);
            var entry = archive.GetEntry("Aspose.Total.lic")
                ?? throw new FileNotFoundException("Entry 'Aspose.Total.lic' not found in zip.");

            using var entryStream = entry.Open();
            using var ms = new MemoryStream();
            entryStream.CopyTo(ms);
            ms.Position = 0;

            // Optionally write the extracted license to the output folder.
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "Aspose.Total.lic");
            using (var fileStream = File.OpenWrite(outputPath))
            {
                ms.CopyTo(fileStream);
            }

            Console.WriteLine($"License extracted to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error extracting license: {ex.Message}");
        }
    }
}