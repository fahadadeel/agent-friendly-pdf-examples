using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.InsertPages;

/// <summary>
/// Demonstrates inserting a range of pages from one PDF into another using Aspose.Pdf.Facades.
/// </summary>
public class InsertPagesBetweenNumbers
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

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Define file paths.
            string sourcePdfPath = Path.Combine(inputDir, "MultiplePages.pdf");
            string insertPdfPath = Path.Combine(inputDir, "InsertPages.pdf");
            string outputPdfPath = Path.Combine(outputDir, "InsertPagesBetweenNumbers_out.pdf");

            // Validate input files exist.
            if (!File.Exists(sourcePdfPath))
                throw new FileNotFoundException($"Source PDF not found: {sourcePdfPath}");
            if (!File.Exists(insertPdfPath))
                throw new FileNotFoundException($"Insert PDF not found: {insertPdfPath}");

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Insert pages from insertPdfPath (pages 2 to 5) into sourcePdfPath after page 1,
            // and save the result to outputPdfPath.
            pdfEditor.Insert(sourcePdfPath, 1, insertPdfPath, 2, 5, outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while inserting pages: {ex.Message}");
        }
    }
}