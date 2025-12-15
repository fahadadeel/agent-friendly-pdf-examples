using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Devices;

namespace Examples.Core.AsposePDF.Images;

public class PageToTIFF
{
    /// <summary>
    /// Converts a single page of a PDF document to a TIFF image.
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

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "PageToTIFF.pdf");
            string outputPath = Path.Combine(outputDir, "PageToTIFF_out.tif");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Create Resolution object.
            Resolution resolution = new Resolution(300);

            // Create TiffSettings object.
            TiffSettings tiffSettings = new TiffSettings
            {
                Compression = CompressionType.None,
                Depth = ColorDepth.Default,
                Shape = ShapeType.Landscape,
                SkipBlankPages = false
            };

            // Create TIFF device.
            TiffDevice tiffDevice = new TiffDevice(resolution, tiffSettings);

            // Convert a particular page (page 1) and save the image.
            tiffDevice.Process(pdfDocument, 1, 1, outputPath);

            Console.WriteLine("PDF one page converted to TIFF successfully!");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF to TIFF conversion: {ex.Message}");
        }
    }
}