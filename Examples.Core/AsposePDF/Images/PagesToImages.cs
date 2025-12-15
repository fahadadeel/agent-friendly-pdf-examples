using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Devices;

namespace Examples.Core.AsposePDF.Images;

public class PagesToImages
{
    /// <summary>
    /// Converts each page of a PDF document to separate JPEG images.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            // Path to the source PDF.
            string pdfPath = Path.Combine(inputDir, "PagesToImages.pdf");

            // Open document
            Document pdfDocument = new Document(pdfPath);

            for (int pageCount = 1; pageCount <= pdfDocument.Pages.Count; pageCount++)
            {
                string outputPath = Path.Combine(outputDir, $"image{pageCount}_out.jpg");

                using (FileStream imageStream = new FileStream(outputPath, FileMode.Create))
                {
                    // Create resolution object (300 DPI)
                    Resolution resolution = new Resolution(300);

                    // Create JPEG device with the resolution and quality 100.
                    JpegDevice jpegDevice = new JpegDevice(resolution, 100);

                    // Convert the page to an image and write to the stream.
                    jpegDevice.Process(pdfDocument.Pages[pageCount], imageStream);
                }
            }

            Console.WriteLine("PDF pages are converted to individual images successfully!");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF to image conversion: {ex.Message}");
        }
    }

    /// <summary>
    /// Converts the first page of a PDF document to a JPEG image.
    /// </summary>
    public static void SinglePageToImage()
    {
        try
        {
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string pdfPath = Path.Combine(inputDir, "PagesToImages.pdf");
            Document pdfDocument = new Document(pdfPath);

            string outputPath = Path.Combine(outputDir, "image1.jpg");

            using (FileStream imageStream = new FileStream(outputPath, FileMode.Create))
            {
                Resolution resolution = new Resolution(300);
                JpegDevice jpegDevice = new JpegDevice(resolution, 100);

                // Convert the first page.
                jpegDevice.Process(pdfDocument.Pages[1], imageStream);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during single page conversion: {ex.Message}");
        }
    }
}