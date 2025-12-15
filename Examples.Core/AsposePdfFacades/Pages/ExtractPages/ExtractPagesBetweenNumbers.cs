using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

/// <summary>
/// Demonstrates extracting a range of pages from a PDF using Aspose.Pdf.Facades.
/// </summary>
namespace Examples.Core.AsposePdfFacades.Pages.ExtractPages;

public class ExtractPagesBetweenNumbers
{
    /// <summary>
    /// Extracts pages 1 through 3 from the input PDF and saves the result.
    /// </summary>
    public static void Run()
    {
        // ExStart:ExtractPagesBetweenNumbers
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "MultiplePages.pdf");
            string outputPath = Path.Combine(outputDir, "ExtractPagesBetweenNumbers_out.pdf");

            // Create PdfFileEditor object.
            var pdfEditor = new PdfFileEditor();

            // Extract pages 1 to 3.
            pdfEditor.Extract(inputPath, 1, 3, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error extracting pages: {ex.Message}");
        }
        // ExEnd:ExtractPagesBetweenNumbers
    }
}