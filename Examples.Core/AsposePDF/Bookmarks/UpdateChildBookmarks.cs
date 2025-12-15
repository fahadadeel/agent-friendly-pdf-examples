using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Bookmarks;

/// <summary>
/// Demonstrates how to update child bookmarks in a PDF document using Aspose.Pdf.
/// </summary>
public class UpdateChildBookmarks
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Define input and output file paths.
        string inputPath = Path.Combine(inputDir, "UpdateChildBookmarks.pdf");
        string outputPath = Path.Combine(outputDir, "UpdateChildBookmarks_out.pdf");

        try
        {
            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Get the first-level bookmark (outline) at index 1.
            OutlineItemCollection pdfOutline = pdfDocument.Outlines[1];

            // Get the child bookmark at index 1.
            OutlineItemCollection childOutline = pdfOutline[1];
            childOutline.Title = "Updated Outline";
            childOutline.Italic = true;
            childOutline.Bold = true;

            // Save the updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nChild bookmarks updated successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while updating child bookmarks: {ex.Message}");
        }
    }
}