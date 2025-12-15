using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Links_Actions;

/// <summary>
/// Demonstrates creating an application link in a PDF using Aspose.Pdf.Facades.
/// </summary>
public class CreateAppLink
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
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPdfPath = Path.Combine(inputDir, "CreateApplicationLink.pdf");
            string linkTargetPath = Path.Combine(inputDir, "test.txt");
            string outputPdfPath = Path.Combine(outputDir, "CreateApplicationLink_out.pdf");

            // Open the PDF document.
            PdfContentEditor contentEditor = new PdfContentEditor();
            contentEditor.BindPdf(inputPdfPath);

            // Define the rectangle area for the link.
            // System.Drawing.Rectangle is platform‑specific; ensure the runtime supports it.
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(100, 100, 200, 200);

            // Create the application link.
            contentEditor.CreateApplicationLink(rectangle, linkTargetPath, 1);

            // Save the updated PDF.
            contentEditor.Save(outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing CreateAppLink example: {ex.Message}");
        }
    }
}