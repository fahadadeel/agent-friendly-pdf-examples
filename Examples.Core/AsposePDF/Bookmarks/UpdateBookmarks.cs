using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Bookmarks;

/// <summary>
/// Demonstrates how to update a bookmark (outline) in a PDF document using Aspose.Pdf.
/// </summary>
public class UpdateBookmarks
{
    /// <summary>
    /// Executes the bookmark update example.
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
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "UpdateBookmarks.pdf");
            string outputPath = Path.Combine(outputDir, "UpdateBookmarks_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Get the first bookmark (outline) item (index 1 as in the original example).
            // Note: Aspose.Pdf uses 1‑based indexing for outlines.
            OutlineItemCollection pdfOutline = pdfDocument.Outlines[1];
            pdfOutline.Title = "Updated Outline";
            pdfOutline.Italic = true;
            pdfOutline.Bold = true;

            // Save the updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nBookmarks updated successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while updating bookmarks: {ex.Message}");
        }
    }
}