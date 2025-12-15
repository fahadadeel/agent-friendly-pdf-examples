using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.StampsWatermarks;

/// <summary>
/// Demonstrates how to read watermark artifacts from a PDF document.
/// </summary>
public class GetWatermark
{
    /// <summary>
    /// Executes the watermark extraction example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve the input PDF path (expects data/inputs/watermark.pdf relative to the application base directory).
            string inputPath = Path.Combine(AppContext.BaseDirectory, "data", "inputs", "watermark.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (used by other examples that may write files).
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Iterate through artifacts on the first page and display their details.
            foreach (Artifact artifact in pdfDocument.Pages[1].Artifacts)
            {
                Console.WriteLine($"{artifact.Subtype} {artifact.Text} {artifact.Rectangle}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetWatermark.Run: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed elsewhere.