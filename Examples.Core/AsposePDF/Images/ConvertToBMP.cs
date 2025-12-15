using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Devices;
using System.Drawing;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates converting each page of a PDF document to BMP images using Aspose.Pdf.
/// </summary>
public class ConvertToBMP
{
    /// <summary>
    /// Executes the conversion process.
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

            // Input PDF file.
            string pdfPath = Path.Combine(inputDir, "AddImage.pdf");

            // Open document
            Document pdfDocument = new Document(pdfPath);

            for (int pageCount = 1; pageCount <= pdfDocument.Pages.Count; pageCount++)
            {
                string outputPath = Path.Combine(outputDir, $"image{pageCount}_out.bmp");
                using (FileStream imageStream = new FileStream(outputPath, FileMode.Create))
                {
                    // Create Resolution object
                    Resolution resolution = new Resolution(300);
                    // Create BMP device with specified attributes
                    BmpDevice bmpDevice = new BmpDevice(resolution);
                    // Convert a particular page and save the image to stream
                    bmpDevice.Process(pdfDocument.Pages[pageCount], imageStream);
                }
            }

            Console.WriteLine("\nPDF file converted to bmp successfully!");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF to BMP conversion: {ex.Message}");
        }
    }
}