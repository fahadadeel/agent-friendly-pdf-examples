using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates creating custom tab stops in a PDF document using Aspose.Pdf.
/// </summary>
public class CustomTabStops
{
    /// <summary>
    /// Runs the custom tab stops example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // The example does not read any external files, but the input directory is kept for consistency.
            // Create a new PDF document.
            Document pdfDocument = new Document();
            Page page = pdfDocument.Pages.Add();

            // Define custom tab stops.
            TabStops ts = new TabStops();
            TabStop ts1 = ts.Add(100);
            ts1.AlignmentType = TabAlignmentType.Right;
            ts1.LeaderType = TabLeaderType.Solid;

            TabStop ts2 = ts.Add(200);
            ts2.AlignmentType = TabAlignmentType.Center;
            ts2.LeaderType = TabLeaderType.Dash;

            TabStop ts3 = ts.Add(300);
            ts3.AlignmentType = TabAlignmentType.Left;
            ts3.LeaderType = TabLeaderType.Dot;

            // Create text fragments using the tab stops.
            TextFragment header = new TextFragment("This is a example of forming table with TAB stops", ts);
            TextFragment text0 = new TextFragment("#$TABHead1 #$TABHead2 #$TABHead3", ts);
            TextFragment text1 = new TextFragment("#$TABdata11 #$TABdata12 #$TABdata13", ts);
            TextFragment text2 = new TextFragment("#$TABdata21 ", ts);
            text2.Segments.Add(new TextSegment("#$TAB"));
            text2.Segments.Add(new TextSegment("data22 "));
            text2.Segments.Add(new TextSegment("#$TAB"));
            text2.Segments.Add(new TextSegment("data23"));

            // Add fragments to the page.
            page.Paragraphs.Add(header);
            page.Paragraphs.Add(text0);
            page.Paragraphs.Add(text1);
            page.Paragraphs.Add(text2);

            // Save the document.
            string outputPath = Path.Combine(outputDir, "CustomTabStops_out.pdf");
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nCustom tab stops setup successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing CustomTabStops example: {ex.Message}");
        }
    }
}