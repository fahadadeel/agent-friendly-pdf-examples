using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

/// <summary>
/// Demonstrates conversion of a CGM image to PDF using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Images;

public class CGMImageToPDF
{
    /// <summary>
    /// Converts a CGM file to PDF and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base data directory relative to the application base path.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            string inputFile = Path.Combine(inputDir, "corvette.cgm");
            string outputFile = Path.Combine(outputDir, "CGMImageToPDF_out.pdf");

            // Convert CGM to PDF.
            PdfProducer.Produce(inputFile, ImportFormat.Cgm, outputFile);

            Console.WriteLine($"\nCGM file converted to PDF successfully.\nFile saved at {outputFile}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during CGM to PDF conversion: {ex.Message}");
        }
    }
}