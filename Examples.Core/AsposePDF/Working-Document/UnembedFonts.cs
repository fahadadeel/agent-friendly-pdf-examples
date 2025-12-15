using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Optimization;

namespace Examples.Core.AsposePDF.Working_Document;

/// <summary>
/// Demonstrates how to unembed fonts from a PDF document using Aspose.Pdf.
/// </summary>
public class UnembedFonts
{
    /// <summary>
    /// Executes the unembed fonts example.
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

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "OptimizeDocument.pdf");
            string outputPath = Path.Combine(outputDir, "OptimizeDocument_out.pdf");

            // Open the PDF document.
            var pdfDocument = new Document(inputPath);

            // Set the UnembedFonts option.
            var optimizeOptions = new OptimizationOptions
            {
                UnembedFonts = true
            };

            Console.WriteLine("Start");

            // Optimize PDF document using the specified options.
            pdfDocument.OptimizeResources(optimizeOptions);

            // Save the updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("Finished");

            var fiOriginal = new FileInfo(inputPath);
            var fiOptimized = new FileInfo(outputPath);
            Console.WriteLine($"Original file size: {fiOriginal.Length}. Reduced file size: {fiOptimized.Length}");

            Console.WriteLine("\nUnembeded fonts successfully.\nFile saved at " + outputDir);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in UnembedFonts.Run: {ex.Message}");
        }
    }
}