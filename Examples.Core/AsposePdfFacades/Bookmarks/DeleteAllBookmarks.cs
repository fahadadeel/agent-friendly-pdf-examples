using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.BookmarkDemo
{
    /// <summary>
    /// Demonstrates how to delete all bookmarks from a PDF document using Aspose.Pdf.Facades.
    /// </summary>
    public class DeleteAllBookmarks
    {
        /// <summary>
        /// Executes the bookmark deletion example.
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

                // Define full paths for the input and output PDF files.
                string inputPath = Path.Combine(inputDir, "DeleteAllBookmarks.pdf");
                string outputPath = Path.Combine(outputDir, "DeleteAllBookmarks_out.pdf");

                // Open the PDF document.
                PdfBookmarkEditor bookmarkEditor = new PdfBookmarkEditor();
                bookmarkEditor.BindPdf(inputPath);

                // Delete all bookmarks.
                bookmarkEditor.DeleteBookmarks();

                // Save the updated PDF file.
                bookmarkEditor.Save(outputPath);

                Console.WriteLine($"Bookmarks deleted successfully. Output saved to: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred while deleting bookmarks: {ex.Message}");
            }
        }
    }
}