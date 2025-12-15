using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.QuickStart;

/// <summary>
/// Demonstrates setting an Aspose.Pdf license using an embedded resource.
/// </summary>
public class SetLicenseUsingEmbeddedResource
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve the data directory (inputs). Adjust as needed for your environment.
            string dataDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Initialize license object
            var license = new License();

            // Set license
            // license.SetLicense("MergedAPI.Aspose.Total.lic");
            // TODO: Provide the correct license file path or embed the license as a resource.

            Console.WriteLine("License set successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error setting license: {ex.Message}");
        }
    }
}