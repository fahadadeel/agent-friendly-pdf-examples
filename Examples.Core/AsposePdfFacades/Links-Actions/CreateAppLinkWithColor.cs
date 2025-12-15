using System;
using System.IO;
using Aspose.Pdf.Facades;
using System.Drawing;

namespace Examples.Core.AsposePdfFacades.Links_Actions;

/// <summary>
/// Demonstrates creating an application link with a specified color using Aspose.Pdf.Facades.
/// </summary>
public class CreateAppLinkWithColor
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Define file paths.
        string inputPdf = Path.Combine(inputDir, "CreateApplicationLink.pdf");
        string linkedFile = Path.Combine(inputDir, "test.txt");
        string outputPdf = Path.Combine(outputDir, "CreateAppLinkWithColor_out.pdf");

        try
        {
            // Open the PDF document.
            var contentEditor = new PdfContentEditor();
            contentEditor.BindPdf(inputPdf);

            // Define the rectangle area for the link.
            var rectangle = new Rectangle(100, 100, 200, 200);

            // Create an application link with red color.
            contentEditor.CreateApplicationLink(rectangle, linkedFile, 1, Color.Red);

            // Save the updated PDF.
            contentEditor.Save(outputPdf);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing CreateAppLinkWithColor: {ex.Message}");
        }
    }
}