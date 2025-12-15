using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.ExtractPages;

/// <summary>
/// Demonstrates extracting a specific array of pages from a PDF using Aspose.Pdf.Facades.
/// </summary>
public class ExtractArrayOfPages
{
    /// <summary>
    /// Executes the page extraction example.
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
            {
                Directory.CreateDirectory(outputDir);
            }

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "Extract.pdf");
            string outputPath = Path.Combine(outputDir, "ExtractArrayOfPages_out.pdf");

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Pages to extract (1‑based indexing as required by Aspose.Pdf).
            int[] pagesToExtract = new int[] { 1, 2 };

            // Extract the specified pages.
            pdfEditor.Extract(inputPath, pagesToExtract, outputPath);

            Console.WriteLine($"Pages extracted successfully to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during PDF page extraction: {ex.Message}");
        }
    }
}