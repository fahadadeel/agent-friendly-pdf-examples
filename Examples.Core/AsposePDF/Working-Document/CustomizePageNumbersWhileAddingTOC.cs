using Aspose.Pdf;
using Aspose.Pdf.Text;
using System;
using System.IO;

namespace Examples.Core.AsposePDF.Working_Document;

public class CustomizePageNumbersWhileAddingTOC
{
    /// <summary>
    /// Demonstrates customizing page numbers while adding a Table of Contents.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            string inFile = Path.Combine(inputDir, "42824.pdf");
            string outFile = Path.Combine(outputDir, "42824_out.pdf");

            // Load an existing PDF file.
            Document doc = new Document(inFile);

            // Insert a new page at the beginning to hold the TOC.
            Page tocPage = doc.Pages.Insert(1);

            // Create TOC information.
            TocInfo tocInfo = new TocInfo();
            TextFragment title = new TextFragment("Table Of Contents");
            title.TextState.FontSize = 20;
            title.TextState.FontStyle = FontStyles.Bold;
            tocInfo.Title = title;
            tocInfo.PageNumbersPrefix = "P";
            tocPage.TocInfo = tocInfo;

            // Add headings for each page (starting from the second page of the original document).
            for (int i = 1; i < doc.Pages.Count; i++)
            {
                // Create a heading object with level 1.
                Heading heading = new Heading(1);
                TextSegment segment = new TextSegment();

                heading.TocPage = tocPage;
                heading.Segments.Add(segment);

                // Destination page is the page after the current one (because we inserted a TOC page at position 1).
                heading.DestinationPage = doc.Pages[i + 1];
                // Position the destination at the top of the page.
                heading.Top = doc.Pages[i + 1].Rect.Height;

                segment.Text = "Page " + i.ToString();

                // Add heading to the TOC page.
                tocPage.Paragraphs.Add(heading);
            }

            // Save the updated document.
            doc.Save(outFile);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in {nameof(CustomizePageNumbersWhileAddingTOC)}: {ex.Message}");
        }
    }
}