using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Graphs;

/// <summary>
/// Demonstrates how to add a line object to a PDF document using Aspose.Pdf.
/// </summary>
public class AddLineObject
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output path relative to the application base directory.
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "AddLineObject_out.pdf");

            // Create a new PDF document.
            Document doc = new Document();

            // Add a page to the document.
            Page page = doc.Pages.Add();

            // Create a Graph object with specified dimensions.
            Aspose.Pdf.Drawing.Graph graph = new Aspose.Pdf.Drawing.Graph(100.0, 400.0);

            // Add the graph to the page's paragraphs collection.
            page.Paragraphs.Add(graph);

            // Create a Line object.
            Aspose.Pdf.Drawing.Line line = new Aspose.Pdf.Drawing.Line(new float[] { 100, 100, 200, 100 });

            // Configure line dash pattern.
            line.GraphInfo.DashArray = new int[] { 0, 1, 0 };
            line.GraphInfo.DashPhase = 1;

            // Add the line to the graph's shapes collection.
            graph.Shapes.Add(line);

            // Save the PDF document.
            doc.Save(outputPath);

            Console.WriteLine($"\nLine object added successfully to pdf.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while adding line object: {ex.Message}");
        }
    }
}