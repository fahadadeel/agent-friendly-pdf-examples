using System;
using System.IO;
using System.Drawing;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Links_Actions;

/// <summary>
/// Demonstrates removal of the document open action from a PDF using Aspose.Pdf.Facades.
/// </summary>
public class RemoveAction
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

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "RemoveOpenAction.pdf");
            string outputPath = Path.Combine(outputDir, "RemoveOpenAction_out.pdf");

            // Open document.
            var contentEditor = new PdfContentEditor();
            contentEditor.BindPdf(inputPath);

            // Example rectangle (not used further, kept for parity with legacy code).
            var rectangle = new Rectangle(100, 100, 200, 200);

            // Remove the document open action.
            contentEditor.RemoveDocumentOpenAction();

            // Save updated PDF.
            contentEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in {nameof(RemoveAction)}.{nameof(Run)}: {ex.Message}");
        }
    }
}