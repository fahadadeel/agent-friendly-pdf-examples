using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using System;
using System.IO;

/// <summary>
/// Demonstrates creation of link structure elements in a tagged PDF and validates PDF/UA compliance.
/// </summary>
namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

public class LinkStructureElements
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve base directories
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Define file paths
        string outFile = Path.Combine(outputDir, "LinkStructureElements_Output.pdf");
        string logFile = Path.Combine(outputDir, "46035_log.xml");
        string imgFile = Path.Combine(inputDir, "google-icon-512.png");

        try
        {
            // Create a new PDF document and obtain its tagged content
            Document document = new Document();
            ITaggedContent taggedContent = document.TaggedContent;

            // Set document metadata
            taggedContent.SetTitle("Link Elements Example");
            taggedContent.SetLanguage("en-US");

            // Get the root structure element
            StructureElement rootElement = taggedContent.RootElement;

            // Paragraph 1 with simple link
            ParagraphElement p1 = taggedContent.CreateParagraphElement();
            rootElement.AppendChild(p1);
            LinkElement link1 = taggedContent.CreateLinkElement();
            p1.AppendChild(link1);
            link1.Hyperlink = new WebHyperlink("http://google.com");
            link1.SetText("Google");
            link1.AlternateDescriptions = "Link to Google";

            // Paragraph 2 with link containing a span
            ParagraphElement p2 = taggedContent.CreateParagraphElement();
            rootElement.AppendChild(p2);
            LinkElement link2 = taggedContent.CreateLinkElement();
            p2.AppendChild(link2);
            link2.Hyperlink = new WebHyperlink("http://google.com");
            SpanElement span2 = taggedContent.CreateSpanElement();
            span2.SetText("Google");
            link2.AppendChild(span2);
            link2.AlternateDescriptions = "Link to Google";

            // Paragraph 3 with split span elements
            ParagraphElement p3 = taggedContent.CreateParagraphElement();
            rootElement.AppendChild(p3);
            LinkElement link3 = taggedContent.CreateLinkElement();
            p3.AppendChild(link3);
            link3.Hyperlink = new WebHyperlink("http://google.com");
            SpanElement span31 = taggedContent.CreateSpanElement();
            span31.SetText("G");
            SpanElement span32 = taggedContent.CreateSpanElement();
            span32.SetText("oogle");
            link3.AppendChild(span31);
            link3.SetText("-");
            link3.AppendChild(span32);
            link3.AlternateDescriptions = "Link to Google";

            // Paragraph 4 with a long multiline link text
            ParagraphElement p4 = taggedContent.CreateParagraphElement();
            rootElement.AppendChild(p4);
            LinkElement link4 = taggedContent.CreateLinkElement();
            p4.AppendChild(link4);
            link4.Hyperlink = new WebHyperlink("http://google.com");
            link4.SetText("The multiline link: Google Google Google Google Google Google Google Google Google Google Google Google Google Google Google Google Google Google Google Google");
            link4.AlternateDescriptions = "Link to Google (multiline)";

            // Paragraph 5 with a linked figure (image)
            ParagraphElement p5 = taggedContent.CreateParagraphElement();
            rootElement.AppendChild(p5);
            LinkElement link5 = taggedContent.CreateLinkElement();
            p5.AppendChild(link5);
            link5.Hyperlink = new WebHyperlink("http://google.com");
            FigureElement figure5 = taggedContent.CreateFigureElement();
            figure5.SetImage(imgFile, 1200);
            figure5.AlternativeText = "Google icon";

            // Set layout attribute for the link
            StructureAttributes linkLayoutAttributes = link5.Attributes.GetAttributes(AttributeOwnerStandard.Layout);
            StructureAttribute placementAttribute = new StructureAttribute(AttributeKey.Placement);
            placementAttribute.SetNameValue(AttributeName.Placement_Block);
            linkLayoutAttributes.SetAttribute(placementAttribute);

            link5.AppendChild(figure5);
            link5.AlternateDescriptions = "Link to Google";

            // Save the tagged PDF document
            document.Save(outFile);

            // Validate PDF/UA compliance
            document = new Document(outFile);
            bool isPdfUaCompliance = document.Validate(logFile, PdfFormat.PDF_UA_1);
            Console.WriteLine(string.Format("PDF/UA compliance: {0}", isPdfUaCompliance));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}