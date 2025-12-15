using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Miscellaneous;

/// <summary>
/// Demonstrates how to use Measure with a PolylineAnnotation in Aspose.Pdf.
/// </summary>
public class UseMeasureWithPolylineAnnotation
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // ExStart:UseMeasureWithPolylineAnnotation
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "UseMeasureWithPolylineAnnotation_out.pdf");

            // Load the document.
            Document doc = new Document(inputPath);

            // Define the vertices of the polyline.
            Point[] vertices = new Point[]
            {
                new Point(100, 600),
                new Point(500, 600),
                new Point(500, 500),
                new Point(400, 300),
                new Point(100, 500),
                new Point(100, 600)
            };

            // Define the rectangle that bounds the annotation.
            Rectangle rect = new Rectangle(100, 500, 500, 600);

            // Create the polyline annotation (area or perimeter line).
            PolylineAnnotation area = new PolylineAnnotation(doc.Pages[1], rect, vertices);
            area.Color = Color.Red;

            // Set line ending styles.
            area.StartingStyle = LineEnding.OpenArrow;
            area.EndingStyle = LineEnding.OpenArrow;

            // Attach a Measure object to the annotation.
            area.Measure = new Measure(area);
            area.Measure.DistanceFormat = new Measure.NumberFormatList(area.Measure);
            area.Measure.DistanceFormat.Add(new Measure.NumberFormat(area.Measure));
            // The first element (index 0) is the default format; we modify the second (index 1).
            if (area.Measure.DistanceFormat.Count > 1)
            {
                area.Measure.DistanceFormat[1].UnitLabel = "mm";
            }

            // Add the annotation to the page.
            doc.Pages[1].Annotations.Add(area);

            // Save the modified document.
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in UseMeasureWithPolylineAnnotation: {ex.Message}");
        }
        // ExEnd:UseMeasureWithPolylineAnnotation
    }
}