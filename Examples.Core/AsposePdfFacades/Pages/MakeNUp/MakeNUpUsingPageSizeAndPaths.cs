using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeNUp;

public class MakeNUpUsingPageSizeAndPaths
{
    /// <summary>
    /// Demonstrates making N-up pages using a specific page size and file paths.
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
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "MultiplePages.pdf");
            string outputPath = Path.Combine(outputDir, "MakeNUpUsingPageSizeAndPaths_out.pdf");

            // Create PdfFileEditor object.
            var pdfEditor = new PdfFileEditor();

            // Make N-up (2 columns, 3 rows) using A5 page size.
            pdfEditor.MakeNUp(inputPath, outputPath, 2, 3, PageSize.A5);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during MakeNUp operation: {ex.Message}");
        }
    }
}