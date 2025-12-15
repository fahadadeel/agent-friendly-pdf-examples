using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Images;

/// <summary>
/// Demonstrates deleting images from a specific page of a PDF using Aspose.Pdf.Facades.
/// </summary>
public class DeleteImagesPage
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

            // Ensure output directory exists.
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "DeleteImages-Page.pdf");
            string outputPath = Path.Combine(outputDir, "DeleteImages-Page_out.pdf");

            // Verify input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open PDF file with PdfContentEditor.
            PdfContentEditor contentEditor = new PdfContentEditor();
            contentEditor.BindPdf(inputPath);

            // Array of image indices to be deleted (1‑based index as per Aspose documentation).
            int[] imageIndex = new int[] { 1 };

            // Delete the images from page number 2.
            contentEditor.DeleteImage(2, imageIndex);

            // Save the modified PDF.
            contentEditor.Save(outputPath);

            Console.WriteLine($"Images deleted successfully. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}