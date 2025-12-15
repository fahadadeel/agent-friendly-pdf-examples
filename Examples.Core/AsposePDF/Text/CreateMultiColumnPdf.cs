using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Drawing;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates how to create a PDF document with multiple columns using Aspose.Pdf.
/// </summary>
public class CreateMultiColumnPdf
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = System.IO.Path.Combine(baseDir, "data", "inputs");
            string outputDir = System.IO.Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new PDF document.
            Document doc = new Document();

            // Set left and right margins.
            doc.PageInfo.Margin.Left = 40;
            doc.PageInfo.Margin.Right = 40;

            // Add a page.
            Page page = doc.Pages.Add();

            // Draw a horizontal line at the top of the page.
            Graph graph1 = new Graph(500.0, 2.0);
            page.Paragraphs.Add(graph1);
            float[] posArr = new float[] { 1, 2, 500, 2 };
            Line l1 = new Line(posArr);
            graph1.Shapes.Add(l1);

            // Add a heading using HTML formatting.
            string s = "<font face=\"Times New Roman\" size=4>" +
                       "<strong> How to Steer Clear of money scams</strong>" +
                       "</font>";
            HtmlFragment headingText = new HtmlFragment(s);
            page.Paragraphs.Add(headingText);

            // Create a floating box that will contain two columns.
            FloatingBox box = new FloatingBox
            {
                ColumnInfo =
                {
                    ColumnCount = 2,
                    ColumnSpacing = "5",
                    ColumnWidths = "105 105"
                }
            };

            // Add a subtitle to the floating box.
            TextFragment text1 = new TextFragment("By A Googler (The Official Google Blog)");
            text1.TextState.FontSize = 8;
            text1.TextState.LineSpacing = 2;
            box.Paragraphs.Add(text1);
            text1.TextState.FontSize = 10;
            text1.TextState.FontStyle = FontStyles.Italic;

            // Draw a line inside the floating box.
            Graph graph2 = new Graph(50.0, 10.0);
            float[] posArr2 = new float[] { 1, 10, 100, 10 };
            Line l2 = new Line(posArr2);
            graph2.Shapes.Add(l2);
            box.Paragraphs.Add(graph2);

            // Add a long body text to the floating box.
            TextFragment text2 = new TextFragment(@"Sed augue tortor, sodales id, luctus et, pulvinar ut, eros. Suspendisse vel dolor. Sed quam. Curabitur ut massa vitae eros euismod aliquam. Pellentesque sit amet elit. Vestibulum interdum pellentesque augue. Cras mollis arcu sit amet purus. Donec augue. Nam mollis tortor a elit. Nulla viverra nisl vel mauris. Vivamus sapien. nascetur ridiculus mus. Nam justo lorem, aliquam luctus, sodales et, semper sed, enim Nam justo lorem, aliquam luctus, sodales et,nAenean posuere ante ut neque. Morbi sollicitudin congue felis. Praesent turpis diam, iaculis sed, pharetra non, mollis ac, mauris. Phasellus nisi ipsum, pretium vitae, tempor sed, molestie eu, dui. Duis lacus purus, tristique ut, iaculis cursus, tincidunt vitae, risus. Sed commodo. *** sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam justo lorem, aliquam luctus, sodales et, semper sed, enim Nam justo lorem, aliquam luctus, sodales et, semper sed, enim Nam justo lorem, aliquam luctus, sodales et, semper sed, enim nAenean posuere ante ut neque. Morbi sollicitudin congue felis. Praesent turpis diam, iaculis sed, pharetra non, mollis ac, mauris. Phasellus nisi ipsum, pretium vitae, tempor sed, molestie eu, dui. Duis lacus purus, tristique ut, iaculis cursus, tincidunt vitae, risus. Sed commodo. *** sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed urna. . Duis convallis ultrices nisi. Maecenas non ligula. Nunc nibh est, tincidunt in, placerat sit amet, vestibulum a, nulla. Praesent porttitor turpis eleifend ante. Morbi sodales.nAenean posuere ante ut neque. Morbi sollicitudin congue felis. Praesent turpis diam, iaculis sed, pharetra non, mollis ac, mauris. Phasellus nisi ipsum, pretium vitae, tempor sed, molestie eu, dui. Duis lacus purus, tristique ut, iaculis cursus, tincidunt vitae, risus. Sed commodo. *** sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed urna. . Duis convallis ultrices nisi. Maecenas non ligula. Nunc nibh est, tincidunt in, placerat sit amet, vestibulum a, nulla. Praesent porttitor turpis eleifend ante. Morbi sodales.");
            box.Paragraphs.Add(text2);

            // Add the floating box to the page.
            page.Paragraphs.Add(box);

            // Save the PDF document.
            string outputPath = System.IO.Path.Combine(outputDir, "CreateMultiColumnPdf_out.pdf");
            doc.Save(outputPath);

            Console.WriteLine($"\nMulti column PDF file created successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error creating multi column PDF: {ex.Message}");
        }
    }
}