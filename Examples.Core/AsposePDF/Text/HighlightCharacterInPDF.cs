using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Devices;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates how to highlight characters in a PDF document and save the result as an image.
/// </summary>
public class HighlightCharacterInPDF
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
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Output image file.
            string outputPath = Path.Combine(outputDir, "HighlightCharacterInPDF_out.png");

            int resolution = 150;

            // Load the PDF document.
            Document pdfDocument = new Document(inputPath);

            using (MemoryStream ms = new MemoryStream())
            {
                // Convert the first page of the PDF to an image.
                PdfConverter conv = new PdfConverter(pdfDocument);
                conv.Resolution = new Resolution(resolution, resolution);
                conv.GetNextImage(ms, ImageFormat.Png);

                using (Bitmap bmp = (Bitmap)Bitmap.FromStream(ms))
                {
                    using (Graphics gr = Graphics.FromImage(bmp))
                    {
                        float scale = resolution / 72f;
                        // Resolve ambiguity by fully qualifying the Matrix type.
                        gr.Transform = new System.Drawing.Drawing2D.Matrix(scale, 0, 0, -scale, 0, bmp.Height);

                        for (int i = 0; i < pdfDocument.Pages.Count; i++)
                        {
                            // NOTE: Original code always used page 1; preserving that behavior.
                            Page page = pdfDocument.Pages[1];

                            // Find all words using a regular expression.
                            TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber(@"[\S]+");
                            textFragmentAbsorber.TextSearchOptions.IsRegularExpressionUsed = true;
                            page.Accept(textFragmentAbsorber);

                            TextFragmentCollection textFragmentCollection = textFragmentAbsorber.TextFragments;

                            foreach (TextFragment textFragment in textFragmentCollection)
                            {
                                if (i == 0)
                                {
                                    // Highlight the whole text fragment.
                                    gr.DrawRectangle(
                                        Pens.Yellow,
                                        (float)textFragment.Position.XIndent,
                                        (float)textFragment.Position.YIndent,
                                        (float)textFragment.Rectangle.Width,
                                        (float)textFragment.Rectangle.Height);

                                    for (int segNum = 1; segNum <= textFragment.Segments.Count; segNum++)
                                    {
                                        TextSegment segment = textFragment.Segments[segNum];

                                        for (int charNum = 1; charNum <= segment.Characters.Count; charNum++)
                                        {
                                            CharInfo characterInfo = segment.Characters[charNum];

                                            Aspose.Pdf.Rectangle rect = page.GetPageRect(true);
                                            Console.WriteLine("TextFragment = " + textFragment.Text + "    Page URY = " + rect.URY +
                                                              "   TextFragment URY = " + textFragment.Rectangle.URY);

                                            // Highlight individual character.
                                            gr.DrawRectangle(
                                                Pens.Black,
                                                (float)characterInfo.Rectangle.LLX,
                                                (float)characterInfo.Rectangle.LLY,
                                                (float)characterInfo.Rectangle.Width,
                                                (float)characterInfo.Rectangle.Height);
                                        }

                                        // Highlight the segment.
                                        gr.DrawRectangle(
                                            Pens.Green,
                                            (float)segment.Rectangle.LLX,
                                            (float)segment.Rectangle.LLY,
                                            (float)segment.Rectangle.Width,
                                            (float)segment.Rectangle.Height);
                                    }
                                }
                            }
                        }
                    }

                    // Save the resulting image.
                    bmp.Save(outputPath, ImageFormat.Png);
                }
            }

            Console.WriteLine("\nCharacters highlighted successfully in PDF document.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "\nThis example will only work if you apply a valid Aspose License. You can purchase a full license or get a 30‑day temporary license from http://www.aspose.com/purchase/default.aspx.");
        }
    }
}