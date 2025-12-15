using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeBooklet;

/// <summary>
/// Demonstrates making a booklet from a PDF using streams and a specific page size.
/// </summary>
public class MakeBookletUsingPageSizeAndStreams
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "MakeBookletUsingPageSizeAndStreams_out.pdf");

            // Create PdfFileEditor object.
            var pdfEditor = new PdfFileEditor();

            // Open streams for input and output.
            using var inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using var outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            // Make booklet with A5 page size.
            pdfEditor.MakeBooklet(inputStream, outputStream, PageSize.A5);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during MakeBookletUsingPageSizeAndStreams execution: {ex.Message}");
        }
    }
}