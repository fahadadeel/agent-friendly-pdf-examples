using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates adding a border around a text fragment in a PDF document using Aspose.Pdf.
/// </summary>
public class AddTextBorder
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory relative to the application base directory.
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Create a new PDF document.
            Document pdfDocument = new Document();

            // Add a page to the document.
            Page pdfPage = pdfDocument.Pages.Add();

            // Create a text fragment.
            TextFragment textFragment = new TextFragment("main text")
            {
                Position = new Position(100, 600)
            };

            // Set text properties.
            textFragment.TextState.FontSize = 12;
            textFragment.TextState.Font = FontRepository.FindFont("TimesNewRoman");
            textFragment.TextState.BackgroundColor = Aspose.Pdf.Color.LightGray;
            textFragment.TextState.ForegroundColor = Aspose.Pdf.Color.Red;

            // Set StrokingColor property for drawing border (stroking) around text rectangle.
            textFragment.TextState.StrokingColor = Aspose.Pdf.Color.DarkRed;

            // Enable drawing of the text rectangle border.
            textFragment.TextState.DrawTextRectangleBorder = true;

            // Append the text fragment to the page.
            TextBuilder tb = new TextBuilder(pdfPage);
            tb.AppendText(textFragment);

            // Save the document.
            string outputPath = Path.Combine(outputDir, "PDFWithTextBorder_out.pdf");
            pdfDocument.Save(outputPath);

            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF creation: {ex.Message}");
        }
    }
}