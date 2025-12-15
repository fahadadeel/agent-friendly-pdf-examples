using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Annotations;

public class StrikeOutWords
{
    /// <summary>
    /// Strikes out all occurrences of the word "Estoque" in the input PDF and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "StrikeOutWords_out.pdf");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Open the PDF document.
            Document document = new Document(inputPath);

            // Create a TextFragmentAbsorber to find the word "Estoque".
            TextFragmentAbsorber absorber = new TextFragmentAbsorber("Estoque");

            // Search each page for the text fragment.
            for (int i = 1; i <= document.Pages.Count; i++)
            {
                Page page = document.Pages[i];
                page.Accept(absorber);
            }

            // Get the collection of found text fragments.
            TextFragmentCollection fragments = absorber.TextFragments;

            // Iterate over each fragment and add a strike‑out annotation.
            for (int j = 1; j <= fragments.Count; j++)
            {
                TextFragment fragment = fragments[j];

                // Determine the rectangle that bounds the text fragment.
                Rectangle rect = new Rectangle(
                    (float)fragment.Position.XIndent,
                    (float)fragment.Position.YIndent,
                    (float)fragment.Position.XIndent + (float)fragment.Rectangle.Width,
                    (float)fragment.Position.YIndent + (float)fragment.Rectangle.Height);

                // Create the strike‑out annotation.
                StrikeOutAnnotation strikeOut = new StrikeOutAnnotation(fragment.Page, rect);
                strikeOut.Opacity = 0.80f;
                strikeOut.Border = new Border(strikeOut);
                strikeOut.Color = Color.Red;

                // Add the annotation to the page.
                fragment.Page.Annotations.Add(strikeOut);
            }

            // Save the modified document.
            document.Save(outputPath);

            Console.WriteLine($"\nWords strikeout successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during StrikeOutWords execution: {ex.Message}");
        }
    }
}