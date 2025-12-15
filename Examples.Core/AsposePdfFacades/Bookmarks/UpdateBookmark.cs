using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.BookmarkSamples; // AUTOFIX – renamed to avoid conflict with Aspose.Pdf.Facades.Bookmarks type

/// <summary>
/// Demonstrates how to update bookmarks in a PDF document using Aspose.Pdf.Facades.
/// </summary>
public class UpdateBookmark
{
    /// <summary>
    /// Executes the bookmark update example.
    /// </summary>
    public static void Run()
    {
        // ExStart:UpdateBookmark
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "UpdateBookmark.pdf");
            string outputPath = Path.Combine(baseDir, "data", "outputs", "UpdateBookmark_out.pdf");

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);

            // Open document and edit bookmarks.
            var bookmarkEditor = new PdfBookmarkEditor();
            bookmarkEditor.BindPdf(inputPath);
            bookmarkEditor.ModifyBookmarks("New Bookmark", "New Title");
            bookmarkEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error updating bookmarks: {ex.Message}");
        }
        // ExEnd:UpdateBookmark
    }
}