using Aspose.Pdf;
using Aspose.Pdf.Text;
using System;
using System.IO;

namespace Examples.Core.AsposePDF.Text;

public class AddHTMLUsingDOMAndOverwrite
{
    /// <summary>
    /// Demonstrates adding an HTML fragment to a PDF document using DOM and overwriting text properties.
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
                Directory.CreateDirectory(outputDir);

            // No input file is required for this example; we create a new PDF document.
            Document doc = new Document();

            // Add a page to the document.
            Page page = doc.Pages.Add();

            // Create an HTML fragment.
            HtmlFragment title = new HtmlFragment("<p style='font-family: Verdana'><b><i>Table contains text</i></b></p>");

            // Overwrite the font family and set font size.
            title.TextState = new TextState("Arial");
            title.TextState.FontSize = 20;

            // Set margin values.
            title.Margin.Bottom = 10;
            title.Margin.Top = 400;

            // Add the HTML fragment to the page.
            page.Paragraphs.Add(title);

            // Save the PDF file.
            string outputPath = Path.Combine(outputDir, "AddHTMLUsingDOMAndOverwrite_out.pdf");
            doc.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddHTMLUsingDOMAndOverwrite.Run: {ex.Message}");
        }
    }
}