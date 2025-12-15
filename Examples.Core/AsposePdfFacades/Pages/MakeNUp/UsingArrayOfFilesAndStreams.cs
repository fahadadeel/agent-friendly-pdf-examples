using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeNUp;

/// <summary>
/// Demonstrates making an N-up PDF from an array of input files using streams.
/// </summary>
public class UsingArrayOfFilesAndStreams
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
            Directory.CreateDirectory(outputDir);

            // Input file paths.
            string inputPath1 = Path.Combine(inputDir, "input.pdf");
            string inputPath2 = Path.Combine(inputDir, "input2.pdf");

            // Output file path.
            string outputPath = Path.Combine(outputDir, "UsingArrayOfFilesAndStreams_out.pdf");

            // Create streams for the input files.
            using FileStream stream1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read);
            using FileStream stream2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read);
            using FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            FileStream[] fileStreams = new FileStream[] { stream1, stream2 };

            // Create PdfFileEditor object and perform the N-up operation.
            PdfFileEditor pdfEditor = new PdfFileEditor();
            pdfEditor.MakeNUp(fileStreams, outputStream, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in UsingArrayOfFilesAndStreams.Run: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.