using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Devices;

namespace Examples.Core.AsposePDF.Images;

public class ConvertAllPagesToPNG
{
    /// <summary>
    /// Converts each page of a PDF document to a separate PNG image.
    /// Input PDF is read from <c>data/inputs</c> relative to the application base directory.
    /// Output PNG files are written to <c>data/outputs</c>.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base path.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "ConvertAllPagesToPNG.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Iterate through all pages.
            for (int pageNumber = 1; pageNumber <= pdfDocument.Pages.Count; pageNumber++)
            {
                string outputPath = Path.Combine(outputDir, $"image{pageNumber}_out.png");

                // Create PNG device with desired resolution.
                Resolution resolution = new Resolution(300);
                var pngDevice = new PngDevice(resolution); // AUTOFIX: PngDevice does not implement IDisposable

                // Process the page and write to the output file.
                using FileStream imageStream = new FileStream(outputPath, FileMode.Create);
                pngDevice.Process(pdfDocument.Pages[pageNumber], imageStream);
            }

            Console.WriteLine("PDF pages are converted to PNG successfully!");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during conversion: {ex.Message}");
        }
    }
}