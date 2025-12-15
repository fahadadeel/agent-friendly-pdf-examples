using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Links_Actions;

/// <summary>
/// Demonstrates how to create a JavaScript link in a PDF using Aspose.Pdf.Facades.
/// </summary>
public class CreateJSLink
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory ?? Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "CreateApplicationLink.pdf");
            string outputPath = Path.Combine(outputDir, "CreateJSLink_out.pdf");

            // Verify input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open document.
            PdfContentEditor contentEditor = new PdfContentEditor();
            contentEditor.BindPdf(inputPath);

            // Define the rectangle area for the link.
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(100, 100, 200, 200);

            // Create JavaScript link.
            contentEditor.CreateJavaScriptLink(
                "app.alert('Welcome to Aspose!');",
                rectangle,
                1,
                System.Drawing.Color.Red);

            // Save updated PDF.
            contentEditor.Save(outputPath);

            Console.WriteLine($"PDF saved successfully to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}