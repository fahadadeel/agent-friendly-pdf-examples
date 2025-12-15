using System;
using System.IO;
using Aspose.Pdf.Facades;
using Aspose.Pdf; // AUTOFIX

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

/// <summary>
/// Demonstrates how to change the page size of a PDF using Aspose.Pdf.Facades.
/// </summary>
public class ChangePageSizes
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

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "FilledForm.pdf");
            string outputPath = Path.Combine(outputDir, "ChangePageSizes_out.pdf");

            // Create PdfPageEditor object.
            PdfPageEditor pEdit = new PdfPageEditor();

            // Bind the PDF file.
            pEdit.BindPdf(inputPath);

            // Change page size of the selected pages (page numbers are 1‑based).
            pEdit.ProcessPages = new int[] { 1 };

            // Set the desired page size.
            pEdit.PageSize = PageSize.PageLetter;

            // Save the modified PDF.
            pEdit.Save(outputPath);

            // Verify the size of the first page.
            pEdit.BindPdf(inputPath);
            PageSize size = pEdit.GetPageSize(1);
            Console.WriteLine($"Page 1 size after modification: {size}");

            // Clean up.
            pEdit = null;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ChangePageSizes.Run: {ex.Message}");
        }
    }
}