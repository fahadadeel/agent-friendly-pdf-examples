using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Graphs;

/// <summary>
/// Demonstrates controlling rectangle Z-order in a PDF using Aspose.Pdf.
/// </summary>
public class ControlRectangleZOrder
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine output directory and file path
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "ControlRectangleZOrder_out.pdf");

            // Instantiate Document class object
            Document doc1 = new Document();
            // Add page to pages collection of PDF file
            Aspose.Pdf.Page page1 = doc1.Pages.Add();
            // Set size of PDF page
            page1.SetPageSize(375, 300);
            // Set left margin for page object as 0
            page1.PageInfo.Margin.Left = 0;
            // Set top margin of page object as 0
            page1.PageInfo.Margin.Top = 0;
            // Create rectangles with different Z-order
            AddRectangle(page1, 50, 40, 60, 40, Aspose.Pdf.Color.Red, 2);
            AddRectangle(page1, 20, 20, 30, 30, Aspose.Pdf.Color.Blue, 1);
            AddRectangle(page1, 40, 40, 60, 30, Aspose.Pdf.Color.Green, 0);

            // Save resultant PDF file
            doc1.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ControlRectangleZOrder.Run: {ex.Message}");
        }
    }

    // ExStart:AddRectangle
    private static void AddRectangle(Aspose.Pdf.Page page, float x, float y, float width, float height, Aspose.Pdf.Color color, int zindex)
    {
        // Create graph object with dimensions same as specified for Rectangle object
        Aspose.Pdf.Drawing.Graph graph = new Aspose.Pdf.Drawing.Graph(width * 1.0, height * 1.0);
        // Can we change the position of graph instance
        graph.IsChangePosition = false;
        // Set Left coordinate position for Graph instance
        graph.Left = x;
        // Set Top coordinate position for Graph object
        graph.Top = y;
        // Add a rectangle inside the "graph"
        Aspose.Pdf.Drawing.Rectangle rect = new Aspose.Pdf.Drawing.Rectangle(0, 0, width, height);
        // Set rectangle fill color
        rect.GraphInfo.FillColor = color;
        // Color of graph object
        rect.GraphInfo.Color = color;
        // Add rectangle to shapes collection of graph instance
        graph.Shapes.Add(rect);
        // Set Z-Index for rectangle object
        graph.ZIndex = zindex;
        // Add graph to paragraphs collection of page object
        page.Paragraphs.Add(graph);
    }
    // ExEnd:AddRectangle
}