using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.Annotations;

/// <summary>
/// Demonstrates how to set line width and other properties for a link annotation using Aspose.Pdf.
/// </summary>
public class LnkAnnotationLineWidth
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Output file path.
            string outputPath = Path.Combine(outputDir, "lnkAnnotationLineWidth_out.pdf");

            // Create a new PDF document with a single page.
            Document doc = new Document();
            doc.Pages.Add();

            // Prepare ink annotation points.
            IList<Point[]> inkList = new List<Point[]>();
            LineInfo lineInfo = new LineInfo
            {
                VerticeCoordinate = new float[] { 55, 55, 70, 70, 70, 90, 150, 60 },
                Visibility = true,
                LineColor = System.Drawing.Color.Red, // Aspose.Pdf uses System.Drawing.Color for line color.
                LineWidth = 2
            };

            int length = lineInfo.VerticeCoordinate.Length / 2;
            Aspose.Pdf.Point[] gesture = new Aspose.Pdf.Point[length];
            for (int i = 0; i < length; i++)
            {
                gesture[i] = new Aspose.Pdf.Point(
                    lineInfo.VerticeCoordinate[2 * i],
                    lineInfo.VerticeCoordinate[2 * i + 1]);
            }

            inkList.Add(gesture);

            // Create the ink annotation.
            InkAnnotation inkAnnotation = new InkAnnotation(
                doc.Pages[1],
                new Aspose.Pdf.Rectangle(100, 100, 300, 300),
                inkList)
            {
                Subject = "Test",
                Title = "Title",
                Color = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Green) // Uses System.Drawing.Color.
            };

            // Configure border.
            Border border = new Border(inkAnnotation)
            {
                Width = 3,
                Effect = BorderEffect.Cloudy,
                Dash = new Dash(1, 1),
                Style = BorderStyle.Solid
            };

            // Add annotation to the page.
            doc.Pages[1].Annotations.Add(inkAnnotation);

            // Save the document.
            doc.Save(outputPath);

            Console.WriteLine($"\nlnk annotation line width setup successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing LnkAnnotationLineWidth example: {ex.Message}");
        }
    }
}