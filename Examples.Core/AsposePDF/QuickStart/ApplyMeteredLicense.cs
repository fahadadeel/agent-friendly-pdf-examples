using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Demonstrates applying a metered license to Aspose.Pdf and loading a PDF document.
/// </summary>
namespace Examples.Core.AsposePDF.QuickStart;

public class ApplyMeteredLicense
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input directory relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            // Ensure the directory exists.
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDir}");
                return;
            }

            string inputPath = Path.Combine(inputDir, "input.pdf");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Set metered public and private keys.
            Metered metered = new Metered();
            // TODO: Replace placeholder keys with actual metered license keys.
            metered.SetMeteredKey("*****", "*****");

            // Load the document from disk.
            Document doc = new Document(inputPath);
            // Get the page count of the document.
            Console.WriteLine(doc.Pages.Count);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}