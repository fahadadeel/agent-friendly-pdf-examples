using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Devices;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates conversion of a PDF page to a TIFF image and applies the Bradley binarization algorithm.
/// </summary>
public class BradleyAlgorithm
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve base directories relative to the application base path.
        string baseDir = AppContext.BaseDirectory ?? Directory.GetCurrentDirectory();
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure output directory exists.
        Directory.CreateDirectory(outputDir);

        // Input and output file paths.
        string inputPdfPath = Path.Combine(inputDir, "PageToTIFF.pdf");
        string outputImagePath = Path.Combine(outputDir, "resultant_out.tif");
        string outputBinImagePath = Path.Combine(outputDir, "37116-bin_out.tif");

        try
        {
            // Open the PDF document.
            Document pdfDocument = new Document(inputPdfPath);

            // Create resolution and TIFF settings.
            Resolution resolution = new Resolution(300);
            TiffSettings tiffSettings = new TiffSettings
            {
                Compression = CompressionType.LZW,
                Depth = ColorDepth.Format1bpp
            };

            // Initialize the TIFF device.
            TiffDevice tiffDevice = new TiffDevice(resolution, tiffSettings);

            // Convert the PDF page to a TIFF image.
            tiffDevice.Process(pdfDocument, outputImagePath);

            // Apply Bradley binarization.
            using (FileStream inStream = new FileStream(outputImagePath, FileMode.Open, FileAccess.Read))
            using (FileStream outStream = new FileStream(outputBinImagePath, FileMode.Create, FileAccess.Write))
            {
                tiffDevice.BinarizeBradley(inStream, outStream, 0.1);
            }

            Console.WriteLine("Conversion using Bradley algorithm performed successfully!");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during processing: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.