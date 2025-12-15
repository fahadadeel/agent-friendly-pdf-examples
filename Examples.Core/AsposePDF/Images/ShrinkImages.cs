using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Optimization;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates how to shrink images in a PDF using Aspose.Pdf.
/// </summary>
public class ShrinkImages
{
    /// <summary>
    /// Executes the image shrinking example.
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
            string inputPath = Path.Combine(inputDir, "Shrinkimage.pdf");
            string outputPath = Path.Combine(outputDir, "Shrinkimage_out.pdf");

            // Open document.
            var pdfDocument = new Document(inputPath);

            // Initialize OptimizationOptions.
            var optimizeOptions = new OptimizationOptions();

            // Set CompressImages option.
            optimizeOptions.ImageCompressionOptions.CompressImages = true;

            // Set ImageQuality option.
            optimizeOptions.ImageCompressionOptions.ImageQuality = 50;

            // Optimize PDF document using OptimizationOptions.
            pdfDocument.OptimizeResources(optimizeOptions);

            // Save updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nImage shrinked successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during ShrinkImages.Run: {ex.Message}");
        }
    }
}