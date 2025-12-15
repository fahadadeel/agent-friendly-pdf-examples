using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates how to delete an image from a PDF document using Aspose.Pdf.
/// </summary>
public class DeleteImages
{
    /// <summary>
    /// Deletes the first image on the first page of the input PDF and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Base directory of the application
            string baseDir = AppContext.BaseDirectory;

            // Resolve input and output directories
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input PDF file path
            string inputPath = Path.Combine(inputDir, "DeleteImages.pdf");

            // Load the PDF document
            Document pdfDocument = new Document(inputPath);

            // Delete the first image on the first page (index is 1‑based)
            pdfDocument.Pages[1].Resources.Images.Delete(1);

            // Output PDF file path
            string outputPath = Path.Combine(outputDir, "DeleteImages_out.pdf");

            // Save the updated PDF file
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nImages deleted successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error deleting images: {ex.Message}");
        }
    }
}