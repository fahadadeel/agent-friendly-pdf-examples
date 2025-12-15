using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

public class AddTooltipToText
{
    /// <summary>
    /// Demonstrates how to add tooltips to text fragments in a PDF document using Aspose.Pdf.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory relative to the application base directory.
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string outputFile = Path.Combine(outputDir, "Tooltip_out.pdf");

            // Create a sample document with text.
            var doc = new Document();
            doc.Pages.Add().Paragraphs.Add(new TextFragment("Move the mouse cursor here to display a tooltip"));
            doc.Pages[1].Paragraphs.Add(new TextFragment("Move the mouse cursor here to display a very long tooltip"));
            doc.Save(outputFile);

            // Open the document for further processing.
            var document = new Document(outputFile);

            // First tooltip (short).
            var absorber = new TextFragmentAbsorber("Move the mouse cursor here to display a tooltip");
            document.Pages.Accept(absorber);
            TextFragmentCollection textFragments = absorber.TextFragments;

            foreach (TextFragment fragment in textFragments)
            {
                var field = new ButtonField(fragment.Page, fragment.Rectangle)
                {
                    AlternateName = "Tooltip for text."
                };
                document.Form.Add(field);
            }

            // Second tooltip (very long).
            absorber = new TextFragmentAbsorber("Move the mouse cursor here to display a very long tooltip");
            document.Pages.Accept(absorber);
            textFragments = absorber.TextFragments;

            foreach (TextFragment fragment in textFragments)
            {
                var field = new ButtonField(fragment.Page, fragment.Rectangle)
                {
                    AlternateName = "Lorem ipsum dolor sit amet, consectetur adipiscing elit," +
                                    " sed do eiusmod tempor incididunt ut labore et dolore magna" +
                                    " aliqua. Ut enim ad minim veniam, quis nostrud exercitation" +
                                    " ullamco laboris nisi ut aliquip ex ea commodo consequat." +
                                    " Duis aute irure dolor in reprehenderit in voluptate velit" +
                                    " esse cillum dolore eu fugiat nulla pariatur. Excepteur sint" +
                                    " occaecat cupidatat non proident, sunt in culpa qui officia" +
                                    " deserunt mollit anim id est laborum."
                };
                document.Form.Add(field);
            }

            // Save the updated document.
            document.Save(outputFile);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddTooltipToText.Run: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.