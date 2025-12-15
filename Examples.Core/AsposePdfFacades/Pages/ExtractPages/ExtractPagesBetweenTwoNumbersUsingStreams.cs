using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.ExtractPages;

/// <summary>
/// Demonstrates extracting pages 1 through 3 from a PDF using streams.
/// </summary>
public class ExtractPagesBetweenTwoNumbersUsingStreams
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // ExStart:ExtractPagesBetweenTwoNumbersUsingStreams
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "MultiplePages.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "ExtractPagesBetweenTwoNumbers_out.pdf");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Open streams for input and output.
            using var inputStream = File.OpenRead(inputPath);
            using var outputStream = File.OpenWrite(outputPath);

            // Extract pages 1 to 3.
            pdfEditor.Extract(inputStream, 1, 3, outputStream);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF page extraction: {ex.Message}");
        }
        // ExEnd:ExtractPagesBetweenTwoNumbersUsingStreams
    }
}