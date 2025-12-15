using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.Append;

/// <summary>
/// Demonstrates appending multiple PDF files to an existing PDF using streams with Aspose.Pdf.Facades.
/// </summary>
public class AppendArrayOfFilesUsingStream
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure directories exist
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Input and output file paths
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string input2Path = Path.Combine(inputDir, "input2.pdf");
            string input3Path = Path.Combine(inputDir, "input3.pdf");
            string outputPath = Path.Combine(outputDir, "AppendArrayOfFilesUsingStream_out.pdf");

            // Create streams
            using var inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using var portStream0 = new FileStream(input2Path, FileMode.Open, FileAccess.Read);
            using var portStream1 = new FileStream(input3Path, FileMode.Open, FileAccess.Read);
            using var outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            Stream[] portStreams = new Stream[] { portStream0, portStream1 };

            // Append files
            var pdfEditor = new PdfFileEditor();
            pdfEditor.Append(inputStream, portStreams, 1, 1, outputStream);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AppendArrayOfFilesUsingStream: {ex.Message}");
        }
    }
}