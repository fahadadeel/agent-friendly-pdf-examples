using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.InsertPages;

/// <summary>
/// Demonstrates inserting pages from one PDF into another using streams.
/// </summary>
public class InsertPagesBetweenNumbersUsingStreams
{
    /// <summary>
    /// Executes the insert pages example.
    /// </summary>
    public static void Run()
    {
        // ExStart:InsertPagesBetweenNumbersUsingStreams
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Define file paths.
            string sourcePdfPath = Path.Combine(inputDir, "MultiplePages.pdf");
            string insertPdfPath = Path.Combine(inputDir, "InsertPages.pdf");
            string outputPdfPath = Path.Combine(outputDir, "InsertPagesBetweenNumbersUsingStreams_out.pdf");

            // Create PdfFileEditor object.
            var pdfEditor = new PdfFileEditor();

            // Open streams for the source PDF, the PDF containing pages to insert, and the output PDF.
            using var inputStream = new FileStream(sourcePdfPath, FileMode.Open, FileAccess.Read);
            using var portStream = new FileStream(insertPdfPath, FileMode.Open, FileAccess.Read);
            using var outputStream = new FileStream(outputPdfPath, FileMode.Create, FileAccess.Write);

            // Insert pages 1‑4 from the insert PDF after page 1 of the source PDF.
            pdfEditor.Insert(inputStream, 1, portStream, 1, 4, outputStream);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during InsertPagesBetweenNumbersUsingStreams: {ex.Message}");
        }
        // ExEnd:InsertPagesBetweenNumbersUsingStreams
    }
}