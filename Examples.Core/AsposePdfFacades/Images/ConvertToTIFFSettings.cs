using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Devices;

namespace Examples.Core.AsposePdfFacades.Images;

public class ConvertToTIFFSettings
{
    /// <summary>
    /// Demonstrates converting a PDF page to a TIFF image with custom settings using Aspose.Pdf.Facades.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "ConvertToTIFF-Settings.pdf");
            string outputPath = Path.Combine(outputDir, "output_out.tif");

            // Create PdfConverter object and bind input PDF file.
            PdfConverter pdfConverter = new PdfConverter();

            // Create Resolution object with 300 DPI.
            Resolution resolution = new Resolution(300);
            pdfConverter.Resolution = resolution;

            // Bind the source PDF file.
            pdfConverter.BindPdf(inputPath);

            // Start the conversion process.
            pdfConverter.DoConvert();

            // Create TiffSettings object and set ColorDepth.
            TiffSettings tiffSettings = new TiffSettings
            {
                Depth = ColorDepth.Format1bpp
            };

            // Convert to TIFF image.
            pdfConverter.SaveAsTIFF(outputPath, 300, 300, tiffSettings);

            // Close Converter object.
            pdfConverter.Close();

            Console.WriteLine($"TIFF image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF to TIFF conversion: {ex.Message}");
        }
    }
}