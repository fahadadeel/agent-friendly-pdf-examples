using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using Aspose.Pdf.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

/// <summary>
/// Demonstrates styling text within a tagged PDF using Aspose.Pdf.
/// </summary>
public class StyleTextStructure
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory (data/outputs relative to the application base directory)
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Create a new PDF document
            Document document = new Document();

            // Access the tagged content of the document
            ITaggedContent taggedContent = document.TaggedContent;

            // Set title and language for the document
            taggedContent.SetTitle("Tagged Pdf Document");
            taggedContent.SetLanguage("en-US");

            // Create a paragraph element and add it to the root element
            ParagraphElement paragraph = taggedContent.CreateParagraphElement();
            taggedContent.RootElement.AppendChild(paragraph);

            // Apply styling to the paragraph's text state
            paragraph.StructureTextState.FontSize = 18F;
            paragraph.StructureTextState.ForegroundColor = Color.Red;
            paragraph.StructureTextState.FontStyle = FontStyles.Italic;

            // Set the paragraph text
            paragraph.SetText("Red italic text.");

            // Save the tagged PDF document
            string outputPath = Path.Combine(outputDir, "StyleTextStructure.pdf");
            document.Save(outputPath);

            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing StyleTextStructure example: {ex.Message}");
        }
    }
}