using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeBooklet;

public class MakeBookletUsingPageSizeLeftRightPagesAndStreams
{
    /// <summary>
    /// Demonstrates how to create a booklet PDF using streams, specifying page size and custom left/right page ordering.
    /// </summary>
    public static void Run()
    {
        // ExStart:MakeBookletUsingPageSizeLeftRightPagesAndStreams
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Define file paths.
            string inputPath = Path.Combine(inputDir, "MultiplePages.pdf");
            string outputPath = Path.Combine(outputDir, "MakeBookletUsingPageSizeLeftRightPagesAndStreams_out.pdf");

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Create streams for input and output.
            using var inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using var outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            // Set left and right pages.
            int[] leftPages = new int[] { 1, 5 };
            int[] rightPages = new int[] { 2, 3 };

            // Make booklet.
            pdfEditor.MakeBooklet(inputStream, outputStream, PageSize.A5, leftPages, rightPages);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during MakeBookletUsingPageSizeLeftRightPagesAndStreams: {ex.Message}");
        }
        // ExEnd:MakeBookletUsingPageSizeLeftRightPagesAndStreams
    }
}