using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates rotating text using TextParagraph and TextBuilder.
/// </summary>
public class RotateTextUsingTextParagraphAndBuilder
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine output directory relative to application base.
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Initialize a new PDF document.
            Document pdfDocument = new Document();

            // Add a page to the document.
            Page pdfPage = (Page)pdfDocument.Pages.Add();

            for (int i = 0; i < 4; i++)
            {
                TextParagraph paragraph = new TextParagraph
                {
                    Position = new Position(200, 600),
                    Rotation = i * 90 + 45
                };

                // First line
                TextFragment textFragment1 = new TextFragment("Paragraph Text");
                textFragment1.TextState.FontSize = 12;
                textFragment1.TextState.Font = FontRepository.FindFont("TimesNewRoman");
                textFragment1.TextState.BackgroundColor = Aspose.Pdf.Color.LightGray;
                textFragment1.TextState.ForegroundColor = Aspose.Pdf.Color.Blue;

                // Second line
                TextFragment textFragment2 = new TextFragment("Second line of text");
                textFragment2.TextState.FontSize = 12;
                textFragment2.TextState.Font = FontRepository.FindFont("TimesNewRoman");
                textFragment2.TextState.BackgroundColor = Aspose.Pdf.Color.LightGray;
                textFragment2.TextState.ForegroundColor = Aspose.Pdf.Color.Blue;

                // Third line
                TextFragment textFragment3 = new TextFragment("And some more text...");
                textFragment3.TextState.FontSize = 12;
                textFragment3.TextState.Font = FontRepository.FindFont("TimesNewRoman");
                textFragment3.TextState.BackgroundColor = Aspose.Pdf.Color.LightGray;
                textFragment3.TextState.ForegroundColor = Aspose.Pdf.Color.Blue;
                textFragment3.TextState.Underline = true;

                paragraph.AppendLine(textFragment1);
                paragraph.AppendLine(textFragment2);
                paragraph.AppendLine(textFragment3);

                TextBuilder textBuilder = new TextBuilder(pdfPage);
                textBuilder.AppendParagraph(paragraph);
            }

            string outputPath = Path.Combine(outputDir, "TextFragmentTests_Rotated4_out.pdf");
            pdfDocument.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing RotateTextUsingTextParagraphAndBuilder: {ex.Message}");
        }
    }
}