using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Tagged;

namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

public class TaggedPDFContent
{
    /// <summary>
    /// Creates a simple tagged PDF document, sets its title and language, and saves it to the output folder.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve the output directory relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Define the output file path.
            string outputPath = Path.Combine(outputDir, "TaggedPDFContent.pdf");

            // Create a new PDF document.
            Document document = new Document();

            // Access the tagged content interface.
            ITaggedContent taggedContent = document.TaggedContent;

            // Set title and language for the document.
            taggedContent.SetTitle("Simple Tagged Pdf Document");
            taggedContent.SetLanguage("en-US");

            // Save the tagged PDF document.
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in TaggedPDFContent.Run: {ex.Message}");
        }
    }
}