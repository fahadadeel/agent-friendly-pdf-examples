using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeNUp;

/// <summary>
/// Demonstrates making N-up PDF using streams with Aspose.Pdf.Facades.
/// </summary>
public class MakeNUpUsingStreams
{
    /// <summary>
    /// Runs the MakeNUp example.
    /// </summary>
    public static void Run()
    {
        // ExStart:MakeNUpUsingStreams
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath1 = Path.Combine(inputDir, "input.pdf");
            string inputPath2 = Path.Combine(inputDir, "input2.pdf");
            string outputPath = Path.Combine(outputDir, "MakeNUpUsingStreams_out.pdf");

            // Create PdfFileEditor object
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Open streams
            using var inputStream1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read);
            using var inputStream2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read);
            using var outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            // Make NUp
            pdfEditor.MakeNUp(inputStream1, inputStream2, outputStream);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during MakeNUpUsingStreams: {ex.Message}");
        }
        // ExEnd:MakeNUpUsingStreams
    }
}