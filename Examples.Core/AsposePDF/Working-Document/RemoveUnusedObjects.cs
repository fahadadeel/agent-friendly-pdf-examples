using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Optimization;

/// <summary>
/// Demonstrates removing unused objects from a PDF document using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Working_Document;

public class RemoveUnusedObjects
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "OptimizeDocument.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "OptimizeDocument_out.pdf");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open document
            var pdfDocument = new Document(inputPath);

            // Set RemoveUnusedObjects option
            var optimizeOptions = new OptimizationOptions
            {
                RemoveUnusedObjects = true
            };

            // Optimize PDF document using OptimizationOptions
            pdfDocument.OptimizeResources(optimizeOptions);

            // Save updated document
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nUnused objects removed successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF optimization: {ex.Message}");
        }
    }
}