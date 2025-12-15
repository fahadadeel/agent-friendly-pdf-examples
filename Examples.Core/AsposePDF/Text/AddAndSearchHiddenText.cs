using Aspose.Pdf;
using Aspose.Pdf.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates adding hidden (invisible) text to a PDF document and searching for it.
/// </summary>
public class AddAndSearchHiddenText
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
            Directory.CreateDirectory(outputDir);

            // Create a new PDF document with hidden text.
            var doc = new Document();
            var page = doc.Pages.Add();

            var frag1 = new TextFragment("This is common text.");
            var frag2 = new TextFragment("This is invisible text.");
            // Set text property - invisible
            frag2.TextState.Invisible = true;

            page.Paragraphs.Add(frag1);
            page.Paragraphs.Add(frag2);

            string outputPath = Path.Combine(outputDir, "39400_out.pdf");
            doc.Save(outputPath);
            doc.Dispose();

            // Search text in the created document.
            var loadedDoc = new Document(outputPath);
            var absorber = new TextFragmentAbsorber();
            absorber.Visit(loadedDoc.Pages[1]);

            foreach (TextFragment fragment in absorber.TextFragments)
            {
                Console.WriteLine(
                    "Text '{0}' on pos {1} invisibility: {2} ",
                    fragment.Text,
                    fragment.Position.ToString(),
                    fragment.TextState.Invisible);
            }

            loadedDoc.Dispose();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddAndSearchHiddenText.Run: {ex.Message}");
        }
    }
}