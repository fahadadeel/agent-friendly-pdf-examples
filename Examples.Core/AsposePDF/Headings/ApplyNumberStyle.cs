using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Headings;

public class ApplyNumberStyle
{
    /// <summary>
    /// Demonstrates applying different numbering styles to headings in a PDF document.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories.
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Output file path.
            string outputPath = Path.Combine(outputDir, "ApplyNumberStyle_out.pdf");

            // Create a new PDF document.
            Document pdfDoc = new Document();
            pdfDoc.PageInfo.Width = 612.0;
            pdfDoc.PageInfo.Height = 792.0;
            pdfDoc.PageInfo.Margin = new MarginInfo { Left = 72, Right = 72, Top = 72, Bottom = 72 };

            // Add a page.
            Page pdfPage = pdfDoc.Pages.Add();
            pdfPage.PageInfo.Width = 612.0;
            pdfPage.PageInfo.Height = 792.0;
            pdfPage.PageInfo.Margin = new MarginInfo { Left = 72, Right = 72, Top = 72, Bottom = 72 };

            // Create a floating box that uses the page margins.
            FloatingBox floatBox = new FloatingBox { Margin = pdfPage.PageInfo.Margin };
            pdfPage.Paragraphs.Add(floatBox);

            // First heading.
            Heading heading = new Heading(1)
            {
                IsInList = true,
                StartNumber = 1,
                Text = "List 1",
                Style = NumberingStyle.NumeralsRomanLowercase,
                IsAutoSequence = true
            };
            floatBox.Paragraphs.Add(heading);

            // Second heading.
            Heading heading2 = new Heading(1)
            {
                IsInList = true,
                StartNumber = 13,
                Text = "List 2",
                Style = NumberingStyle.NumeralsRomanLowercase,
                IsAutoSequence = true
            };
            floatBox.Paragraphs.Add(heading2);

            // Third heading.
            Heading heading3 = new Heading(2)
            {
                IsInList = true,
                StartNumber = 1,
                Text = "the value, as of the effective date of the plan, of property to be distributed under the plan onaccount of each allowed",
                Style = NumberingStyle.LettersLowercase,
                IsAutoSequence = true
            };
            floatBox.Paragraphs.Add(heading3);

            // Save the document.
            pdfDoc.Save(outputPath);
            Console.WriteLine($"\nNumber style applied successfully in headings.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing ApplyNumberStyle: {ex.Message}");
        }
    }
}