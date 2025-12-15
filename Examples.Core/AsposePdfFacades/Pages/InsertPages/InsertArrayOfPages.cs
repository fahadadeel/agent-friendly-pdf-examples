using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.InsertPages;

/// <summary>
/// Demonstrates inserting an array of pages from one PDF into another using Aspose.Pdf.Facades.
/// </summary>
public class InsertArrayOfPages
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

            // Ensure directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Input file paths.
            string sourcePdfPath = Path.Combine(inputDir, "MultiplePages.pdf");
            string insertPdfPath = Path.Combine(inputDir, "InsertPages.pdf");

            // Output file path.
            string outputPdfPath = Path.Combine(outputDir, "InsertArrayOfPages_out.pdf");

            // Verify that input files exist; if not, inform the user.
            if (!File.Exists(sourcePdfPath) || !File.Exists(insertPdfPath))
            {
                Console.Error.WriteLine("One or more input PDF files are missing:");
                Console.Error.WriteLine($"  Expected: {sourcePdfPath}");
                Console.Error.WriteLine($"  Expected: {insertPdfPath}");
                return;
            }

            // Create PdfFileEditor object.
            var pdfEditor = new PdfFileEditor();

            // Pages to insert (1‑based page numbers).
            int[] pagesToInsert = new int[] { 2, 3 };

            // Insert pages.
            // Parameters: sourcePdf, insertAfterPage, insertPdf, pagesArray, outputPdf
            pdfEditor.Insert(sourcePdfPath, 1, insertPdfPath, pagesToInsert, outputPdfPath);

            Console.WriteLine($"Pages inserted successfully. Output saved to: {outputPdfPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during InsertArrayOfPages example: {ex.Message}");
        }
    }
}