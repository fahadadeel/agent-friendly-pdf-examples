using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.Bookmarks;

/// <summary>
/// Demonstrates how to read bookmark information, including page numbers, from a PDF document.
/// </summary>
public class GetBookmarkPageNumber
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

            // Path to the source PDF file.
            string inputPath = Path.Combine(inputDir, "GetBookmarks.pdf");

            // Create PdfBookmarkEditor and bind the PDF.
            PdfBookmarkEditor bookmarkEditor = new PdfBookmarkEditor();
            bookmarkEditor.BindPdf(inputPath);

            // Extract bookmarks.
            Aspose.Pdf.Facades.Bookmarks bookmarks = bookmarkEditor.ExtractBookmarks();

            // Iterate through each bookmark and display its details.
            foreach (Bookmark bookmark in bookmarks)
            {
                string levelSeparator = string.Empty;
                for (int i = 1; i < bookmark.Level; i++)
                {
                    levelSeparator += "----";
                }

                Console.WriteLine("{0}Title: {1}", levelSeparator, bookmark.Title);
                Console.WriteLine("{0}Page Number: {1}", levelSeparator, bookmark.PageNumber);
                Console.WriteLine("{0}Page Action: {1}", levelSeparator, bookmark.Action);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while processing bookmarks: {ex.Message}");
        }
    }
}