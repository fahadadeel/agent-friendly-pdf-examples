using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Images;

/// <summary>
/// Demonstrates how to extract images from a specific page of a PDF document using Aspose.Pdf.Facades.
/// </summary>
public class ExtractImagesPage
{
    /// <summary>
    /// Executes the image extraction example.
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
            {
                Directory.CreateDirectory(outputDir);
            }

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "ExtractImages-Page.pdf");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open input PDF.
            PdfExtractor pdfExtractor = new PdfExtractor();
            pdfExtractor.BindPdf(inputPath);

            // Set the page range (extract images from page 2 only).
            pdfExtractor.StartPage = 2;
            pdfExtractor.EndPage = 2;

            // Extract images.
            pdfExtractor.ExtractImage();

            // Process extracted images.
            while (pdfExtractor.HasNextImage())
            {
                using MemoryStream memoryStream = new MemoryStream();
                pdfExtractor.GetNextImage(memoryStream);

                // Reset stream position before writing.
                memoryStream.Position = 0;

                string outputFileName = $"{DateTime.Now.Ticks}_out.jpg";
                string outputPath = Path.Combine(outputDir, outputFileName);

                using FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
                memoryStream.CopyTo(fileStream);
                Console.WriteLine($"Image extracted to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during image extraction: {ex.Message}");
        }
    }
}