using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeBooklet;

public class MakeBookletUsingPageSizeAndPaths
{
    /// <summary>
    /// Demonstrates how to create a booklet PDF using a specific page size and file paths.
    /// </summary>
    public static void Run()
    {
        // ExStart:MakeBookletUsingPageSizeAndPaths
        try
        {
            // Resolve base directory (directory where the application is running)
            string baseDir = AppContext.BaseDirectory;

            // Input and output directories
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Build full file paths
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "MakeBookletUsingPageSizeAndPaths_out.pdf");

            // Create PdfFileEditor object
            var pdfEditor = new PdfFileEditor();

            // Make booklet using A5 page size
            pdfEditor.MakeBooklet(inputPath, outputPath, PageSize.A5);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during MakeBookletUsingPageSizeAndPaths: {ex.Message}");
        }
        // ExEnd:MakeBookletUsingPageSizeAndPaths
    }
}