using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Pages;

/// <summary>
/// Demonstrates how to retrieve various page properties from a PDF document using Aspose.Pdf.
/// </summary>
public class GetProperties
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists (even if this example does not write output).
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Path to the source PDF file.
            string inputPath = Path.Combine(inputDir, "GetProperties.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open document
            Document pdfDocument = new Document(inputPath);

            // Get page collection
            PageCollection pageCollection = pdfDocument.Pages;

            // Get particular page (pages are 1‑based)
            Page pdfPage = pageCollection[1];

            // Output page properties
            Console.WriteLine(
                "ArtBox : Height={0},Width={1},LLX={2},LLY={3},URX={4},URY={5}",
                pdfPage.ArtBox.Height,
                pdfPage.ArtBox.Width,
                pdfPage.ArtBox.LLX,
                pdfPage.ArtBox.LLY,
                pdfPage.ArtBox.URX,
                pdfPage.ArtBox.URY);

            Console.WriteLine(
                "BleedBox : Height={0},Width={1},LLX={2},LLY={3},URX={4},URY={5}",
                pdfPage.BleedBox.Height,
                pdfPage.BleedBox.Width,
                pdfPage.BleedBox.LLX,
                pdfPage.BleedBox.LLY,
                pdfPage.BleedBox.URX,
                pdfPage.BleedBox.URY);

            Console.WriteLine(
                "CropBox : Height={0},Width={1},LLX={2},LLY={3},URX={4},URY={5}",
                pdfPage.CropBox.Height,
                pdfPage.CropBox.Width,
                pdfPage.CropBox.LLX,
                pdfPage.CropBox.LLY,
                pdfPage.CropBox.URX,
                pdfPage.CropBox.URY);

            Console.WriteLine(
                "MediaBox : Height={0},Width={1},LLX={2},LLY={3},URX={4},URY={5}",
                pdfPage.MediaBox.Height,
                pdfPage.MediaBox.Width,
                pdfPage.MediaBox.LLX,
                pdfPage.MediaBox.LLY,
                pdfPage.MediaBox.URX,
                pdfPage.MediaBox.URY);

            Console.WriteLine(
                "TrimBox : Height={0},Width={1},LLX={2},LLY={3},URX={4},URY={5}",
                pdfPage.TrimBox.Height,
                pdfPage.TrimBox.Width,
                pdfPage.TrimBox.LLX,
                pdfPage.TrimBox.LLY,
                pdfPage.TrimBox.URX,
                pdfPage.TrimBox.URY);

            Console.WriteLine(
                "Rect : Height={0},Width={1},LLX={2},LLY={3},URX={4},URY={5}",
                pdfPage.Rect.Height,
                pdfPage.Rect.Width,
                pdfPage.Rect.LLX,
                pdfPage.Rect.LLY,
                pdfPage.Rect.URX,
                pdfPage.Rect.URY);

            Console.WriteLine("Page Number : {0}", pdfPage.Number);
            Console.WriteLine("Rotate : {0}", pdfPage.Rotate);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while retrieving page properties: {ex.Message}");
        }
    }
}