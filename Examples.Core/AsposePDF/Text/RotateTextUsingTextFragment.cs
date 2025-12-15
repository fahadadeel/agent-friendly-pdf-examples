using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates rotating text fragments using Aspose.Pdf.
/// </summary>
public class RotateTextUsingTextFragment
{
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

            // Add a page.
            Page pdfPage = (Page)pdfDocument.Pages.Add();

            // Create first text fragment (no rotation).
            TextFragment textFragment1 = new TextFragment("main text");
            textFragment1.Position = new Position(100, 600);
            textFragment1.TextState.FontSize = 12;
            textFragment1.TextState.Font = FontRepository.FindFont("TimesNewRoman");

            // Create second text fragment (45° rotation).
            TextFragment textFragment2 = new TextFragment("rotated text");
            textFragment2.Position = new Position(200, 600);
            textFragment2.TextState.FontSize = 12;
            textFragment2.TextState.Font = FontRepository.FindFont("TimesNewRoman");
            textFragment2.TextState.Rotation = 45;

            // Create third text fragment (90° rotation).
            TextFragment textFragment3 = new TextFragment("rotated text");
            textFragment3.Position = new Position(300, 600);
            textFragment3.TextState.FontSize = 12;
            textFragment3.TextState.Font = FontRepository.FindFont("TimesNewRoman");
            textFragment3.TextState.Rotation = 90;

            // Append fragments to the page.
            TextBuilder textBuilder = new TextBuilder(pdfPage);
            textBuilder.AppendText(textFragment1);
            textBuilder.AppendText(textFragment2);
            textBuilder.AppendText(textFragment3);

            // Save the document.
            string outputPath = Path.Combine(outputDir, "TextFragmentTests_Rotated1_out.pdf");
            pdfDocument.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during RotateTextUsingTextFragment execution: {ex.Message}");
        }
    }
}