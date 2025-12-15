using System;
using System.IO;
using System.Text;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates how to extract paragraphs from a PDF document using Aspose.Pdf.
/// </summary>
public class ExtractParagraphs
{
    /// <summary>
    /// Runs the paragraph extraction example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve the input PDF path (data/inputs/input.pdf relative to the application base directory)
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open the existing PDF document
            Document doc = new Document(inputPath);

            // Instantiate ParagraphAbsorber and process the document
            ParagraphAbsorber absorber = new ParagraphAbsorber();
            absorber.Visit(doc);

            // Iterate through the extracted page markups
            foreach (PageMarkup markup in absorber.PageMarkups)
            {
                int i = 1; // Section counter
                foreach (MarkupSection section in markup.Sections)
                {
                    int j = 1; // Paragraph counter

                    foreach (MarkupParagraph paragraph in section.Paragraphs)
                    {
                        StringBuilder paragraphText = new StringBuilder();

                        // Build paragraph text from lines and fragments
                        foreach (var line in paragraph.Lines)
                        {
                            foreach (TextFragment fragment in line)
                            {
                                paragraphText.Append(fragment.Text);
                            }
                            paragraphText.Append("\r\n");
                        }
                        paragraphText.Append("\r\n");

                        Console.WriteLine($"Paragraph {j} of section {i} on page {markup.Number}:");
                        Console.WriteLine(paragraphText.ToString());

                        j++;
                    }

                    i++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while extracting paragraphs: {ex.Message}");
        }
    }
}