using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Pages;

/// <summary>
/// Demonstrates how to get page dimensions and rotate a page using Aspose.Pdf.
/// </summary>
public class GetDimensions
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Path to the source PDF.
            string inputPath = Path.Combine(inputDir, "UpdateDimensions.pdf");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open document
            Document pdfDocument = new Document(inputPath);

            // Adds a blank page to pdf document (or gets first page if exists)
            Page page = pdfDocument.Pages.Count > 0 ? pdfDocument.Pages[1] : pdfDocument.Pages.Add();

            // Get page height and width information
            Console.WriteLine($"{page.GetPageRect(true).Width}:{page.GetPageRect(true).Height}");

            // Rotate page at 90 degree angle
            page.Rotate = Rotation.on90;

            // Get page height and width information after rotation
            Console.WriteLine($"{page.GetPageRect(true).Width}:{page.GetPageRect(true).Height}");

            // Save the modified document to the output folder.
            string outputPath = Path.Combine(outputDir, "UpdateDimensions_Modified.pdf");
            pdfDocument.Save(outputPath);
            Console.WriteLine($"Modified PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetDimensions.Run: {ex.Message}");
        }
    }
}