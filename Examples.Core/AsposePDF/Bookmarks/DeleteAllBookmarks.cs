using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Bookmarks;

/// <summary>
/// Demonstrates how to delete all bookmarks from a PDF document using Aspose.Pdf.
/// </summary>
public class DeleteAllBookmarks
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

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "DeleteAllBookmarks.pdf");
            string outputPath = Path.Combine(outputDir, "DeleteAllBookmarks_out.pdf");

            // Verify the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Delete all bookmarks (outlines).
            pdfDocument.Outlines.Delete();

            // Save the updated PDF.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nAll bookmarks deleted successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while deleting bookmarks: {ex.Message}");
        }
    }
}