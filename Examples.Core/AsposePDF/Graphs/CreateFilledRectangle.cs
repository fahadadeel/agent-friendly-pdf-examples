using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Drawing;

namespace Examples.Core.AsposePDF.Graphs;

/// <summary>
/// Demonstrates how to create a filled rectangle in a PDF document using Aspose.Pdf.
/// </summary>
public class CreateFilledRectangle
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
            string outputDir = System.IO.Path.Combine(baseDir, "data", "outputs"); // AUTOFIX

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new PDF document.
            Document doc = new Document();

            // Add a page to the document.
            Page page = doc.Pages.Add();

            // Create a Graph object positioned at (100, 400).
            Graph graph = new Graph(100.0, 400.0);
            page.Paragraphs.Add(graph);

            // Create a rectangle shape (x=100, y=100, width=200, height=120).
            Aspose.Pdf.Drawing.Rectangle rect = new Aspose.Pdf.Drawing.Rectangle(100, 100, 200, 120); // AUTOFIX
            rect.GraphInfo.FillColor = Color.Red;

            // Add the rectangle to the graph.
            graph.Shapes.Add(rect);

            // Define the output file path.
            string outputPath = System.IO.Path.Combine(outputDir, "CreateFilledRectangle_out.pdf"); // AUTOFIX

            // Save the PDF document.
            doc.Save(outputPath);

            Console.WriteLine($"\nFilled rectangle object created successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error creating filled rectangle PDF: {ex.Message}");
        }
    }
}