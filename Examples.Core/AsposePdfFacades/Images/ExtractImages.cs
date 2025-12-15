using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Images;

/// <summary>
/// Demonstrates how to extract all images from a PDF document using Aspose.Pdf.Facades.
/// </summary>
public class ExtractImages
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

            // Ensure directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "ExtractImages.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Initialize the PDF extractor.
            PdfExtractor pdfExtractor = new PdfExtractor();
            pdfExtractor.BindPdf(inputPath);

            // Extract all images from the PDF.
            pdfExtractor.ExtractImage();

            // Retrieve each extracted image and save it to the output directory.
            while (pdfExtractor.HasNextImage())
            {
                string outputPath = Path.Combine(outputDir, $"{DateTime.Now.Ticks}_out.jpg");
                pdfExtractor.GetNextImage(outputPath);
                Console.WriteLine($"Extracted image saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during image extraction: {ex.Message}");
        }
    }
}