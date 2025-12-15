using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.WorkingDocument;

public class HidePageNumbersInTOC
{
    /// <summary>
    /// Demonstrates how to create a Table of Contents (TOC) page with hidden page numbers.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories relative to the application base path.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Output file path.
            string outFile = Path.Combine(outputDir, "HiddenPageNumbers_out.pdf");

            // Create a new PDF document.
            Document doc = new Document();

            // Add a page that will hold the TOC.
            Page tocPage = doc.Pages.Add();

            // Configure TOC information.
            TocInfo tocInfo = new TocInfo();
            TextFragment title = new TextFragment("Table Of Contents");
            title.TextState.FontSize = 20;
            title.TextState.FontStyle = FontStyles.Bold;
            tocInfo.Title = title;

            // Assign TOC info to the page.
            tocPage.TocInfo = tocInfo;

            // Hide page numbers and define formatting for four levels.
            tocInfo.IsShowPageNumbers = false;
            tocInfo.FormatArrayLength = 4;

            tocInfo.FormatArray[0].Margin.Right = 0;
            tocInfo.FormatArray[0].TextState.FontStyle = FontStyles.Bold | FontStyles.Italic;

            tocInfo.FormatArray[1].Margin.Left = 30;
            tocInfo.FormatArray[1].TextState.Underline = true;
            tocInfo.FormatArray[1].TextState.FontSize = 10;

            tocInfo.FormatArray[2].TextState.FontStyle = FontStyles.Bold;
            tocInfo.FormatArray[3].TextState.FontStyle = FontStyles.Bold;

            // Add a regular page that will contain headings.
            Page page = doc.Pages.Add();

            // Add four headings, each linked to the TOC page.
            for (int level = 1; level <= 4; level++)
            {
                Heading heading = new Heading(level);
                TextSegment segment = new TextSegment();
                heading.TocPage = tocPage;
                heading.Segments.Add(segment);
                heading.IsAutoSequence = true;
                segment.Text = "this is heading of level " + level;
                heading.IsInList = true;
                page.Paragraphs.Add(heading);
            }

            // Save the document.
            doc.Save(outFile);
            Console.WriteLine($"PDF saved to: {outFile}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in HidePageNumbersInTOC.Run: {ex.Message}");
        }
    }
}