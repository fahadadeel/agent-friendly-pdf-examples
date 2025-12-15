using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Links_Actions;

public class CreateLocalLink
{
    /// <summary>
    /// Demonstrates creating a local link in a PDF using Aspose.Pdf.Facades.
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
            string inputPath = Path.Combine(inputDir, "CreateApplicationLink.pdf");
            string outputPath = Path.Combine(outputDir, "CreateLocalLink_out.pdf");

            // Open document
            var contentEditor = new PdfContentEditor();
            contentEditor.BindPdf(inputPath);

            // Define rectangle for the link.
            var rectangle = new System.Drawing.Rectangle(100, 100, 200, 200);

            // Create local link (page number 3, zoom 1, red color).
            contentEditor.CreateLocalLink(rectangle, 3, 1, System.Drawing.Color.Red);

            // Save updated PDF
            contentEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in CreateLocalLink.Run: {ex.Message}");
        }
    }
}