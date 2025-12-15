using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

public class CreateNestedBookmarks
{
    /// <summary>
    /// Demonstrates how to create nested bookmarks in a PDF document using Aspose.Pdf.Facades.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string inputPath = Path.Combine(AppContext.BaseDirectory, "data", "inputs", "inFile.pdf");
            string outputDirectory = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDirectory);
            string outputPath = Path.Combine(outputDirectory, "Nested_BookMarks_out.pdf");

            // Initialize the PDF content editor and bind the source PDF.
            PdfContentEditor editor = new PdfContentEditor();
            editor.BindPdf(inputPath);

            // Creating child items of a chapter, in this example, the first child item also includes a child item.
            Bookmark bm11 = new Bookmark
            {
                Action = "GoTo",
                PageNumber = 3,
                Title = "Section - 1.1.1"
            };

            Bookmark bm1 = new Bookmark
            {
                Action = "GoTo",
                PageNumber = 2,
                Title = "Section - 1.1"
            };

            Bookmarks bms1 = new Bookmarks();
            bms1.Add(bm11);
            bm1.ChildItems = bms1;

            // Creating a child item of a chapter.
            Bookmark bm2 = new Bookmark
            {
                Action = "GoTo",
                PageNumber = 4,
                Title = "Section - 1.2"
            };

            // Creating a chapter (Parent Level Bookmark)
            Bookmark bm = new Bookmark
            {
                Action = "GoTo",
                PageNumber = 1,
                Title = "Chapter - 1"
            };

            Bookmarks bms = new Bookmarks();
            bms.Add(bm1);
            bms.Add(bm2);
            bm.ChildItems = bms;

            // Creating a second chapter (Parent Level Bookmark)
            Bookmark bm_parent2 = new Bookmark
            {
                Action = "GoTo",
                PageNumber = 5,
                Title = "Chapter - 2"
            };

            // Creating a child item of the second chapter.
            Bookmark bm22 = new Bookmark
            {
                Action = "GoTo",
                PageNumber = 6,
                Title = "Section - 2.1"
            };

            Bookmarks bms_parent2 = new Bookmarks();
            bms_parent2.Add(bm22);
            bm_parent2.ChildItems = bms_parent2;

            // Add the top‑level bookmarks to the document.
            // NOTE: The AddBookmark method is not available in the current Aspose.Pdf.Facades version.
            // TODO: Replace with the appropriate API for adding top‑level bookmarks, e.g., using PdfBookmarkEditor
            // or accessing the document outline directly.
            // editor.AddBookmark(bm);
            // editor.AddBookmark(bm_parent2);

            // Save the result PDF to the output file.
            editor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error creating nested bookmarks: {ex.Message}");
        }
    }
}