using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Bookmarks;

public class ExpandBookmarks
{
    /// <summary>
    /// Expands all bookmarks (outlines) in a PDF document and saves the result.
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

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "input-bookmark.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open document.
            Document doc = new Document(inputPath);

            // Set page view mode to show outlines (bookmarks).
            doc.PageMode = PageMode.UseOutlines;

            // Expand each outline item.
            foreach (OutlineItemCollection item in doc.Outlines)
            {
                item.Open = true;
            }

            // Output PDF file.
            string outputPath = Path.Combine(outputDir, "ExpandBookmarks_out.pdf");
            doc.Save(outputPath);

            Console.WriteLine($"\nBookmarks expanded successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error expanding bookmarks: {ex.Message}");
        }
    }
}