using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Devices;
using System.Drawing;

namespace Examples.Core.AsposePDF.Images;

public class ConvertPageRegionToDOM
{
    /// <summary>
    /// Demonstrates converting a specific page region of a PDF to an image using Aspose.Pdf.
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

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "AddImage.pdf");
            string outputPath = Path.Combine(outputDir, "ConvertPageRegionToDOM_out.png");

            // Open the PDF document.
            Document document = new Document(inputPath);

            // Define the rectangle representing the desired page region.
            Aspose.Pdf.Rectangle pageRect = new Aspose.Pdf.Rectangle(20, 671, 693, 1125);

            // Apply the rectangle as the CropBox for the first page.
            document.Pages[1].CropBox = pageRect;

            // Save the cropped document into a memory stream.
            using var ms = new MemoryStream();
            document.Save(ms);

            // Re-open the cropped PDF from the memory stream.
            ms.Position = 0;
            document = new Document(ms);

            // Create a resolution object (300 DPI).
            Resolution resolution = new Resolution(300);

            // Create a PNG device with the specified resolution.
            PngDevice pngDevice = new PngDevice(resolution);

            // Convert the first page to PNG and save to the output path.
            pngDevice.Process(document.Pages[1], outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during conversion: {ex.Message}");
            return;
        }

        Console.WriteLine("\nPage region converted to DOM successfully.\nFile saved at data/outputs/ConvertPageRegionToDOM_out.png");
    }
}