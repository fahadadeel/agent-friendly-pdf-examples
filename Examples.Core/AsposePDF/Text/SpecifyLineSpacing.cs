using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates how to specify line spacing for text added to a PDF document using Aspose.Pdf.
/// </summary>
public class SpecifyLineSpacing
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Path to the TrueType font file.
            string fontFile = Path.Combine(inputDir, "HPSimplified.TTF");

            // Create a new PDF document.
            var doc = new Document();

            // Configure line spacing to use full size.
            var formattingOptions = new TextFormattingOptions();
            formattingOptions.LineSpacing = TextFormattingOptions.LineSpacingMode.FullSize;

            // Create a text fragment with the desired content.
            var textFragment = new TextFragment("Hello world");

            if (!string.IsNullOrEmpty(fontFile) && File.Exists(fontFile))
            {
                // Load the TrueType font from the file stream.
                using var fontStream = File.OpenRead(fontFile);
                textFragment.TextState.Font = FontRepository.OpenFont(fontStream, FontTypes.TTF);

                // Set the position of the text fragment on the page.
                textFragment.Position = new Position(100, 600);

                // Apply the line‑spacing formatting options.
                textFragment.TextState.FormattingOptions = formattingOptions;

                // Add a new page and place the text fragment on it.
                var page = doc.Pages.Add();
                page.Paragraphs.Add(textFragment);
            }
            else
            {
                Console.WriteLine($"Font file not found: {fontFile}");
            }

            // Save the resulting PDF document to the output directory.
            string outputPath = Path.Combine(outputDir, "SpecifyLineSpacing_out.pdf");
            doc.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in SpecifyLineSpacing.Run: {ex.Message}");
        }
    }
}