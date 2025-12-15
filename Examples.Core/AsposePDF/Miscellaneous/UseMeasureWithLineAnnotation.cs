using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Miscellaneous;

public class UseMeasureWithLineAnnotation
{
    /// <summary>
    /// Demonstrates how to add a line annotation with measurement to a PDF document.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "UseMeasureWithLineAnnotation_out.pdf");

            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Define the rectangle that bounds the annotation.
            Rectangle rect = new Rectangle(260, 630, 451, 662);

            // Create a line annotation with start and end points.
            LineAnnotation line = new LineAnnotation(doc.Pages[1], rect, new Point(266, 657), new Point(446, 656))
            {
                Color = Color.Red,
                LeaderLine = -15,
                LeaderLineExtension = 5,
                StartingStyle = LineEnding.OpenArrow,
                EndingStyle = LineEnding.OpenArrow,
                Contents = "155 mm",
                ShowCaption = true,
                CaptionPosition = CaptionPosition.Top
            };

            // Create and configure the Measure element.
            line.Measure = new Measure(line);
            line.Measure.DistanceFormat = new Measure.NumberFormatList(line.Measure);
            line.Measure.DistanceFormat.Add(new Measure.NumberFormat(line.Measure));
            line.Measure.DistanceFormat[1].UnitLabel = "mm";
            line.Measure.DistanceFormat[1].FractionSeparator = ".";
            line.Measure.DistanceFormat[1].ConvresionFactor = 1;

            // Add the annotation to the page and save the document.
            doc.Pages[1].Annotations.Add(line);
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in UseMeasureWithLineAnnotation: {ex.Message}");
        }
    }
}