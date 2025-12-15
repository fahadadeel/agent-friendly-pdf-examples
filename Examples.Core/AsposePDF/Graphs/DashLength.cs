using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Drawing;

namespace Examples.Core.AsposePDF.Graphs;

/// <summary>
/// Demonstrates creating a line with dash length settings using Aspose.Pdf.
/// </summary>
public class DashLength
{
    public static void Run()
    {
        try
        {
            // Determine base directories
            string baseDir = AppContext.BaseDirectory;
            string inputDir = System.IO.Path.Combine(baseDir, "data", "inputs");
            string outputDir = System.IO.Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Output file path
            string outputPath = System.IO.Path.Combine(outputDir, "DashLength_out.pdf");

            // Instantiate Document instance
            Document doc = new Document();

            // Add page to pages collection of Document object
            Page page = doc.Pages.Add();

            // Create Drawing object with certain dimensions
            Graph canvas = new Graph(100.0, 400.0);

            // Add drawing object to paragraphs collection of page instance
            page.Paragraphs.Add(canvas);

            // Create Line object
            Line line = new Line(new float[] { 100, 100, 200, 100 });

            // Set color for Line object
            line.GraphInfo.Color = Color.Red;

            // Specify dash array for line object
            line.GraphInfo.DashArray = new int[] { 0, 1, 0 };

            // Set the dash phase for Line instance
            line.GraphInfo.DashPhase = 1;

            // Add line to shapes collection of drawing object
            canvas.Shapes.Add(line);

            // Save PDF document
            doc.Save(outputPath);

            Console.WriteLine($"\nLength dashed successfully in black and white.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in DashLength example: {ex.Message}");
        }
    }
}