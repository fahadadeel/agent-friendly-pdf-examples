using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Text;

/// <summary>
/// Demonstrates replacing text on a PDF page using Aspose.Pdf.Facades.
/// </summary>
public class ReplaceTextPage
{
    /// <summary>
    /// Executes the replace‑text example.
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
            string inputPath = Path.Combine(inputDir, "ReplaceText-Page.pdf");
            string outputPath = Path.Combine(outputDir, "ReplaceTextPage_out.pdf");

            // Open input PDF.
            var pdfContentEditor = new PdfContentEditor();
            pdfContentEditor.BindPdf(inputPath);

            // Replace text on all pages.
            pdfContentEditor.ReplaceText("Hello", 1, "World");

            // Save output PDF.
            pdfContentEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ReplaceTextPage.Run: {ex.Message}");
        }
    }
}