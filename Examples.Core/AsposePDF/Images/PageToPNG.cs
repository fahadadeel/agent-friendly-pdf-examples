using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Devices;

namespace Examples.Core.AsposePDF.Images;

public class PageToPNG
{
    /// <summary>
    /// Converts the first page of a PDF document to a PNG image.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = System.AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input PDF file path.
            string pdfPath = Path.Combine(inputDir, "PageToPNG.pdf");
            // Output PNG file path.
            string pngPath = Path.Combine(outputDir, "aspose-logo.png");

            // Open the PDF document.
            Document pdfDocument = new Document(pdfPath);

            // Create resolution (300 DPI) and PNG device.
            Resolution resolution = new Resolution(300);
            PngDevice pngDevice = new PngDevice(resolution);

            // Process the first page and save the image.
            using (FileStream imageStream = new FileStream(pngPath, FileMode.Create))
            {
                pngDevice.Process(pdfDocument.Pages[1], imageStream);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine($"Error in PageToPNG.Run: {ex.Message}");
        }
    }
}