using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using System;
using System.IO;

namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

/// <summary>
/// Demonstrates adding structure elements into a tagged PDF document and validating PDF/UA compliance.
/// </summary>
public class AddStructureElementIntoElement
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // ExStart:AddStructureElementIntoElement
        try
        {
            // Resolve output directory relative to the application base directory.
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string outFile = Path.Combine(outputDir, "AddStructureElementIntoElement_Output.pdf");
            string logFile = Path.Combine(outputDir, "46144_log.xml");

            // Create a new PDF document and obtain its tagged content.
            Document document = new Document();
            ITaggedContent taggedContent = document.TaggedContent;

            // Set title and language for the document.
            taggedContent.SetTitle("Text Elements Example");
            taggedContent.SetLanguage("en-US");

            // Get the root structure element (document structure element).
            StructureElement rootElement = taggedContent.RootElement;

            // Paragraph 1
            ParagraphElement p1 = taggedContent.CreateParagraphElement();
            rootElement.AppendChild(p1);
            SpanElement span11 = taggedContent.CreateSpanElement();
            span11.SetText("Span_11");
            SpanElement span12 = taggedContent.CreateSpanElement();
            span12.SetText(" and Span_12.");
            p1.SetText("Paragraph with ");
            p1.AppendChild(span11);
            p1.AppendChild(span12);

            // Paragraph 2
            ParagraphElement p2 = taggedContent.CreateParagraphElement();
            rootElement.AppendChild(p2);
            SpanElement span21 = taggedContent.CreateSpanElement();
            span21.SetText("Span_21");
            SpanElement span22 = taggedContent.CreateSpanElement();
            span22.SetText("Span_22.");
            p2.AppendChild(span21);
            p2.SetText(" and ");
            p2.AppendChild(span22);

            // Paragraph 3
            ParagraphElement p3 = taggedContent.CreateParagraphElement();
            rootElement.AppendChild(p3);
            SpanElement span31 = taggedContent.CreateSpanElement();
            span31.SetText("Span_31");
            SpanElement span32 = taggedContent.CreateSpanElement();
            span32.SetText(" and Span_32");
            p3.AppendChild(span31);
            p3.AppendChild(span32);
            p3.SetText(".");

            // Paragraph 4
            ParagraphElement p4 = taggedContent.CreateParagraphElement();
            rootElement.AppendChild(p4);
            SpanElement span41 = taggedContent.CreateSpanElement();
            SpanElement span411 = taggedContent.CreateSpanElement();
            span411.SetText("Span_411, ");
            span41.SetText("Span_41, ");
            span41.AppendChild(span411);
            SpanElement span42 = taggedContent.CreateSpanElement();
            SpanElement span421 = taggedContent.CreateSpanElement();
            span421.SetText("Span 421 and ");
            span42.AppendChild(span421);
            span42.SetText("Span_42");
            p4.AppendChild(span41);
            p4.AppendChild(span42);
            p4.SetText(".");

            // Save the tagged PDF document.
            document.Save(outFile);

            // Re-open the document to validate PDF/UA compliance.
            document = new Document(outFile);
            bool isPdfUaCompliance = document.Validate(logFile, PdfFormat.PDF_UA_1);
            Console.WriteLine(string.Format("PDF/UA compliance: {0}", isPdfUaCompliance));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
        // ExEnd:AddStructureElementIntoElement
    }
}