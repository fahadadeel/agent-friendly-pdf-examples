using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.ConcatenateDocuments;

/// <summary>
/// Demonstrates concatenating PDF documents using Aspose.Pdf.Facades.
/// </summary>
public class ConcatenateUsingPath
{
    /// <summary>
    /// Concatenates two PDF files located in the input directory and writes the result to the output directory.
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

            // Define input and output file paths.
            string inputPath1 = Path.Combine(inputDir, "input.pdf");
            string inputPath2 = Path.Combine(inputDir, "input2.pdf");
            string outputPath = Path.Combine(outputDir, "ConcatenateUsingPath_out.pdf");

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Concatenate files.
            pdfEditor.Concatenate(inputPath1, inputPath2, outputPath);

            Console.WriteLine($"Concatenated PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during Run: {ex.Message}");
        }
    }

    /// <summary>
    /// Concatenates all PDF files in the input directory without copying outlines, and writes the result to the output directory.
    /// </summary>
    public static void CopyOutline()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Get all PDF files from the input directory.
            string[] files = Directory.GetFiles(inputDir, "*.pdf");

            if (files.Length == 0)
            {
                Console.WriteLine("No PDF files found in the input directory.");
                return;
            }

            // Create PdfFileEditor object.
            PdfFileEditor pfe = new PdfFileEditor
            {
                // Do not copy outlines from source documents.
                CopyOutlines = false
            };

            // Define output file path.
            string outputPath = Path.Combine(outputDir, "CopyOutline_out.pdf");

            // Concatenate files.
            pfe.Concatenate(files, outputPath);

            Console.WriteLine($"Concatenated PDF without outlines saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during CopyOutline: {ex.Message}");
        }
    }
}