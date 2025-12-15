using System;
using System.IO;

namespace Examples.Core.AsposePDF.QuickStart;

/// <summary>
/// Demonstrates loading an Aspose.Pdf license from a file stream.
/// </summary>
public class LoadLicenseFromStreamObject
{
    /// <summary>
    /// Loads the license from a stream located in the data/inputs directory.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve the inputs directory relative to the application base directory.
            string inputsDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            if (!Directory.Exists(inputsDir))
            {
                Console.Error.WriteLine($"Inputs directory not found: {inputsDir}");
                return;
            }

            // Path to the license file.
            string licensePath = Path.Combine(inputsDir, "Aspose.Pdf.net.lic");
            if (!File.Exists(licensePath))
            {
                Console.Error.WriteLine($"License file not found: {licensePath}");
                return;
            }

            // Initialize license object.
            Aspose.Pdf.License license = new Aspose.Pdf.License();

            // Load license in FileStream.
            using FileStream myStream = new FileStream(licensePath, FileMode.Open, FileAccess.Read);
            // Set license.
            license.SetLicense(myStream);

            Console.WriteLine("License set successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error setting license: {ex.Message}");
        }
    }
}