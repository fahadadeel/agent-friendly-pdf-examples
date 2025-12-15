using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.ConcatenateDocuments;

/// <summary>
/// Demonstrates concatenating multiple PDF documents using streams with Aspose.Pdf.Facades.
/// </summary>
public class ConcatenateArrayOfPdfUsingStreams
{
    /// <summary>
    /// Executes the concatenation example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories relative to the application base path.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Prepare input file paths.
            string inputPath1 = Path.Combine(inputDir, "input.pdf");
            string inputPath2 = Path.Combine(inputDir, "input2.pdf");

            // Prepare output file path.
            string outputPath = Path.Combine(outputDir, "ConcatenateArrayOfPdfUsingStreams_out.pdf");

            // Create the PdfFileEditor instance.
            var pdfEditor = new PdfFileEditor();

            // Open input streams.
            FileStream[] inputStreams = new FileStream[2];
            inputStreams[0] = new FileStream(inputPath1, FileMode.Open, FileAccess.Read);
            inputStreams[1] = new FileStream(inputPath2, FileMode.Open, FileAccess.Read);

            // Open output stream.
            using var outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            // Concatenate the PDFs.
            pdfEditor.Concatenate(inputStreams, outputStream);

            Console.WriteLine($"PDF files concatenated successfully. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during PDF concatenation: {ex.Message}");
        }
    }
}