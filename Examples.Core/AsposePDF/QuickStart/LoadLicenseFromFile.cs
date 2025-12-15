using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Demonstrates loading an Aspose.Pdf license from a file.
/// </summary>
namespace Examples.Core.AsposePDF.QuickStart;

public class LoadLicenseFromFile
{
    /// <summary>
    /// Runs the license loading example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve the data directory (inputs) relative to the application base.
            // TODO: Replace with actual helper if RunExamples is available.
            // string dataDir = RunExamples.GetDataDir_AsposePdf_QuickStart();
            string dataDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");

            // Ensure the directory exists.
            if (!Directory.Exists(dataDir))
            {
                Console.WriteLine($"Input directory not found: {dataDir}");
                return;
            }

            // Initialize license object
            var license = new License();

            // Build the license file path.
            string licensePath = Path.Combine(dataDir, "Aspose.Pdf.net.lic");

            // Set license
            license.SetLicense(licensePath);
            Console.WriteLine("License set successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error setting license: {ex.Message}");
        }
    }
}