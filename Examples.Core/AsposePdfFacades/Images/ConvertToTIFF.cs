using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Devices;

namespace Examples.Core.AsposePdfFacades.Images;

/// <summary>
/// Demonstrates converting a PDF document to a TIFF image using Aspose.Pdf.Facades.
/// </summary>
public class ConvertToTIFF
{
    /// <summary>
    /// Executes the conversion example.
    /// </summary>
    public static void Run()
    {
        // ExStart:ConvertToTIFF
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "ConvertToTIFF-Settings.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "output_out.tif");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create PdfConverter object and bind input PDF file.
            PdfConverter pdfConverter = new PdfConverter();

            // Bind the source PDF file.
            pdfConverter.BindPdf(inputPath);

            // Start the conversion process.
            pdfConverter.DoConvert();

            // Convert to TIFF image.
            pdfConverter.SaveAsTIFF(outputPath);

            // Close Converter object.
            pdfConverter.Close();
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error during PDF to TIFF conversion: {ex.Message}");
        }
        // ExEnd:ConvertToTIFF
    }
}