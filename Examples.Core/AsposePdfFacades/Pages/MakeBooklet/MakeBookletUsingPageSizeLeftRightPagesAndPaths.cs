using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeBooklet;

/// <summary>
/// Demonstrates creating a booklet PDF using specific page sizes, left/right page selections, and file paths.
/// </summary>
public class MakeBookletUsingPageSizeLeftRightPagesAndPaths
{
    /// <summary>
    /// Executes the example.
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "MultiplePages.pdf");
            string outputPath = Path.Combine(outputDir, "MakeBookletUsingPageSizeLeftRightPagesAndPaths_out.pdf");

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Set left and right pages.
            int[] leftPages = new int[] { 1, 5 };
            int[] rightPages = new int[] { 2, 3 };

            // Make booklet.
            pdfEditor.MakeBooklet(inputPath, outputPath, PageSize.A5, leftPages, rightPages);

            Console.WriteLine($"Booklet created successfully at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during MakeBooklet example: {ex.Message}");
        }
    }
}