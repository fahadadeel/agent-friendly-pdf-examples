using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using System;
using System.IO;

namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

/// <summary>
/// Demonstrates how to access and modify child elements of a tagged PDF document.
/// </summary>
public class AccessChildrenElements
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

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "StructureElementsTree.pdf");
            string outputPath = Path.Combine(outputDir, "AccessChildrenElements.pdf");

            // Open PDF document.
            Document document = new Document(inputPath);

            // Get content for work with TaggedPdf.
            ITaggedContent taggedContent = document.TaggedContent;

            // Access root element(s).
            ElementList elementList = taggedContent.StructTreeRootElement.ChildElements;
            foreach (Element element in elementList)
            {
                if (element is StructureElement structureElement)
                {
                    // Get properties.
                    string title = structureElement.Title;
                    string language = structureElement.Language;
                    string actualText = structureElement.ActualText;
                    string expansionText = structureElement.ExpansionText;
                    string alternativeText = structureElement.AlternativeText;

                    // (Optional) Use the retrieved values, e.g., log them.
                    Console.WriteLine($"Root Element - Title: {title}, Language: {language}");
                }
            }

            // Access children elements of the second element in the root element (index 1).
            elementList = taggedContent.RootElement.ChildElements[1].ChildElements;
            foreach (Element element in elementList)
            {
                if (element is StructureElement structureElement)
                {
                    // Set properties.
                    structureElement.Title = "title";
                    structureElement.Language = "fr-FR";
                    structureElement.ActualText = "actual text";
                    structureElement.ExpansionText = "exp";
                    structureElement.AlternativeText = "alt";
                }
            }

            // Save the modified tagged PDF document.
            document.Save(outputPath);

            Console.WriteLine($"Tagged PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during AccessChildrenElements execution: {ex.Message}");
        }
    }
}