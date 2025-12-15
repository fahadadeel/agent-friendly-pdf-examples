using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using System;
using System.IO;

namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

public class TextStructureElements
{
    /// <summary>
    /// Demonstrates creating a tagged PDF with a paragraph text structure element.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory relative to the application base directory.
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Create a new PDF document.
            Document document = new Document();

            // Access the tagged content of the document.
            ITaggedContent taggedContent = document.TaggedContent;

            // Set title and language for the document.
            taggedContent.SetTitle("Tagged Pdf Document");
            taggedContent.SetLanguage("en-US");

            // Retrieve the root structure element.
            StructureElement rootElement = taggedContent.RootElement;

            // Create a paragraph element and set its text.
            ParagraphElement paragraph = taggedContent.CreateParagraphElement();
            paragraph.SetText("Paragraph.");
            rootElement.AppendChild(paragraph);

            // Save the tagged PDF document.
            string outputPath = Path.Combine(outputDir, "TextStructureElement.pdf");
            document.Save(outputPath);

            Console.WriteLine($"Tagged PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in TextStructureElements.Run: {ex.Message}");
        }
    }
}