using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Annotations;

/// <summary>
/// Demonstrates how to delete all annotations from a specific page of a PDF document
/// and save the result to an output file.
/// </summary>
public class DeleteAllAnnotationsFromPage
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // ExStart:DeleteAllAnnotationsFromPage
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "DeleteAllAnnotationsFromPage.pdf");
            string outputPath = Path.Combine(outputDir, "DeleteAllAnnotationsFromPage_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Delete all annotations from the first page (pages are 1‑based).
            pdfDocument.Pages[1].Annotations.Delete();

            // Save the updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nAll annotations from a page deleted successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while deleting annotations: " + ex.Message);
        }
        // ExEnd:DeleteAllAnnotationsFromPage
    }
}