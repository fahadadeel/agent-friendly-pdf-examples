using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Pages;

/// <summary>
/// Demonstrates how to get the page count of a PDF document after processing paragraphs.
/// </summary>
public class GetPageCount
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // ExStart:GetPageCount
            // Instantiate Document instance
            Document doc = new Document();
            // Add page to pages collection of PDF file
            Page page = doc.Pages.Add();
            // Create loop instance
            for (int i = 0; i < 300; i++)
                // Add TextFragment to paragraphs collection of page object
                page.Paragraphs.Add(new TextFragment("Pages count test"));
            // Process the paragraphs in PDF file to get accurate page count
            doc.ProcessParagraphs();
            // Print number of pages in document
            Console.WriteLine("Number of pages in document = " + doc.Pages.Count);
            // ExEnd:GetPageCount
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in GetPageCount.Run: {ex.Message}");
        }
    }
}