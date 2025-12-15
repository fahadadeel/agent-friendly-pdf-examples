using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Example demonstrating how to tag images in an existing PDF and validate PDF/UA compliance.
/// </summary>
namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

public class TagImageInExistingPDF
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory ?? Directory.GetCurrentDirectory();
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        string inFile = Path.Combine(inputDir, "TH.pdf");
        string outFile = Path.Combine(outputDir, "TH_out.pdf");
        string logFile = Path.Combine(outputDir, "TH_out.xml");

        try
        {
            // Open document
            Document document = new Document(inFile);

            // Gets tagged content and root structure element
            ITaggedContent taggedContent = document.TaggedContent;
            StructureElement rootElement = taggedContent.RootElement;

            // Set title for tagged pdf document
            taggedContent.SetTitle("Document with images");

            // Process all Figure elements
            foreach (FigureElement figureElement in rootElement.FindElements<FigureElement>(true))
            {
                // Set Alternative Text for Figure
                figureElement.AlternativeText = "Figure alternative text (technique 2)";

                // Create and Set BBox Attribute
                StructureAttribute bboxAttribute = new StructureAttribute(AttributeKey.BBox);
                bboxAttribute.SetRectangleValue(new Rectangle(0.0, 0.0, 100.0, 100.0));

                StructureAttributes figureLayoutAttributes = figureElement.Attributes.GetAttributes(AttributeOwnerStandard.Layout);
                figureLayoutAttributes.SetAttribute(bboxAttribute);
            }

            // Move Span Element into Paragraph (find wrong span and paragraph in first TD)
            TableElement tableElement = rootElement.FindElements<TableElement>(true)[0];
            SpanElement spanElement = tableElement.FindElements<SpanElement>(true)[0];
            TableTDElement firstTdElement = tableElement.FindElements<TableTDElement>(true)[0];
            ParagraphElement paragraph = firstTdElement.FindElements<ParagraphElement>(true)[0];

            // Move Span Element into Paragraph
            spanElement.ChangeParentElement(paragraph);

            // Save document
            document.Save(outFile);

            // Checking PDF/UA Compliance for out document
            Document outDoc = new Document(outFile);
            bool isPdfUaCompliance = outDoc.Validate(logFile, PdfFormat.PDF_UA_1);
            Console.WriteLine(string.Format("PDF/UA compliance: {0}", isPdfUaCompliance));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during TagImageInExistingPDF execution: {ex.Message}");
        }
    }
}