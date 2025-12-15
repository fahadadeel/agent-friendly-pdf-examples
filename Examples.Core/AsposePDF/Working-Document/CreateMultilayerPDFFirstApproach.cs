// TODO: Original required namespace 'Examples.Core.AsposePDF/Working-Document' contains invalid characters.
// Using a valid C# namespace instead.
namespace Examples.Core.AsposePDF.Working_Document;

using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

/// <summary>
/// Demonstrates creating a multi‑layer PDF using Aspose.Pdf.
/// </summary>
public class CreateMultilayerPDFFirstApproach
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
            Directory.CreateDirectory(outputDir);

            // Create a new PDF document.
            var pdf = new Document();

            // Add a page to the document.
            var sec1 = pdf.Pages.Add();

            // Add a text fragment to the page.
            var t1 = new TextFragment("paragraph 3 segment");
            sec1.Paragraphs.Add(t1);

            // Modify the text fragment.
            t1.Text = "paragraph 3 segment 1";
            t1.TextState.ForegroundColor = Color.Red;
            t1.TextState.FontSize = 12;

            // Add an image to the document.
            var image1 = new Image();
            image1.File = Path.Combine(inputDir, "test_image.png");

            // Create a floating box and place the image inside it.
            var box1 = new FloatingBox(117, 21);
            sec1.Paragraphs.Add(box1);
            box1.Left = -4;
            box1.Top = -4;
            box1.Paragraphs.Add(image1);

            // Save the PDF to the output directory.
            string outputPath = Path.Combine(outputDir, "CreateMultiLayerPdf_out.pdf");
            pdf.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}