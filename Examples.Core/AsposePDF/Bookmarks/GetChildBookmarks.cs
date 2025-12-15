using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Bookmarks;

/// <summary>
/// Demonstrates how to iterate through PDF bookmarks and their child bookmarks using Aspose.Pdf.
/// </summary>
public class GetChildBookmarks
{
    /// <summary>
    /// Entry point for the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Path to the source PDF file.
            string pdfPath = Path.Combine(inputDir, "GetChildBookmarks.pdf");

            if (!File.Exists(pdfPath))
            {
                Console.Error.WriteLine($"Input file not found: {pdfPath}");
                return;
            }

            // Open the PDF document.
            Document pdfDocument = new Document(pdfPath);

            // Loop through all the top‑level bookmarks.
            foreach (OutlineItemCollection outlineItem in pdfDocument.Outlines)
            {
                Console.WriteLine(outlineItem.Title);
                Console.WriteLine(outlineItem.Italic);
                Console.WriteLine(outlineItem.Bold);
                Console.WriteLine(outlineItem.Color);

                if (outlineItem.Count > 0)
                {
                    Console.WriteLine("Child Bookmarks");
                    // Loop through child bookmarks.
                    foreach (OutlineItemCollection childOutline in outlineItem)
                    {
                        Console.WriteLine(childOutline.Title);
                        Console.WriteLine(childOutline.Italic);
                        Console.WriteLine(childOutline.Bold);
                        Console.WriteLine(childOutline.Color);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while processing bookmarks: {ex.Message}");
        }
    }
}