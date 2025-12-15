using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.BookmarkSamples
{
    /// <summary>
    /// Demonstrates adding a bookmark to a PDF using Aspose.Pdf.Facades.
    /// </summary>
    public class AddBookmark
    {
        /// <summary>
        /// Runs the AddBookmark example.
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

                string inputPath = Path.Combine(inputDir, "AddBookmark.pdf");
                string outputPath = Path.Combine(outputDir, "AddBookmark_out.pdf");

                // Create bookmark
                Bookmark bookmark = new Bookmark
                {
                    PageNumber = 1,
                    Title = "New Bookmark"
                };

                // Create PdfBookmarkEditor and bind the PDF document.
                PdfBookmarkEditor bookmarkEditor = new PdfBookmarkEditor();
                bookmarkEditor.BindPdf(inputPath);

                // Add the bookmark.
                bookmarkEditor.CreateBookmarks(bookmark);

                // Save the updated document.
                bookmarkEditor.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in AddBookmark.Run: {ex.Message}");
            }
        }
    }
}