using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates setting SubsequentLinesIndent for text fragments using Aspose.Pdf.
/// </summary>
public class AddSubsequentLinesIndent
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory and ensure it exists.
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string outputPath = Path.Combine(outputDir, "SubsequentIndent_out.pdf");

            // Create new document.
            Document document = new Document();
            Page page = document.Pages.Add();

            TextFragment text = new TextFragment(
                "A quick brown fox jumped over the lazy dog. A quick brown fox jumped over the lazy dog. " +
                "A quick brown fox jumped over the lazy dog. A quick brown fox jumped over the lazy dog. " +
                "A quick brown fox jumped over the lazy dog. A quick brown fox jumped over the lazy dog. " +
                "A quick brown fox jumped over the lazy dog. A quick brown fox jumped over the lazy dog.");

            // Initialize TextFormattingOptions for the text fragment and specify SubsequentLinesIndent value.
            text.TextState.FormattingOptions = new TextFormattingOptions
            {
                SubsequentLinesIndent = 20
            };

            page.Paragraphs.Add(text);

            text = new TextFragment("Line2");
            page.Paragraphs.Add(text);

            text = new TextFragment("Line3");
            page.Paragraphs.Add(text);

            text = new TextFragment("Line4");
            page.Paragraphs.Add(text);

            text = new TextFragment("Line5");
            page.Paragraphs.Add(text);

            document.Save(outputPath, SaveFormat.Pdf);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddSubsequentLinesIndent.Run: {ex.Message}");
        }
    }
}