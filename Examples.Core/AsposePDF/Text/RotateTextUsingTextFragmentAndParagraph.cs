using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates rotating text using <see cref="TextFragment"/> and adding them to a PDF page.
/// </summary>
public class RotateTextUsingTextFragmentAndParagraph
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory (data/outputs relative to the application base directory)
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Initialize a new PDF document
            Document pdfDocument = new Document();

            // Add a new page to the document
            Page pdfPage = (Page)pdfDocument.Pages.Add();

            // Create the first text fragment (no rotation)
            TextFragment textFragment1 = new TextFragment("main text");
            textFragment1.TextState.FontSize = 12;
            textFragment1.TextState.Font = FontRepository.FindFont("TimesNewRoman");

            // Create the second text fragment (rotated 315 degrees)
            TextFragment textFragment2 = new TextFragment("rotated text");
            textFragment2.TextState.FontSize = 12;
            textFragment2.TextState.Font = FontRepository.FindFont("TimesNewRoman");
            textFragment2.TextState.Rotation = 315;

            // Create the third text fragment (rotated 270 degrees)
            TextFragment textFragment3 = new TextFragment("rotated text");
            textFragment3.TextState.FontSize = 12;
            textFragment3.TextState.Font = FontRepository.FindFont("TimesNewRoman");
            textFragment3.TextState.Rotation = 270;

            // Add the fragments to the page's paragraph collection
            pdfPage.Paragraphs.Add(textFragment1);
            pdfPage.Paragraphs.Add(textFragment2);
            pdfPage.Paragraphs.Add(textFragment3);

            // Save the document to the output directory
            string outputPath = Path.Combine(outputDir, "TextFragmentTests_Rotated3_out.pdf");
            pdfDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in RotateTextUsingTextFragmentAndParagraph.Run: {ex.Message}");
        }
    }
}