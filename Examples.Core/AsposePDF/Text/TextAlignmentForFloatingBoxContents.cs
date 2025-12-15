using Aspose.Pdf.Text;
using System;

/// <summary>
/// Demonstrates alignment of floating box contents in a PDF document.
/// </summary>
namespace Examples.Core.AsposePDF.Text;

public class TextAlignmentForFloatingBoxContents
{
    /// <summary>
    /// Creates a PDF with three floating boxes aligned differently and saves it to the output directory.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine output directory: <app base>/data/outputs
            string outputDir = System.IO.Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            System.IO.Directory.CreateDirectory(outputDir);

            // Create a new PDF document with a single page.
            Aspose.Pdf.Document doc = new Aspose.Pdf.Document();
            doc.Pages.Add();

            // Bottom‑aligned floating box.
            Aspose.Pdf.FloatingBox floatBox = new Aspose.Pdf.FloatingBox(100, 100);
            floatBox.VerticalAlignment = Aspose.Pdf.VerticalAlignment.Bottom;
            floatBox.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Right;
            floatBox.Paragraphs.Add(new TextFragment("FloatingBox_bottom"));
            floatBox.Border = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, Aspose.Pdf.Color.Blue);
            doc.Pages[1].Paragraphs.Add(floatBox);

            // Center‑aligned floating box.
            Aspose.Pdf.FloatingBox floatBox1 = new Aspose.Pdf.FloatingBox(100, 100);
            floatBox1.VerticalAlignment = Aspose.Pdf.VerticalAlignment.Center;
            floatBox1.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Right;
            floatBox1.Paragraphs.Add(new TextFragment("FloatingBox_center"));
            floatBox1.Border = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, Aspose.Pdf.Color.Blue);
            doc.Pages[1].Paragraphs.Add(floatBox1);

            // Top‑aligned floating box.
            Aspose.Pdf.FloatingBox floatBox2 = new Aspose.Pdf.FloatingBox(100, 100);
            floatBox2.VerticalAlignment = Aspose.Pdf.VerticalAlignment.Top;
            floatBox2.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Right;
            floatBox2.Paragraphs.Add(new TextFragment("FloatingBox_top"));
            floatBox2.Border = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, Aspose.Pdf.Color.Blue);
            doc.Pages[1].Paragraphs.Add(floatBox2);

            // Save the document.
            string outputPath = System.IO.Path.Combine(outputDir, "FloatingBox_alignment_review_out.pdf");
            doc.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in TextAlignmentForFloatingBoxContents.Run: {ex.Message}");
        }
    }
}