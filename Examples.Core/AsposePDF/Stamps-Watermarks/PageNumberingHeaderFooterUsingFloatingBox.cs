using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Stamps_Watermarks;

/// <summary>
/// Demonstrates adding page numbers using a floating box in a newly created PDF document.
/// </summary>
public class PageNumberingHeaderFooterUsingFloatingBox
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory (data/outputs relative to the application base directory)
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Output file path
            string outputPath = Path.Combine(outputDir, "PageNumberinHeaderFooterUsingFloatingBox_out.pdf");

            // Instantiate a new PDF document
            Document pdf = new Document();

            // Add a page to the document
            Page page = pdf.Pages.Add();

            // Initialize a floating box (width: 140, height: 80)
            FloatingBox box1 = new FloatingBox(140, 80)
            {
                Left = 2,
                Top = 10
            };

            // Add a text fragment with page number macros
            box1.Paragraphs.Add(new TextFragment("Page: ($p/ $P )"));

            // Add the floating box to the page
            page.Paragraphs.Add(box1);

            // Save the document
            pdf.Save(outputPath);

            Console.WriteLine($"PDF saved successfully to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing PageNumberingHeaderFooterUsingFloatingBox: {ex.Message}");
        }
    }
}