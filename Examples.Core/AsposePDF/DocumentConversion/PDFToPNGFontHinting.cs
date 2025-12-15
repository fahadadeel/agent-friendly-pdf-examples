using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Devices;

namespace Examples.Core.AsposePDF.DocumentConversion;

public class PDFToPNGFontHinting
{
    /// <summary>
    /// Converts each page of a PDF document to PNG images with font hinting enabled.
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

            // Path to the source PDF file.
            string inputPath = Path.Combine(inputDir, "input.pdf");

            // Load the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Enable font hinting via rendering options.
            RenderingOptions opts = new RenderingOptions
            {
                UseFontHinting = true
            };

            // Process each page.
            for (int pageNumber = 1; pageNumber <= pdfDocument.Pages.Count; pageNumber++)
            {
                string outputPath = Path.Combine(outputDir, $"image{pageNumber}_out.png");

                // Create the PNG device with desired resolution.
                Resolution resolution = new Resolution(300);
                PngDevice pngDevice = new PngDevice(resolution)
                {
                    RenderingOptions = opts
                };

                // Render the page to a file.
                using var imageStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
                pngDevice.Process(pdfDocument.Pages[pageNumber], imageStream);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}