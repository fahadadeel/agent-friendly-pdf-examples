using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.DeletePages;

/// <summary>
/// Demonstrates deleting specific pages from a PDF using file paths.
/// </summary>
public class DeletePagesUsingFilePath
{
    /// <summary>
    /// Executes the example.
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

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "DeletePagesUsingFilePath_out.pdf");

            // Verify input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Array of pages to delete (1‑based indexing).
            int[] pagesToDelete = new int[] { 1, 2 };

            // Delete pages.
            pdfEditor.Delete(inputPath, pagesToDelete, outputPath);

            Console.WriteLine($"Pages deleted successfully. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while deleting pages: {ex.Message}");
        }
    }
}