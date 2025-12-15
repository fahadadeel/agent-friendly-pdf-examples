using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Bookmarks;

public class InheritZoom
{
    /// <summary>
    /// Demonstrates how to add a bookmark with an explicit zoom level to a PDF document.
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
            Directory.CreateDirectory(outputDir);

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open the document.
            Document doc = new Document(inputPath);

            // Create a new bookmark (outline item).
            OutlineItemCollection item = new OutlineItemCollection(doc.Outlines);

            // Set zoom level (0) with XYZ explicit destination.
            XYZExplicitDestination dest = new XYZExplicitDestination(2, 100, 100, 0);

            // Assign the GoTo action with the destination to the bookmark.
            item.Action = new GoToAction(dest);

            // Add the bookmark to the document's outlines collection.
            doc.Outlines.Add(item);

            // Output PDF file path.
            string outputPath = Path.Combine(outputDir, "InheritZoom_out.pdf");

            // Save the modified document.
            doc.Save(outputPath);

            Console.WriteLine($"\nBookmarks updated successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while processing the PDF: {ex.Message}");
        }
    }
}