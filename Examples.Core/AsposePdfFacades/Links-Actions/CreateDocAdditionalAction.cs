using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Links_Actions;

/// <summary>
/// Demonstrates adding a document‑level additional JavaScript action using Aspose.Pdf.Facades.
/// </summary>
public class CreateDocAdditionalAction
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
            string inputPath = Path.Combine(inputDir, "CreateDocumentLink.pdf");
            string outputPath = Path.Combine(outputDir, "CreateDocAdditionalAction_out.pdf");

            // Open the PDF document.
            var contentEditor = new PdfContentEditor();
            contentEditor.BindPdf(inputPath);

            // (The rectangle is defined in the original example but not used; kept for parity.)
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(100, 100, 200, 200);

            // Add a JavaScript action that runs when the document is closed.
            contentEditor.AddDocumentAdditionalAction(PdfContentEditor.DocumentClose,
                "app.alert('Thank you for using Aspose products!');");

            // Save the updated PDF.
            contentEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing CreateDocAdditionalAction: {ex.Message}");
        }
    }
}