using System;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Demonstrates extracting a particular page from a PDF and saving it as a new document.
/// </summary>
namespace Examples.Core.AsposePDF.Pages;

public class GetParticularPage
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Input and output file paths.
        string inputPath = Path.Combine(inputDir, "GetParticularPage.pdf");
        string outputPath = Path.Combine(outputDir, "GetParticularPage_out.pdf");

        try
        {
            // Open the source PDF document.
            Document pdfDocument = new Document(inputPath);

            // Get the particular page (page numbers are 1‑based; we want page 2).
            Page pdfPage = pdfDocument.Pages[2];

            // Create a new document and add the extracted page.
            Document newDocument = new Document();
            newDocument.Pages.Add(pdfPage);

            // Save the new document.
            newDocument.Save(outputPath);

            Console.WriteLine("\nParticular page accessed successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error processing PDF: {ex.Message}");
        }
    }
}