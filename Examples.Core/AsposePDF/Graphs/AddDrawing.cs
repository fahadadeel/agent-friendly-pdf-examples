using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Drawing;

namespace Examples.Core.AsposePDF.Graphs;

/// <summary>
/// Demonstrates adding a drawing (rectangle) with transparent fill color to a PDF document using Aspose.Pdf.
/// </summary>
public class AddDrawing
{
    public static void Run()
    {
        try
        {
            // Resolve directories
            string baseDir = AppContext.BaseDirectory;
            string outputDir = System.IO.Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Output file path
            string outputPath = System.IO.Path.Combine(outputDir, "AddDrawing_out.pdf");

            // Define colors
            int alpha = 10;
            int green = 0;
            int red = 100;
            int blue = 0;
            Color alphaColor = Color.FromArgb(alpha, red, green, blue); // Provide alpha channel

            // Create a new PDF document
            Document document = new Document();

            // Add a page
            Page page = document.Pages.Add();

            // Create a Graph object with dimensions
            Graph graph = new Graph(300.0, 400.0);

            // Set border for the graph
            graph.Border = new BorderInfo(BorderSide.All, Color.Black);

            // Add graph to the page
            page.Paragraphs.Add(graph);

            // Create a rectangle shape
            Aspose.Pdf.Drawing.Rectangle rectangle = new Aspose.Pdf.Drawing.Rectangle(0, 0, 100, 50);

            // Configure rectangle appearance
            GraphInfo graphInfo = rectangle.GraphInfo;
            graphInfo.Color = Color.Red;
            graphInfo.FillColor = alphaColor;

            // Add rectangle to the graph
            graph.Shapes.Add(rectangle);

            // Save the PDF
            document.Save(outputPath);

            Console.WriteLine($"\nDrawing added successfully with transparent color.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddDrawing.Run: {ex.Message}");
        }
    }
}