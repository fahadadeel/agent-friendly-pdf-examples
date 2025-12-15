using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Bookmarks;

/// <summary>
/// Demonstrates how to add a bookmark (outline) to a PDF document using Aspose.Pdf.
/// </summary>
public class AddBookmark
{
    /// <summary>
    /// Executes the bookmark addition example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        try
        {
            Directory.CreateDirectory(outputDir);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to create output directory: {ex.Message}");
            return;
        }

        string inputPath = Path.Combine(inputDir, "AddBookmark.pdf");
        string outputPath = Path.Combine(outputDir, "AddBookmark_out.pdf");

        try
        {
            // Open the source PDF document.
            Document pdfDocument = new Document(inputPath);

            // Create a new bookmark (outline) item.
            OutlineItemCollection pdfOutline = new OutlineItemCollection(pdfDocument.Outlines)
            {
                Title = "Test Outline",
                Italic = true,
                Bold = true,
                Action = new GoToAction(pdfDocument.Pages[1])
            };

            // Add the bookmark to the document's outline collection.
            pdfDocument.Outlines.Add(pdfOutline);

            // Save the modified document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nBookmark added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while processing the PDF: {ex.Message}");
        }
    }
}