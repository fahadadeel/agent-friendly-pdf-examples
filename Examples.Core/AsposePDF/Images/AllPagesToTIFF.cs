using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Devices;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates converting all pages of a PDF document to a single TIFF image using Aspose.Pdf.
/// </summary>
public class AllPagesToTIFF
{
    /// <summary>
    /// Executes the conversion.
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
                Directory.CreateDirectory(outputDir);

            // Define input PDF and output TIFF file paths.
            string inputPath = Path.Combine(inputDir, "PageToTIFF.pdf");
            string outputPath = Path.Combine(outputDir, "AllPagesToTIFF_out.tif");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Create a resolution object (300 DPI).
            Resolution resolution = new Resolution(300);

            // Configure TIFF settings.
            TiffSettings tiffSettings = new TiffSettings
            {
                Compression = CompressionType.None,
                Depth = ColorDepth.Default,
                Shape = ShapeType.Landscape,
                SkipBlankPages = false
            };

            // Initialize the TIFF device with the resolution and settings.
            TiffDevice tiffDevice = new TiffDevice(resolution, tiffSettings);

            // Convert all pages of the PDF to a single TIFF file.
            tiffDevice.Process(pdfDocument, outputPath);

            Console.WriteLine("PDF all pages converted to one TIFF file successfully!");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF to TIFF conversion: {ex.Message}");
        }
    }
}