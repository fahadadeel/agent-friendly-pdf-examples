using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Images;

/// <summary>
/// Demonstrates how to delete all images from a PDF using Aspose.Pdf.Facades.
/// </summary>
public class DeleteAllImages
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

            // Ensure directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "DeleteAllImages.pdf");
            string outputPath = Path.Combine(outputDir, "DeleteAllImages_out.pdf");

            // Open PDF file.
            var contentEditor = new PdfContentEditor();
            contentEditor.BindPdf(inputPath);

            // Delete all images from the PDF.
            contentEditor.DeleteImage();

            // Save the modified PDF.
            contentEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in DeleteAllImages.Run: {ex.Message}");
        }
    }
}