using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using System.Drawing;
using System.Drawing.Imaging;

namespace Examples.Core.AsposePdfFacades.Images;

/// <summary>
/// Demonstrates extracting images from a PDF using a defined extraction mode.
/// </summary>
public class ExtractImageExtractionMode
{
    /// <summary>
    /// Runs the image extraction example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Path to the source PDF.
            string inputPath = Path.Combine(inputDir, "ExtractImageExtractionMode.pdf");

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Initialize the PDF extractor.
            PdfExtractor extractor = new PdfExtractor();
            extractor.BindPdf(inputPath);

            // Specify the image extraction mode.
            extractor.ExtractImageMode = ExtractImageMode.DefinedInResources;

            // Extract images based on the specified mode.
            extractor.ExtractImage();

            // Retrieve and save all extracted images.
            while (extractor.HasNextImage())
            {
                string outputFile = Path.Combine(outputDir, $"{DateTime.Now.Ticks}_out.png");
                extractor.GetNextImage(outputFile, ImageFormat.Png);
            }

            Console.WriteLine("Image extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during image extraction: {ex.Message}");
        }
    }
}