using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Images;

/// <summary>
/// Demonstrates extracting images from a PDF using Aspose.Pdf.Facades.PdfExtractor.
/// Input PDF is read from the "data/inputs" folder relative to the application base directory.
/// Extracted images are written to the "data/outputs" folder.
/// </summary>
public class ExtractImagesStream
{
    public static void Run()
    {
        try
        {
            // Resolve directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input PDF file path.
            string inputPdfPath = Path.Combine(inputDir, "ExtractImages-Stream.pdf");
            if (!File.Exists(inputPdfPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPdfPath}");
                return;
            }

            // Initialize extractor and bind the PDF.
            PdfExtractor pdfExtractor = new PdfExtractor();
            pdfExtractor.BindPdf(inputPdfPath);

            // Extract images.
            pdfExtractor.ExtractImage();

            // Iterate through extracted images.
            while (pdfExtractor.HasNextImage())
            {
                using MemoryStream memoryStream = new MemoryStream();
                pdfExtractor.GetNextImage(memoryStream);
                memoryStream.Position = 0; // Reset stream position before writing.

                string outputFileName = $"{DateTime.Now.Ticks}_out.jpg";
                string outputPath = Path.Combine(outputDir, outputFileName);

                using FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
                memoryStream.CopyTo(fileStream);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}