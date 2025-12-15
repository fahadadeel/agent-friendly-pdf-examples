using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.ConcatenateDocuments;

/// <summary>
/// Demonstrates concatenating PDF documents with a blank PDF using Aspose.Pdf.Facades.
/// </summary>
public class ConcatenateWithBlankPdf
{
    /// <summary>
    /// Executes the concatenation example.
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Build full paths for the source PDFs and the result PDF.
            string inputPath1 = Path.Combine(inputDir, "input.pdf");
            string inputPath2 = Path.Combine(inputDir, "input2.pdf");
            string blankPath = Path.Combine(inputDir, "blank.pdf");
            string outputPath = Path.Combine(outputDir, "ConcatenateWithBlankPdf_out.pdf");

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Concatenate files.
            pdfEditor.Concatenate(inputPath1, inputPath2, blankPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF concatenation: {ex.Message}");
        }
    }
}