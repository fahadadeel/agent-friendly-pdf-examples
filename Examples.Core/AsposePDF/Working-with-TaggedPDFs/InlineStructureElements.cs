using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;

namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

/// <summary>
/// Demonstrates creation of a tagged PDF with inline structure elements using Aspose.Pdf.
/// </summary>
public class InlineStructureElements
{
    /// <summary>
    /// Executes the example. Generates a tagged PDF containing headers, paragraphs and spans,
    /// and saves it to the <c>data/outputs</c> directory relative to the application base path.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory and ensure it exists
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Output file path
            string outputPath = Path.Combine(outputDir, "InlineStructureElements.pdf");

            // Create a new PDF document
            Document document = new Document();

            // Get Tagged PDF content interface
            ITaggedContent taggedContent = document.TaggedContent;

            // Set document title and language
            taggedContent.SetTitle("Tagged Pdf Document");
            taggedContent.SetLanguage("en-US");

            // Get the root structure element
            StructureElement rootElement = taggedContent.RootElement;

            // Create header elements (H1–H6) and add them to the root
            HeaderElement h1 = taggedContent.CreateHeaderElement(1);
            HeaderElement h2 = taggedContent.CreateHeaderElement(2);
            HeaderElement h3 = taggedContent.CreateHeaderElement(3);
            HeaderElement h4 = taggedContent.CreateHeaderElement(4);
            HeaderElement h5 = taggedContent.CreateHeaderElement(5);
            HeaderElement h6 = taggedContent.CreateHeaderElement(6);

            rootElement.AppendChild(h1);
            rootElement.AppendChild(h2);
            rootElement.AppendChild(h3);
            rootElement.AppendChild(h4);
            rootElement.AppendChild(h5);
            rootElement.AppendChild(h6);

            // Populate each header with its label and text
            SpanElement spanH11 = taggedContent.CreateSpanElement();
            spanH11.SetText("H1. ");
            h1.AppendChild(spanH11);
            SpanElement spanH12 = taggedContent.CreateSpanElement();
            spanH12.SetText("Level 1 Header");
            h1.AppendChild(spanH12);

            SpanElement spanH21 = taggedContent.CreateSpanElement();
            spanH21.SetText("H2. ");
            h2.AppendChild(spanH21);
            SpanElement spanH22 = taggedContent.CreateSpanElement();
            spanH22.SetText("Level 2 Header");
            h2.AppendChild(spanH22);

            SpanElement spanH31 = taggedContent.CreateSpanElement();
            spanH31.SetText("H3. ");
            h3.AppendChild(spanH31);
            SpanElement spanH32 = taggedContent.CreateSpanElement();
            spanH32.SetText("Level 3 Header");
            h3.AppendChild(spanH32);

            SpanElement spanH41 = taggedContent.CreateSpanElement();
            spanH41.SetText("H4. ");
            h4.AppendChild(spanH41);
            SpanElement spanH42 = taggedContent.CreateSpanElement();
            spanH42.SetText("Level 4 Header");
            h4.AppendChild(spanH42);

            SpanElement spanH51 = taggedContent.CreateSpanElement();
            spanH51.SetText("H5. ");
            h5.AppendChild(spanH51);
            SpanElement spanH52 = taggedContent.CreateSpanElement();
            spanH52.SetText("Level 5 Header");
            h5.AppendChild(spanH52);

            SpanElement spanH61 = taggedContent.CreateSpanElement();
            spanH61.SetText("H6. ");
            h6.AppendChild(spanH61);
            SpanElement spanH62 = taggedContent.CreateSpanElement();
            spanH62.SetText("Level 6 Header");
            h6.AppendChild(spanH62);

            // Create a paragraph element with multiple spans
            ParagraphElement p = taggedContent.CreateParagraphElement();
            p.SetText("P. ");
            rootElement.AppendChild(p);

            void AddSpan(string text)
            {
                SpanElement span = taggedContent.CreateSpanElement();
                span.SetText(text);
                p.AppendChild(span);
            }

            AddSpan("Lorem ipsum dolor sit amet, consectetur adipiscing elit. ");
            AddSpan("Aenean nec lectus ac sem faucibus imperdiet. ");
            AddSpan("Sed ut erat ac magna ullamcorper hendrerit. ");
            AddSpan("Cras pellentesque libero semper, gravida magna sed, luctus leo. ");
            AddSpan("Fusce lectus odio, laoreet nec ullamcorper ut, molestie eu elit. ");
            AddSpan("Interdum et malesuada fames ac ante ipsum primis in faucibus. ");
            AddSpan("Aliquam lacinia sit amet elit ac consectetur. Donec cursus condimentum ligula, vitae volutpat sem tristique eget. ");
            AddSpan("Nulla in consectetur massa. Vestibulum vitae lobortis ante. Nulla ullamcorper pellentesque justo rhoncus accumsan. ");
            AddSpan("Mauris ornare eu odio non lacinia. Aliquam massa leo, rhoncus ac iaculis eget, tempus et magna. Sed non consectetur elit. ");
            AddSpan("Sed vulputate, quam sed lacinia luctus, ipsum nibh fringilla purus, vitae posuere risus odio id massa. Cras sed venenatis lacus.");

            // Save the tagged PDF document
            document.Save(outputPath);
            Console.WriteLine($"Tagged PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during InlineStructureElements execution: {ex.Message}");
        }
    }
}