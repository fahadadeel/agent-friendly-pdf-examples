using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

/// <summary>
/// Demonstrates appending PDF files using Aspose.Pdf.Facades.
/// </summary>
namespace Examples.Core.AsposePdfFacades.Pages.Append;

public class AppendFiles
{
    /// <summary>
    /// Appends the second PDF to the first PDF and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Define file paths.
            string firstPdf = Path.Combine(inputDir, "input.pdf");
            string secondPdf = Path.Combine(inputDir, "input2.pdf");
            string resultPdf = Path.Combine(outputDir, "AppendFiles_out.pdf");

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Append the second PDF to the first PDF.
            // Parameters: sourceFile, fileToAppend, startPage, endPage, outputFile
            pdfEditor.Append(firstPdf, secondPdf, 1, 1, resultPdf);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF append operation: {ex.Message}");
        }
    }
}