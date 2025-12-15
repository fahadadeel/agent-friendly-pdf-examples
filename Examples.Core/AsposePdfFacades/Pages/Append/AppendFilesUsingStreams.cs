using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.Append;

/// <summary>
/// Demonstrates appending PDF pages using streams with Aspose.Pdf.Facades.
/// </summary>
public class AppendFilesUsingStreams
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve directories relative to the application base path.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Define file paths.
        string inputPath1 = Path.Combine(inputDir, "input.pdf");
        string inputPath2 = Path.Combine(inputDir, "input2.pdf");
        string outputPath = Path.Combine(outputDir, "AppendFilesUsingStreams_out.pdf");

        try
        {
            // Create PdfFileEditor object.
            var pdfEditor = new PdfFileEditor();

            // Open streams and perform the append operation.
            using (FileStream inputStream = new FileStream(inputPath1, FileMode.Open, FileAccess.Read))
            using (FileStream appendStream = new FileStream(inputPath2, FileMode.Open, FileAccess.Read))
            using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                // Append pages from the second document to the first document.
                // Parameters: source stream, append stream, start page, end page, output stream.
                pdfEditor.Append(inputStream, appendStream, 1, 1, outputStream);
            }

            Console.WriteLine($"PDF files appended successfully. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while appending PDF files: {ex.Message}");
        }
    }
}