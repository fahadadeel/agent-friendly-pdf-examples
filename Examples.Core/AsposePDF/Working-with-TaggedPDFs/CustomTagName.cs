using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/// <summary>
/// Demonstrates creating a tagged PDF with custom tag names using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

public class CustomTagName
{
    /// <summary>
    /// Runs the example. Creates a tagged PDF document with custom tags and saves it to the output directory.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine output directory and ensure it exists.
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "CustomTag.pdf");

            // Create a new PDF document.
            Document document = new Document();

            // Get Tagged content interface.
            ITaggedContent taggedContent = document.TaggedContent;

            // Set title and language for the document.
            taggedContent.SetTitle("Tagged Pdf Document");
            taggedContent.SetLanguage("en-US");

            // Create a section element and add it to the root.
            SectElement sect = taggedContent.CreateSectElement();
            taggedContent.RootElement.AppendChild(sect);

            // Create paragraph elements.
            ParagraphElement p1 = taggedContent.CreateParagraphElement();
            ParagraphElement p2 = taggedContent.CreateParagraphElement();
            ParagraphElement p3 = taggedContent.CreateParagraphElement();
            ParagraphElement p4 = taggedContent.CreateParagraphElement();

            p1.SetText("P1. ");
            p2.SetText("P2. ");
            p3.SetText("P3. ");
            p4.SetText("P4. ");

            p1.SetTag("P1");
            p2.SetTag("Para");
            p3.SetTag("Para");
            p4.SetTag("Paragraph");

            sect.AppendChild(p1);
            sect.AppendChild(p2);
            sect.AppendChild(p3);
            sect.AppendChild(p4);

            // Create span elements.
            SpanElement span1 = taggedContent.CreateSpanElement();
            SpanElement span2 = taggedContent.CreateSpanElement();
            SpanElement span3 = taggedContent.CreateSpanElement();
            SpanElement span4 = taggedContent.CreateSpanElement();

            span1.SetText("Span 1.");
            span2.SetText("Span 2.");
            span3.SetText("Span 3.");
            span4.SetText("Span 4.");

            span1.SetTag("SPAN");
            span2.SetTag("Sp");
            span3.SetTag("Sp");
            span4.SetTag("TheSpan");

            p1.AppendChild(span1);
            p2.AppendChild(span2);
            p3.AppendChild(span3);
            p4.AppendChild(span4);

            // Save the tagged PDF document.
            document.Save(outputPath);
            Console.WriteLine($"Tagged PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing CustomTagName example: {ex.Message}");
        }
    }
}