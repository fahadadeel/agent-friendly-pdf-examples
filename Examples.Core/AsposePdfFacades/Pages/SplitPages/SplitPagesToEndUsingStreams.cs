using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.SplitPages;

/// <summary>
/// Demonstrates splitting a PDF from a given page to the end using streams.
/// </summary>
public class SplitPagesToEndUsingStreams
{
    /// <summary>
    /// Executes the split operation.
    /// </summary>
    public static void Run()
    {
        // ExStart:SplitPagesToEndUsingStreams
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");

            // Ensure directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Define full paths for the input and output PDF files.
            string inputPath = Path.Combine(inputDir, "MultiplePages.pdf");
            string outputPath = Path.Combine(outputDir, "SplitPagesToEndUsingStreams_out.pdf");

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Open streams for input and output.
            using FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            // Split pages from page 3 to the end.
            pdfEditor.SplitToEnd(inputStream, 3, outputStream);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF split operation: {ex.Message}");
        }
        // ExEnd:SplitPagesToEndUsingStreams
    }
}