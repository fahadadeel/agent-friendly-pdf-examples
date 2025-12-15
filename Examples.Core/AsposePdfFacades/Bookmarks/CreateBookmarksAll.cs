using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.BookmarksDemo; // Renamed to avoid conflict with Aspose.Pdf.Bookmarks type

public class CreateBookmarksAll
{
    /// <summary>
    /// Demonstrates creating bookmarks for all pages of a PDF using Aspose.Pdf.Facades.
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
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "CreateBookmarksAll.pdf");
            string outputPath = Path.Combine(outputDir, "Output_out.pdf");

            // Open document and create bookmarks for all pages.
            var bookmarkEditor = new PdfBookmarkEditor();
            bookmarkEditor.BindPdf(inputPath);
            bookmarkEditor.CreateBookmarks();
            bookmarkEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in {nameof(CreateBookmarksAll)}: {ex.Message}");
        }
    }
}