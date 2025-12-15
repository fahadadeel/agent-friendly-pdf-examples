using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Graphs;

/// <summary>
/// Demonstrates drawing two diagonal lines across a PDF page using Aspose.Pdf.
/// </summary>
public class DrawingLine
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
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Output file path.
            string outputPath = Path.Combine(outputDir, "DrawingLine_out.pdf");

            // Create a new PDF document.
            Document pDoc = new Document();

            // Add a page to the document.
            Page pg = pDoc.Pages.Add();

            // Set page margins to zero on all sides.
            pg.PageInfo.Margin.Left = pg.PageInfo.Margin.Right = pg.PageInfo.Margin.Bottom = pg.PageInfo.Margin.Top = 0;

            // Create a Graph object sized to the page dimensions.
            Aspose.Pdf.Drawing.Graph graph = new Aspose.Pdf.Drawing.Graph(pg.PageInfo.Width, pg.PageInfo.Height);

            // First line: lower‑left to upper‑right corner.
            Aspose.Pdf.Drawing.Line line = new Aspose.Pdf.Drawing.Line(new float[]
            {
                (float)pg.Rect.LLX, 0,
                (float)pg.PageInfo.Width, (float)pg.Rect.URY
            });
            graph.Shapes.Add(line);

            // Second line: upper‑left to lower‑right corner.
            Aspose.Pdf.Drawing.Line line2 = new Aspose.Pdf.Drawing.Line(new float[]
            {
                0, (float)pg.Rect.URY,
                (float)pg.PageInfo.Width, (float)pg.Rect.LLX
            });
            graph.Shapes.Add(line2);

            // Add the graph to the page's paragraphs collection.
            pg.Paragraphs.Add(graph);

            // Save the PDF file.
            pDoc.Save(outputPath);

            Console.WriteLine($"\nLine drawn successfully across the page.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing DrawingLine example: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.