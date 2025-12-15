using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Links_Actions;

/// <summary>
/// Demonstrates creating local hyperlinks within a PDF document using Aspose.Pdf.
/// </summary>
public class CreateLocalHyperlink
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories relative to the application base path.
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new PDF document.
            Document doc = new Document();

            // Add a page to the document.
            Page page = doc.Pages.Add();

            // First text fragment with a hyperlink to page 7.
            TextFragment text = new TextFragment("link page number test to page 7");
            LocalHyperlink link = new LocalHyperlink
            {
                TargetPageNumber = 7
            };
            text.Hyperlink = link;
            page.Paragraphs.Add(text);

            // Second text fragment with a hyperlink to page 1, placed on a new page.
            text = new TextFragment("link page number test to page 1")
            {
                IsInNewPage = true
            };
            link = new LocalHyperlink
            {
                TargetPageNumber = 1
            };
            text.Hyperlink = link;
            page.Paragraphs.Add(text);

            // Define the output file path.
            string outputPath = Path.Combine(outputDir, "CreateLocalHyperlink_out.pdf");

            // Save the document.
            doc.Save(outputPath);

            Console.WriteLine($"\nLocal hyperlink created successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while creating local hyperlinks: {ex.Message}");
        }
    }
}