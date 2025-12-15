using Aspose.Pdf;
using Aspose.Pdf.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using IOPath = System.IO.Path; // AUTOFIX
using DrawingRectangle = Aspose.Pdf.Drawing.Rectangle; // AUTOFIX

namespace Examples.Core.AsposePDF.Graphs;

/// <summary>
/// Demonstrates adding a drawing with a gradient fill to a PDF document using Aspose.Pdf.
/// </summary>
public class AddDrawingWithGradientFill
{
    /// <summary>
    /// Creates a PDF containing a rectangle filled with an axial gradient (red to blue) and saves it to the
    /// <c>data/outputs</c> directory relative to the application base path.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory and ensure it exists.
            string outputDir = IOPath.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Create a new PDF document.
            Document doc = new Document();
            Page page = doc.Pages.Add();

            // Create a graph of size 300x300.
            Graph graph = new Graph(300.0, 300.0);
            page.Paragraphs.Add(graph);

            // Add a rectangle shape to the graph.
            DrawingRectangle rect = new DrawingRectangle(0, 0, 300, 300);
            graph.Shapes.Add(rect);

            // Apply an axial gradient fill (red to blue) to the rectangle.
            rect.GraphInfo.FillColor = new Color
            {
                PatternColorSpace = new GradientAxialShading(Color.Red, Color.Blue)
                {
                    Start = new Point(0, 0),
                    End = new Point(300, 300)
                }
            };

            // Save the document.
            string outputPath = IOPath.Combine(outputDir, "AddDrawingWithGradientFill_out.pdf");
            doc.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddDrawingWithGradientFill.Run: {ex.Message}");
        }
    }
}