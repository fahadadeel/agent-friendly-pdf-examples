using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.InsertPages;

public class InsertPagesUsingStreams
{
    /// <summary>
    /// Demonstrates inserting pages into a PDF document using streams.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string sourcePdfPath = Path.Combine(inputDir, "MultiplePages.pdf");
            string insertPdfPath = Path.Combine(inputDir, "InsertPages.pdf");
            string outputPdfPath = Path.Combine(outputDir, "InsertPagesUsingStreams_out.pdf");

            // Create PdfFileEditor object.
            var pdfEditor = new PdfFileEditor();

            // Pages to insert (1‑based page numbers from the insert document).
            int[] pagesToInsert = new int[] { 2, 3 };

            // Use streams as required by the legacy example.
            using var inputStream = new FileStream(sourcePdfPath, FileMode.Open, FileAccess.Read);
            using var insertStream = new FileStream(insertPdfPath, FileMode.Open, FileAccess.Read);
            using var outputStream = new FileStream(outputPdfPath, FileMode.Create, FileAccess.Write);

            // Insert pages from insertStream into inputStream at position 1.
            pdfEditor.Insert(inputStream, 1, insertStream, pagesToInsert, outputStream);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during InsertPagesUsingStreams example: {ex.Message}");
        }
    }
}