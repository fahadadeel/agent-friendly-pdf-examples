using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.ExtractPages;

/// <summary>
/// Demonstrates extracting specific pages from a PDF using streams with Aspose.Pdf.Facades.
/// </summary>
public class ExtractArrayOfPagesUsingStreams
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        // Determine base directory (where the executable resides)
        string baseDir = AppContext.BaseDirectory;

        // Resolve input and output directories
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Input and output file paths
        string inputPath = Path.Combine(inputDir, "MultiplePages.pdf");
        string outputPath = Path.Combine(outputDir, "ExtractArrayOfPagesUsingStreams_out.pdf");

        try
        {
            // Create PdfFileEditor object
            var pdfEditor = new PdfFileEditor();

            // Open streams
            using var inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using var outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            int[] pagesToExtract = new int[] { 1, 2 };

            // Extract pages
            pdfEditor.Extract(inputStream, pagesToExtract, outputStream);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error extracting pages: {ex.Message}");
        }
    }
}