using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.Append;

public class AppendArrayOfFiles
{
    /// <summary>
    /// Demonstrates appending an array of PDF files using Aspose.Pdf.Facades.PdfFileEditor.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input files.
            string inputFile1 = Path.Combine(inputDir, "input.pdf");
            string inputFile2 = Path.Combine(inputDir, "input2.pdf");
            string sourceFile = Path.Combine(inputDir, "input3.pdf");

            // Output file.
            string outputFile = Path.Combine(outputDir, "AppendArrayOfFiles_out.pdf");

            // Create PdfFileEditor object.
            var pdfEditor = new PdfFileEditor();

            // Array of files to append.
            string[] filesToAppend = new string[] { inputFile1, inputFile2 };

            // Append files. Parameters: source file, array of files, start page, end page, output file.
            pdfEditor.Append(sourceFile, filesToAppend, 1, 1, outputFile);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during AppendArrayOfFiles example: {ex.Message}");
        }
    }
}