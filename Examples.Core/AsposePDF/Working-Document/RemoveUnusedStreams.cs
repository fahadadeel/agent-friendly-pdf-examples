using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Optimization;

namespace Examples.Core.AsposePDF.Working_Document;

/// <summary>
/// Demonstrates removing unused streams from a PDF document using Aspose.Pdf.
/// </summary>
public class RemoveUnusedStreams
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

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "OptimizeDocument.pdf");
            string outputPath = Path.Combine(outputDir, "OptimizeDocument_out.pdf");

            // Open the PDF document.
            var pdfDocument = new Document(inputPath);

            // Set RemoveUnusedStreams option.
            var optimizeOptions = new OptimizationOptions
            {
                RemoveUnusedStreams = true
            };

            // Optimize PDF document using OptimizationOptions.
            pdfDocument.OptimizeResources(optimizeOptions);

            // Save the updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nUnused streams removed successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during RemoveUnusedStreams execution: {ex.Message}");
        }
    }
}