using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Drawing;
using System.Drawing; // TODO: System.Drawing may be platform‑specific; verify compatibility on target runtime.

// Alias conflicting types to resolve ambiguity
using SysPath = System.IO.Path;
using AsposeRectangle = Aspose.Pdf.Drawing.Rectangle;
using AsposeColor = Aspose.Pdf.Color;
using SysColor = System.Drawing.Color;

namespace Examples.Core.AsposePDF.Graphs;

/// <summary>
/// Demonstrates creating rectangles with alpha (transparency) colors using Aspose.Pdf.
/// </summary>
public class CreateRectangleWithAlphaColor
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory (data/outputs relative to the application base directory)
            string outputDir = SysPath.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Output file path
            string outputPath = SysPath.Combine(outputDir, "CreateRectangleWithAlphaColor_out.pdf");

            // Instantiate a new PDF document
            Document doc = new Document();

            // Add a page to the document
            Page page = doc.Pages.Add();

            // Create a drawing canvas (graph) with specified dimensions
            Graph canvas = new Graph(100.0, 400.0);

            // First rectangle with semi‑transparent fill
            AsposeRectangle rect = new AsposeRectangle(100, 100, 200, 100);
            // Fill color using ARGB (alpha = 128) – verify that Aspose.Pdf.Color.FromRgb accepts System.Drawing.Color
            rect.GraphInfo.FillColor = AsposeColor.FromRgb(SysColor.FromArgb(128, SysColor.FromArgb(12957183)));
            canvas.Shapes.Add(rect);

            // Second rectangle with a different semi‑transparent fill
            AsposeRectangle rect1 = new AsposeRectangle(200, 150, 200, 100);
            rect1.GraphInfo.FillColor = AsposeColor.FromRgb(SysColor.FromArgb(128, SysColor.FromArgb(16118015)));
            canvas.Shapes.Add(rect1);

            // Add the graph to the page's paragraph collection
            page.Paragraphs.Add(canvas);

            // Save the PDF document
            doc.Save(outputPath);

            Console.WriteLine($"\nRectangle object created successfully with alpha color.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing CreateRectangleWithAlphaColor: {ex.Message}");
        }
    }
}