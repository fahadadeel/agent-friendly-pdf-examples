using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using System.Drawing.Imaging;

namespace Examples.Core.AsposePdfFacades.Images;

/// <summary>
/// Demonstrates converting each page of a PDF document to separate JPEG images using Aspose.Pdf.Facades.
/// </summary>
public class ConvertPDFPages
{
    /// <summary>
    /// Executes the PDF‑to‑image conversion example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Input PDF file path.
        string inputPath = Path.Combine(inputDir, "ConvertPDFPages.pdf");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        PdfConverter objConverter = null;
        try
        {
            // Create PdfConverter object and bind the input PDF.
            objConverter = new PdfConverter();
            objConverter.BindPdf(inputPath);

            // Initialize the converting process.
            objConverter.DoConvert();

            // Use CropBox coordinates for conversion.
            objConverter.CoordinateType = PageCoordinateType.CropBox;

            // Convert each page to a JPEG image.
            while (objConverter.HasNextImage())
            {
                string outputFileName = $"{DateTime.Now.Ticks}_out.jpg";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Convert the current page to an image.
                objConverter.GetNextImage(outputPath, ImageFormat.Jpeg);
                Console.WriteLine($"Page saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during conversion: {ex.Message}");
        }
        finally
        {
            // Close the PdfConverter object if it was created.
            objConverter?.Close();
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.