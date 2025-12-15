using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using System;
using System.IO;

/// <summary>
/// Demonstrates setting properties on structure elements in a tagged PDF using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

public class StructureElementsProperties
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories.
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Create a new PDF document.
            Document document = new Document();

            // Get Tagged content.
            ITaggedContent taggedContent = document.TaggedContent;

            // Set title and language for the document.
            taggedContent.SetTitle("Tagged Pdf Document");
            taggedContent.SetLanguage("en-US");

            // Create structure elements.
            StructureElement rootElement = taggedContent.RootElement;

            SectElement sect = taggedContent.CreateSectElement();
            rootElement.AppendChild(sect);

            HeaderElement h1 = taggedContent.CreateHeaderElement(1);
            sect.AppendChild(h1);
            h1.SetText("The Header");

            h1.Title = "Title";
            h1.Language = "en-US";
            h1.AlternativeText = "Alternative Text";
            h1.ExpansionText = "Expansion Text";
            h1.ActualText = "Actual Text";

            // Save the tagged PDF document.
            string outputPath = Path.Combine(outputDir, "StructureElementsProperties.pdf");
            document.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in StructureElementsProperties.Run: {ex.Message}");
        }
    }
}