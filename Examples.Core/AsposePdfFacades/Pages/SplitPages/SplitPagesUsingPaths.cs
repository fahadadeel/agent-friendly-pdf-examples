using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.SplitPages;

/// <summary>
/// Demonstrates splitting a PDF document using file paths with Aspose.Pdf.Facades.
/// </summary>
public class SplitPagesUsingPaths
{
    /// <summary>
    /// Splits the first three pages of a PDF and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = Path.Combine(AppContext.BaseDirectory, "data");
            string inputDir = Path.Combine(baseDir, "inputs");
            string outputDir = Path.Combine(baseDir, "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "MultiplePages.pdf");
            string outputPath = Path.Combine(outputDir, "SplitPagesUsingPaths_out.pdf");

            // Validate input file existence.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Split pages: extract the first 3 pages into a new PDF.
            pdfEditor.SplitFromFirst(inputPath, 3, outputPath);

            Console.WriteLine($"PDF split successfully. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while splitting the PDF: {ex.Message}");
        }
    }
}