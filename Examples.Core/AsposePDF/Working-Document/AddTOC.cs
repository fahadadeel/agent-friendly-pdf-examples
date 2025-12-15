using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.WorkingDocument;

/// <summary>
/// Demonstrates how to add a Table of Contents (TOC) to an existing PDF document using Aspose.Pdf.
/// </summary>
public class AddTOC
{
    /// <summary>
    /// Executes the AddTOC example.
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "AddTOC.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the existing PDF document.
            Document doc = new Document(inputPath);

            // Insert a new page at the beginning to hold the TOC.
            Page tocPage = doc.Pages.Insert(1);

            // Create TOC information and title.
            TocInfo tocInfo = new TocInfo();
            TextFragment title = new TextFragment("Table Of Contents");
            title.TextState.FontSize = 20;
            title.TextState.FontStyle = FontStyles.Bold;
            tocInfo.Title = title;
            tocPage.TocInfo = tocInfo;

            // Titles for the TOC entries.
            string[] titles = new string[4];
            titles[0] = "First page";
            titles[1] = "Second page";
            titles[2] = "Third page";
            titles[3] = "Fourth page";

            // Add headings for the first two pages.
            for (int i = 0; i < 2; i++)
            {
                // Create a heading object (level 1).
                Heading heading = new Heading(1);
                TextSegment segment = new TextSegment();

                heading.TocPage = tocPage;
                heading.Segments.Add(segment);

                // Destination page for the heading.
                heading.DestinationPage = doc.Pages[i + 2];

                // Position the heading at the top of the destination page.
                heading.Top = doc.Pages[i + 2].Rect.Height;

                // Set the displayed text.
                segment.Text = titles[i];

                // Add the heading to the TOC page.
                tocPage.Paragraphs.Add(heading);
            }

            // Output PDF file path.
            string outputPath = Path.Combine(outputDir, "TOC_out.pdf");

            // Save the updated document.
            doc.Save(outputPath);

            Console.WriteLine($"\nTOC added successfully to an existing PDF.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding TOC: {ex.Message}");
        }
    }
}