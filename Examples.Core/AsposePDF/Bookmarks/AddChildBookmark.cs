using System;
using System.IO;
using Aspose.Pdf.Annotations;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Bookmarks;

/// <summary>
/// Demonstrates adding a child bookmark to a PDF document using Aspose.Pdf.
/// </summary>
public class AddChildBookmark
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "AddChildBookmark.pdf");
            // Output PDF file path.
            string outputPath = Path.Combine(outputDir, "AddChildBookmark_out.pdf");

            // Open document
            Document pdfDocument = new Document(inputPath);

            // Create a parent bookmark object
            OutlineItemCollection pdfOutline = new OutlineItemCollection(pdfDocument.Outlines)
            {
                Title = "Parent Outline",
                Italic = true,
                Bold = true
            };

            // Create a child bookmark object
            OutlineItemCollection pdfChildOutline = new OutlineItemCollection(pdfDocument.Outlines)
            {
                Title = "Child Outline",
                Italic = true,
                Bold = true
            };

            // Add child bookmark to parent bookmark's collection
            pdfOutline.Add(pdfChildOutline);
            // Add parent bookmark to the document's outline collection.
            pdfDocument.Outlines.Add(pdfOutline);

            // Save output
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nChild bookmark added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddChildBookmark.Run: {ex.Message}");
        }
    }
}