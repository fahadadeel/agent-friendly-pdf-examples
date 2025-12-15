using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates extracting and toggling multicolumn paragraph settings using Aspose.Pdf.
/// </summary>
public class MulticolumnParagraphs
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

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Path to the source PDF file.
            string inputPath = Path.Combine(inputDir, "MultiColumnPdf.pdf");

            // Load the document.
            Document doc = new Document(inputPath);

            // Absorb paragraphs from the document.
            ParagraphAbsorber absorber = new ParagraphAbsorber();
            absorber.Visit(doc);

            // Get markup information for the first page.
            PageMarkup markup = absorber.PageMarkups[0];

            Console.WriteLine("IsMulticolumnParagraphsAllowed == false\r\n");

            // Access specific sections and paragraphs before enabling multicolumn.
            MarkupSection section = markup.Sections[2];
            MarkupParagraph paragraph = section.Paragraphs[section.Paragraphs.Count - 1];

            Console.WriteLine($"Section at {section.Rectangle} last paragraph text:\r\n");
            Console.WriteLine(paragraph.Text);

            section = markup.Sections[1];
            paragraph = section.Paragraphs[0];

            Console.WriteLine($"\r\nSection at {section.Rectangle} first paragraph text:\r\n");
            Console.WriteLine(paragraph.Text);

            // Enable multicolumn paragraphs.
            markup.IsMulticolumnParagraphsAllowed = true;
            Console.WriteLine("\r\nIsMulticolumnParagraphsAllowed == true\r\n");

            // Access the same sections after enabling multicolumn.
            section = markup.Sections[2];
            paragraph = section.Paragraphs[section.Paragraphs.Count - 1];

            Console.WriteLine($"Section at {section.Rectangle} last paragraph text:\r\n");
            Console.WriteLine(paragraph.Text);

            section = markup.Sections[1];
            paragraph = section.Paragraphs[0];

            Console.WriteLine($"\r\nSection at {section.Rectangle} first paragraph text:\r\n");
            Console.WriteLine(paragraph.Text);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}