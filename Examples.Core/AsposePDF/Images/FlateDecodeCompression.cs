using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Optimization;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates how to compress images in a PDF using FlateDecode compression with Aspose.Pdf.
/// </summary>
public class FlateDecodeCompression
{
    /// <summary>
    /// Executes the FlateDecode compression example.
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
        string inputPath = Path.Combine(inputDir, "AddImage.pdf");
        string outputPath = Path.Combine(outputDir, "FlateDecodeCompression.pdf");

        try
        {
            // Open the source PDF document.
            Document doc = new Document(inputPath);

            // Initialize optimization options.
            var optimizationOptions = new OptimizationOptions();

            // Set image compression to FlateDecode.
            optimizationOptions.ImageCompressionOptions.Encoding = ImageEncoding.Flate;

            // Apply optimization to the document.
            doc.OptimizeResources(optimizationOptions);

            // Save the optimized PDF.
            doc.Save(outputPath);

            Console.WriteLine($"Document saved successfully to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during PDF optimization: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.