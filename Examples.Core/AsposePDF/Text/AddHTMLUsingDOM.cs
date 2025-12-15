using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates adding HTML fragments to a PDF document using Aspose.Pdf DOM API.
/// </summary>
public class AddHTMLUsingDOM
{
    /// <summary>
    /// Creates a PDF with an HTML fragment positioned via margins and saves it to the output folder.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory (data/outputs relative to the application base).
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Instantiate Document object.
            Document doc = new Document();

            // Add a page to the document.
            Page page = doc.Pages.Add();

            // Instantiate HtmlFragment with HTML contents.
            HtmlFragment title = new HtmlFragment("<fontsize=10><b><i>Table</i></b></fontsize>");

            // Set margin information.
            title.Margin.Bottom = 10;
            title.Margin.Top = 200;

            // Add HTML fragment to the page's paragraphs collection.
            page.Paragraphs.Add(title);

            // Build output file path.
            string outputPath = Path.Combine(outputDir, "AddHTMLUsingDOM_out.pdf");

            // Save PDF file.
            doc.Save(outputPath);

            Console.WriteLine($"\nHTML using DOM added successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddHTMLUsingDOM.Run: {ex.Message}");
        }
    }

    /// <summary>
    /// Creates a PDF with a simple HTML fragment and writes it to the output folder.
    /// Also writes the width of the fragment's rectangle to the console.
    /// </summary>
    public static void HTMLFragmentRectangle()
    {
        try
        {
            // Resolve output directory (data/outputs relative to the application base).
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            Document doc = new Document();
            Page page = doc.Pages.Add();

            HtmlFragment html = new HtmlFragment("<fontsize=10><b><i>Aspose.PDF</i></b></fontsize>");
            page.Paragraphs.Add(html);

            string outputPath = Path.Combine(outputDir, "HTMLfragmentRectangle_out.pdf");
            doc.Save(outputPath);

            Console.WriteLine($"Fragment rectangle width: {html.Rectangle.Width}");
            Console.WriteLine($"File saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddHTMLUsingDOM.HTMLFragmentRectangle: {ex.Message}");
        }
    }
}