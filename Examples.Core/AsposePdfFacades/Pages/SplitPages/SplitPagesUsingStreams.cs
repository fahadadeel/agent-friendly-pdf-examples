using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.SplitPages;

/// <summary>
/// Demonstrates splitting pages of a PDF using streams with Aspose.Pdf.Facades.
/// </summary>
public class SplitPagesUsingStreams
{
    /// <summary>
    /// Splits the first three pages of a PDF and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string inputPath = Path.Combine(inputDir, "MultiplePages.pdf");
            string outputPath = Path.Combine(outputDir, "SplitPagesUsingStreams_out.pdf");

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Open streams.
            using FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            // Split pages: extract first 3 pages into a new document.
            pdfEditor.SplitFromFirst(inputStream, 3, outputStream);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during SplitPagesUsingStreams: {ex.Message}");
        }
    }
}