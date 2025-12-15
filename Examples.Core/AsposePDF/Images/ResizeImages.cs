using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Optimization;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates how to resize images in a PDF document using Aspose.Pdf.
/// </summary>
public class ResizeImages
{
    /// <summary>
    /// Executes the image‑resize example.
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
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "ResizeImage.pdf");
            string outputPath = Path.Combine(outputDir, "ResizeImages_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Initialize optimization options.
            var optimizeOptions = new OptimizationOptions();

            // Configure image compression and resizing.
            optimizeOptions.ImageCompressionOptions.CompressImages = true;
            optimizeOptions.ImageCompressionOptions.ImageQuality = 75;
            optimizeOptions.ImageCompressionOptions.ResizeImages = true;
            optimizeOptions.ImageCompressionOptions.MaxResolution = 300;

            // Optimize the PDF document using the configured options.
            pdfDocument.OptimizeResources(optimizeOptions);

            // Save the updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nImage resized successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while resizing images: {ex.Message}");
        }
    }
}