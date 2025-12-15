using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates rotating text fragments within a paragraph using Aspose.Pdf.
/// </summary>
public class RotateTextUsingParagraph
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Initialize a new PDF document.
            Document pdfDocument = new Document();

            // Add a new page to the document.
            Page pdfPage = (Page)pdfDocument.Pages.Add();

            // Create a text paragraph and set its position.
            TextParagraph paragraph = new TextParagraph
            {
                Position = new Position(200, 600)
            };

            // First rotated text fragment.
            TextFragment textFragment1 = new TextFragment("rotated text");
            textFragment1.TextState.FontSize = 12;
            textFragment1.TextState.Font = FontRepository.FindFont("TimesNewRoman");
            textFragment1.TextState.Rotation = 45;

            // Main (non‑rotated) text fragment.
            TextFragment textFragment2 = new TextFragment("main text");
            textFragment2.TextState.FontSize = 12;
            textFragment2.TextState.Font = FontRepository.FindFont("TimesNewRoman");

            // Second rotated text fragment.
            TextFragment textFragment3 = new TextFragment("another rotated text");
            textFragment3.TextState.FontSize = 12;
            textFragment3.TextState.Font = FontRepository.FindFont("TimesNewRoman");
            textFragment3.TextState.Rotation = -45;

            // Append fragments to the paragraph.
            paragraph.AppendLine(textFragment1);
            paragraph.AppendLine(textFragment2);
            paragraph.AppendLine(textFragment3);

            // Use TextBuilder to add the paragraph to the page.
            TextBuilder textBuilder = new TextBuilder(pdfPage);
            textBuilder.AppendParagraph(paragraph);

            // Save the document to the output directory.
            string outputPath = Path.Combine(outputDir, "TextFragmentTests_Rotated2_out.pdf");
            pdfDocument.Save(outputPath);

            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while running RotateTextUsingParagraph: {ex.Message}");
        }
    }
}