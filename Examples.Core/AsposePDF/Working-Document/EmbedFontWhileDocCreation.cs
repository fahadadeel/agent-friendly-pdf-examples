using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.WorkingDocument;

/// <summary>
/// Demonstrates embedding a custom font while creating a PDF document.
/// </summary>
public class EmbedFontWhileDocCreation
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            // No input file needed for this example, but keep the variable for consistency.
            // string dataDir = inputDir; // Not used.

            // Instantiate Pdf object by calling its empty constructor
            Document doc = new Document();

            // Create a page in the Pdf object
            Page page = doc.Pages.Add();

            // Create a text fragment with an empty string
            TextFragment fragment = new TextFragment("");

            // Create a text segment with sample text
            TextSegment segment = new TextSegment(" This is a sample text using Custom font.");

            // Configure text state to use Arial font and embed it
            TextState ts = new TextState();
            ts.Font = FontRepository.FindFont("Arial");
            ts.Font.IsEmbedded = true;
            segment.TextState = ts;

            // Add segment to fragment and fragment to page
            fragment.Segments.Add(segment);
            page.Paragraphs.Add(fragment);

            // Define output file path
            string outputPath = Path.Combine(outputDir, "EmbedFontWhileDocCreation_out.pdf");

            // Save PDF Document
            doc.Save(outputPath);

            Console.WriteLine("\nFont embedded successfully in a PDF file.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error during PDF creation: " + ex.Message);
        }
    }
}