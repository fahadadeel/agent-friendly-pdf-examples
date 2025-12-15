using System;
using System.IO;
using Aspose.Pdf.Facades;
using System.Drawing;

namespace Examples.Core.AsposePdfFacades.Links_Actions;

/// <summary>
/// Demonstrates creating a document link inside a PDF using Aspose.Pdf.Facades.
/// </summary>
public class CreateDocLink
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
                Directory.CreateDirectory(outputDir);

            // Input PDF files.
            string sourcePdf = Path.Combine(inputDir, "CreateDocumentLink.pdf");
            string targetPdf = Path.Combine(inputDir, "RemoveOpenAction.pdf");

            // Output PDF file.
            string outputPdf = Path.Combine(outputDir, "CreateDocLink_out.pdf");

            // Open document.
            var contentEditor = new PdfContentEditor();
            contentEditor.BindPdf(sourcePdf);

            // Define the rectangle area for the link.
            var rectangle = new Rectangle(100, 100, 200, 200);

            // Create a link to another PDF document.
            // Parameters: rectangle, target file path, page number (1‑based), zoom level (percentage).
            contentEditor.CreatePdfDocumentLink(rectangle, targetPdf, 1, 4);

            // Save the updated PDF.
            contentEditor.Save(outputPdf);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in CreateDocLink.Run: {ex.Message}");
        }
    }
}