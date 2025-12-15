using Aspose.Pdf;
using Aspose.Pdf.Text;
using System;
using System.IO;

/// <summary>
/// Demonstrates extracting paragraphs by drawing borders around them in a PDF document.
/// </summary>
namespace Examples.Core.AsposePDF.Text;

public class ExtractParagraphsByDrawingBorder
{
    /// <summary>
    /// Entry point for the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            ExtractParagraph();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // ExStart:1
    private static void ExtractParagraph()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        string inputPath = Path.Combine(inputDir, "input.pdf");
        string outputPath = Path.Combine(outputDir, "output_out.pdf");

        // Load the PDF document.
        Document doc = new Document(inputPath);
        Page page = doc.Pages[2];

        ParagraphAbsorber absorber = new ParagraphAbsorber();
        absorber.Visit(page);

        PageMarkup markup = absorber.PageMarkups[0];

        foreach (MarkupSection section in markup.Sections)
        {
            DrawRectangleOnPage(section.Rectangle, page);
            foreach (MarkupParagraph paragraph in section.Paragraphs)
            {
                DrawPolygonOnPage(paragraph.Points, page);
            }
        }

        // Save the modified document.
        doc.Save(outputPath);
    }

    private static void DrawRectangleOnPage(Rectangle rectangle, Page page)
    {
        page.Contents.Add(new Aspose.Pdf.Operators.GSave());
        page.Contents.Add(new Aspose.Pdf.Operators.ConcatenateMatrix(1, 0, 0, 1, 0, 0));
        page.Contents.Add(new Aspose.Pdf.Operators.SetRGBColorStroke(0, 1, 0));
        page.Contents.Add(new Aspose.Pdf.Operators.SetLineWidth(2));
        page.Contents.Add(
            new Aspose.Pdf.Operators.Re(
                rectangle.LLX,
                rectangle.LLY,
                rectangle.Width,
                rectangle.Height));
        page.Contents.Add(new Aspose.Pdf.Operators.ClosePathStroke());
        page.Contents.Add(new Aspose.Pdf.Operators.GRestore());
    }

    private static void DrawPolygonOnPage(Point[] polygon, Page page)
    {
        page.Contents.Add(new Aspose.Pdf.Operators.GSave());
        page.Contents.Add(new Aspose.Pdf.Operators.ConcatenateMatrix(1, 0, 0, 1, 0, 0));
        page.Contents.Add(new Aspose.Pdf.Operators.SetRGBColorStroke(0, 0, 1));
        page.Contents.Add(new Aspose.Pdf.Operators.SetLineWidth(1));
        page.Contents.Add(new Aspose.Pdf.Operators.MoveTo(polygon[0].X, polygon[0].Y));
        for (int i = 1; i < polygon.Length; i++)
        {
            page.Contents.Add(new Aspose.Pdf.Operators.LineTo(polygon[i].X, polygon[i].Y));
        }
        page.Contents.Add(new Aspose.Pdf.Operators.LineTo(polygon[0].X, polygon[0].Y));
        page.Contents.Add(new Aspose.Pdf.Operators.ClosePathStroke());
        page.Contents.Add(new Aspose.Pdf.Operators.GRestore());
    }
    // ExEnd:1
}