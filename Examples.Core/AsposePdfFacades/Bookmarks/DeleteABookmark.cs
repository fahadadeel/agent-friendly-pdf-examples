using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.BookmarkSamples; // AUTOFIX

public class DeleteABookmark
{
    /// <summary>
    /// Demonstrates how to delete a bookmark from a PDF document using Aspose.Pdf.Facades.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "DeleteABookmark.pdf");
            string outputPath = Path.Combine(outputDir, "DeleteABookmark_out.pdf");

            // Open document
            var bookmarkEditor = new PdfBookmarkEditor();
            bookmarkEditor.BindPdf(inputPath);

            // Delete bookmark named "Page2"
            bookmarkEditor.DeleteBookmarks("Page2");

            // Save updated PDF file
            bookmarkEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in DeleteABookmark.Run: {ex.Message}");
        }
    }
}