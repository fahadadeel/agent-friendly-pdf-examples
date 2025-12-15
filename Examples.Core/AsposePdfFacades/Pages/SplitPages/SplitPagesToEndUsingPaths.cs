using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.SplitPages;

public class SplitPagesToEndUsingPaths
{
    /// <summary>
    /// Splits a PDF document from a specified start page to the end and saves the result.
    /// Input files are resolved from the "data/inputs" folder and output files are written to the "data/outputs" folder.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "MultiplePages.pdf");
            string outputPath = Path.Combine(baseDir, "data", "outputs", "SplitPagesToEndUsingPaths_out.pdf");

            // Ensure the output directory exists.
            string? outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Split pages from page 3 to the end.
            pdfEditor.SplitToEnd(inputPath, 3, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF split operation: {ex.Message}");
        }
    }
}