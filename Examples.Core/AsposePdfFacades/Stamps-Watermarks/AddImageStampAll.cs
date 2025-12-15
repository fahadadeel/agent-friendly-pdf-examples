using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Stamps_Watermarks;

/// <summary>
/// Demonstrates adding an image stamp to every page of a PDF using Aspose.Pdf.Facades.
/// </summary>
public class AddImageStampAll
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Input and output file paths
            string inputPdfPath = Path.Combine(inputDir, "AddImageStampAll.pdf");
            string inputImagePath = Path.Combine(inputDir, "aspose-logo.jpg");
            string outputPdfPath = Path.Combine(outputDir, "AddImageStampAll_out.pdf");

            // Create PdfFileStamp object
            using var fileStamp = new PdfFileStamp();

            // Open Document
            fileStamp.BindPdf(inputPdfPath);

            // Create stamp (explicitly specify the Facades namespace to avoid ambiguity)
            var stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindImage(inputImagePath);
            stamp.SetOrigin(200, 200);
            stamp.Rotation = 90.0F;
            stamp.IsBackground = true;

            // Add stamp to PDF file
            fileStamp.AddStamp(stamp);

            // Save updated PDF file
            fileStamp.Save(outputPdfPath);

            // Close fileStamp (handled by using)
            Console.WriteLine($"Stamp added successfully. Output saved to: {outputPdfPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during AddImageStampAll execution: {ex.Message}");
        }
    }
}