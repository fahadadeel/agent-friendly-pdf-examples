using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.ConcatenateDocuments;

/// <summary>
/// Demonstrates concatenating PDF documents using Aspose.Pdf.Facades.
/// </summary>
public class ConcatenateUsingStreams
{
    /// <summary>
    /// Concatenates two PDF files using streams and writes the result to the outputs folder.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Define file paths.
        string inputPath1 = Path.Combine(inputDir, "input.pdf");
        string inputPath2 = Path.Combine(inputDir, "input2.pdf");
        string outputPath = Path.Combine(outputDir, "ConcatenateUsingStreams_out.pdf");

        try
        {
            // Create PdfFileEditor object.
            var pdfEditor = new PdfFileEditor();

            // Open streams using 'using' to ensure proper disposal.
            using var inputStream1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read);
            using var inputStream2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read);
            using var outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            // Concatenate the PDFs.
            pdfEditor.Concatenate(inputStream1, inputStream2, outputStream);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during concatenation: {ex.Message}");
        }
    }

    /// <summary>
    /// Concatenates two tagged PDF files, preserving their logical structure.
    /// </summary>
    public static void ConcatenateTaggedFiles()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Define file paths.
        string inputPath1 = Path.Combine(inputDir, "input.pdf");
        string inputPath2 = Path.Combine(inputDir, "input2.pdf");
        string outputPath = Path.Combine(outputDir, "ConcatenateTaggedFiles_out.pdf");

        try
        {
            // Open streams.
            using var fileInputStream1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read);
            using var fileInputStream2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read);
            using var fileOutputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            // Concatenate files with logical structure preservation.
            var editor = new PdfFileEditor
            {
                CopyLogicalStructure = true
            };

            bool success = editor.Concatenate(fileInputStream1, fileInputStream2, fileOutputStream);
            Console.Out.WriteLine("Successful... " + success);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during tagged concatenation: {ex.Message}");
        }
    }
}