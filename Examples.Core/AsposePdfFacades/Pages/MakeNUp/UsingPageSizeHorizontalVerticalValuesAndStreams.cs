using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeNUp;

/// <summary>
/// Demonstrates making N-up pages using Aspose.Pdf.Facades with horizontal and vertical values,
/// reading from an input stream and writing to an output stream.
/// </summary>
public class UsingPageSizeHorizontalVerticalValuesAndStreams
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve base directory (application base)
        string baseDir = AppContext.BaseDirectory;

        // Input and output directories
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // File paths
        string inputPath = Path.Combine(inputDir, "input.pdf");
        string outputPath = Path.Combine(outputDir, "UsingPageSizeHorizontalVerticalValuesAndStreams_out.pdf");

        try
        {
            // Create PdfFileEditor object
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Open streams
            using FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            // Make N-up (2 columns, 3 rows)
            pdfEditor.MakeNUp(inputStream, outputStream, 2, 3);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during N-up processing: {ex.Message}");
        }
    }
}