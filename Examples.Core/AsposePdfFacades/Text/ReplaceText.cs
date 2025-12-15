using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Text;

/// <summary>
/// Demonstrates how to replace text in a PDF using Aspose.Pdf.Facades.
/// </summary>
public class ReplaceText
{
    /// <summary>
    /// Executes the replace‑text example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Define full paths for the source PDF and the resulting PDF.
            string inputPath = Path.Combine(inputDir, "ReplaceText.pdf");
            string outputPath = Path.Combine(outputDir, "ReplaceText_out.pdf");

            // Open input PDF.
            var pdfContentEditor = new PdfContentEditor();
            pdfContentEditor.BindPdf(inputPath);

            // Replace text on all pages.
            pdfContentEditor.ReplaceText("Hello", "World");

            // Save the modified PDF.
            pdfContentEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ReplaceText.Run: {ex.Message}");
        }
    }
}