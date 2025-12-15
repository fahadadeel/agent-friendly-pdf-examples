using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Bookmarks;

/// <summary>
/// Demonstrates how to delete a particular bookmark (outline) from a PDF document.
/// </summary>
public class DeleteParticularBookmark
{
    /// <summary>
    /// Deletes the bookmark titled "Child Outline" from the input PDF and saves the result.
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
                Directory.CreateDirectory(outputDir);

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "DeleteParticularBookmark.pdf");

            // Open the document.
            Document pdfDocument = new Document(inputPath);

            // Delete particular outline by title.
            pdfDocument.Outlines.Delete("Child Outline");

            // Output PDF file path.
            string outputPath = Path.Combine(outputDir, "DeleteParticularBookmark_out.pdf");

            // Save the updated file.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nParticular bookmark deleted successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error deleting bookmark: {ex.Message}");
        }
    }
}