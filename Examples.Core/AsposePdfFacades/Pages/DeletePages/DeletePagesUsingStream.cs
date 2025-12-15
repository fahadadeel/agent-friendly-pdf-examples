using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.DeletePages;

/// <summary>
/// Demonstrates deleting specific pages from a PDF using streams.
/// </summary>
public class DeletePagesUsingStream
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // ExStart:DeletePagesUsingStream
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "DeletePagesUsingStream_out.pdf");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Define pages to delete (1‑based indexing).
            int[] pagesToDelete = new int[] { 1, 3 };

            // Perform deletion using streams.
            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                pdfEditor.Delete(inputStream, pagesToDelete, outputStream);
            }

            Console.WriteLine($"Pages deleted successfully. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during DeletePagesUsingStream example: {ex.Message}");
        }
        // ExEnd:DeletePagesUsingStream
    }
}