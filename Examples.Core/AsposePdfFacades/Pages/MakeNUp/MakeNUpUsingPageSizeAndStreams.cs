using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeNUp;

/// <summary>
/// Demonstrates making N-up pages using Aspose.Pdf.Facades with page size and streams.
/// </summary>
public class MakeNUpUsingPageSizeAndStreams
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

            // Ensure the directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Define file paths.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "MakeNUpUsingPageSizeAndStreams_out.pdf");

            // Create PdfFileEditor object.
            var pdfEditor = new PdfFileEditor();

            // Open streams for input and output.
            using var inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using var outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            // Perform N-up operation: 2 columns, 3 rows, using A5 page size.
            pdfEditor.MakeNUp(inputStream, outputStream, 2, 3, PageSize.A5);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during MakeNUpUsingPageSizeAndStreams execution: {ex.Message}");
        }
    }
}