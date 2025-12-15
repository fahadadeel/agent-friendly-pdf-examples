using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using System;
using System.IO;

namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

public class RootStructure
{
    /// <summary>
    /// Demonstrates creating a tagged PDF document and accessing its root structure elements.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Create a new PDF document.
            Document document = new Document();

            // Get content for work with TaggedPdf.
            ITaggedContent taggedContent = document.TaggedContent;

            // Set title and language for the document.
            taggedContent.SetTitle("Tagged Pdf Document");
            taggedContent.SetLanguage("en-US");

            // Access the structure tree root and root element.
            StructTreeRootElement structTreeRootElement = taggedContent.StructTreeRootElement;
            StructureElement rootElement = taggedContent.RootElement;

            // Optionally save the document to demonstrate output handling.
            string outputPath = Path.Combine(outputDir, "RootStructureOutput.pdf");
            document.Save(outputPath);
            Console.WriteLine($"Document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in RootStructure.Run: {ex.Message}");
        }
    }
}