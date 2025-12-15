using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Text;

public class AddHTMLOrderedListIntoDocuments
{
    /// <summary>
    /// Demonstrates adding an HTML ordered list into a PDF document using Aspose.Pdf.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory relative to application base.
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string outFile = Path.Combine(outputDir, "AddHTMLOrderedListIntoDocuments_out.pdf");

            // Instantiate Document object
            Document doc = new Document();

            // HTML fragment containing an ordered list
            HtmlFragment html = new HtmlFragment("<body style='line-height: 100px;'><ul><li>First</li><li>Second</li><li>Third</li><li>Fourth</li><li>Fifth</li></ul>Text after the list.<br/>Next line<br/>Last line</body>");

            // Add a page and insert the HTML fragment
            Page page = doc.Pages.Add();
            page.Paragraphs.Add(html);

            // Save the PDF
            doc.Save(outFile);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddHTMLOrderedListIntoDocuments.Run: {ex.Message}");
        }
    }
}