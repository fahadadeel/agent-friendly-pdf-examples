using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Pages;

/// <summary>
/// Demonstrates how to calculate new page dimensions to fit contents for landscape orientation.
/// </summary>
public class FitPageContents
{
    /// <summary>
    /// Runs the example.
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

            // Path to the input PDF file.
            string inputPath = Path.Combine(inputDir, "input.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Iterate through each page and compute new dimensions.
            foreach (Page page in doc.Pages)
            {
                Rectangle r = page.MediaBox;
                // New height remains the same.
                double newHeight = r.Height;
                // New width is expanded proportionally to make orientation landscape
                // (assuming the previous orientation is portrait).
                double newWidth = r.Height * r.Height / r.Width;

                // TODO: Apply the new dimensions to the page if required.
                // For example:
                // page.MediaBox = new Rectangle(page.MediaBox.LLX, page.MediaBox.LLY, newWidth, newHeight);
            }

            // TODO: Save the modified document if needed.
            // string outputPath = Path.Combine(outputDir, "output.pdf");
            // doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}