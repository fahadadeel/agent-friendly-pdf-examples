using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Pages;

/// <summary>
/// Demonstrates how to update the dimensions of a PDF page using Aspose.Pdf.
/// </summary>
public class UpdateDimensions
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "UpdateDimensions.pdf");
            string outputPath = Path.Combine(outputDir, "UpdateDimensions_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Get the first page.
            Page pdfPage = pdfDocument.Pages[1];

            // Set the page size to A4 (11.7 x 8.3 inches). In Aspose.Pdf, 1 inch = 72 points,
            // so A4 dimensions in points are (842.4, 597.6). Width first, then height.
            pdfPage.SetPageSize(597.6, 842.4);

            // Save the updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nPage dimensions updated successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while updating page dimensions: {ex.Message}");
        }
    }
}