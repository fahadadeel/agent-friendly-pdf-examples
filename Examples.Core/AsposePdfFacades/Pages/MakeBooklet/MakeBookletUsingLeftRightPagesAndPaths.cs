using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeBooklet;

/// <summary>
/// Demonstrates making a booklet from a PDF using left and right page arrays,
/// reading input from data/inputs and writing output to data/outputs.
/// </summary>
public class MakeBookletUsingLeftRightPagesAndPaths
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // ExStart:MakeBookletUsingLeftRightPagesAndPaths
        try
        {
            // Resolve base directory (application base)
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input and output file paths
            string inputPath = Path.Combine(inputDir, "MultiplePages.pdf");
            string outputPath = Path.Combine(outputDir, "MakeBookletUsingLeftRightPagesAndPaths_out.pdf");

            // Create PdfFileEditor object
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Set left and right pages
            int[] leftPages = new int[] { 1, 5 };
            int[] rightPages = new int[] { 2, 3 };

            // Make booklet
            pdfEditor.MakeBooklet(inputPath, outputPath, leftPages, rightPages);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during MakeBookletUsingLeftRightPagesAndPaths: {ex.Message}");
        }
        // ExEnd:MakeBookletUsingLeftRightPagesAndPaths
    }
}