using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Operators;
// AUTOFIX: Removed unused System.Drawing namespace to avoid type conflicts.
using AsposeRectangle = Aspose.Pdf.Rectangle;

/// <summary>
/// Demonstrates changing page orientation, media box, crop box, and rotation using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Pages;

public class ChangeOrientation
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

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "ChangeOrientation_out.pdf");

            // Load the PDF document.
            Document doc = new Document(inputPath);

            foreach (Page page in doc.Pages)
            {
                // Swap width and height.
                AsposeRectangle r = page.MediaBox;
                double newHeight = r.Width;
                double newWidth = r.Height;
                double newLLX = r.LLX;
                // Move page upper to compensate for changed size.
                double newLLY = r.LLY + (r.Height - newHeight);

                page.MediaBox = new AsposeRectangle(newLLX, newLLY, newLLX + newWidth, newLLY + newHeight);
                // Preserve CropBox if it was set.
                page.CropBox = new AsposeRectangle(newLLX, newLLY, newLLX + newWidth, newLLY + newHeight);

                // Set rotation angle of page.
                page.Rotate = Rotation.on90;
            }

            // Save the modified document.
            doc.Save(outputPath);

            Console.WriteLine("\nPage orientation changed successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ChangeOrientation.Run: {ex.Message}");
        }
    }

    private static bool HasOnlyWhiteColor(Page page)
    {
        // TODO: Implement proper color checking if needed.
        // Placeholder implementation returns true.
        return true;
    }

    private static bool IsBlankPage(Page page)
    {
        if (page.Contents.Count == 0 && page.Annotations.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}