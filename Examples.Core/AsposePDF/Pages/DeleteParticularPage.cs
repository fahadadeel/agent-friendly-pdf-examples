using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Pages;

/// <summary>
/// Demonstrates how to delete a particular page from a PDF document using Aspose.Pdf.
/// </summary>
public class DeleteParticularPage
{
    /// <summary>
    /// Deletes page number 2 from the input PDF and saves the result.
    /// </summary>
    public static void Run()
    {
        // ExStart:DeleteParticularPage
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "DeleteParticularPage.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "DeleteParticularPage_out.pdf");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open document
            Document pdfDocument = new Document(inputPath);

            // Delete a particular page (page numbers are 1‑based)
            pdfDocument.Pages.Delete(2);

            // Save updated PDF
            pdfDocument.Save(outputPath);
            Console.WriteLine("\nParticular page deleted successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error deleting page: {ex.Message}");
        }
        // ExEnd:DeleteParticularPage
    }
}