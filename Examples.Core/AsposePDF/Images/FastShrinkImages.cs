using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Optimization;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates fast image compression (shrink) for a PDF document using Aspose.Pdf.
/// </summary>
public class FastShrinkImages
{
    /// <summary>
    /// Executes the fast image shrink example.
    /// </summary>
    public static void Run()
    {
        // Initialize timing.
        var startTicks = DateTime.Now.Ticks;

        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Define input and output file paths.
        string inputPath = Path.Combine(inputDir, "Shrinkimage.pdf");
        string outputPath = Path.Combine(outputDir, "FastShrinkImages_out.pdf");

        try
        {
            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Initialize optimization options.
            var optimizeOptions = new OptimizationOptions();

            // Configure image compression settings.
            optimizeOptions.ImageCompressionOptions.CompressImages = true;
            optimizeOptions.ImageCompressionOptions.ImageQuality = 75;
            optimizeOptions.ImageCompressionOptions.Version = ImageCompressionVersion.Fast;

            // Optimize PDF document using the configured options.
            pdfDocument.OptimizeResources(optimizeOptions);

            // Save the updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("Ticks: {0}", DateTime.Now.Ticks - startTicks);
            Console.WriteLine("\nImage fast shrinked successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while processing the PDF: {ex.Message}");
        }
    }
}