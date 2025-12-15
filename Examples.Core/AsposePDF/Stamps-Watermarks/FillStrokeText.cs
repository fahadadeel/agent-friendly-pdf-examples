using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Facades;
using System;
using System.IO;

// Alias to resolve ambiguous 'Stamp' type between Aspose.Pdf.Facades and Aspose.Pdf
using FacadeStamp = Aspose.Pdf.Facades.Stamp; // AUTOFIX

namespace Examples.Core.AsposePDF.Stamps_Watermarks;

public class FillStrokeText
{
    /// <summary>
    /// Demonstrates adding a filled/stroked text stamp to a PDF document.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "ouput_out.pdf");

            // Create TextState object to transfer advanced properties.
            TextState ts = new TextState
            {
                StrokingColor = Color.Gray,
                RenderingMode = TextRenderingMode.StrokeText
            };

            // Load the input PDF document.
            Document pdfDoc = new Document(inputPath);
            PdfFileStamp fileStamp = new PdfFileStamp(pdfDoc);

            // Create a stamp and bind a formatted text.
            FacadeStamp stamp = new FacadeStamp();
            // System.Drawing.Color usage may be platform‑specific.
            stamp.BindLogo(new FormattedText(
                "PAID IN FULL",
                System.Drawing.Color.Gray,
                "Arial",
                EncodingType.Winansi,
                true,
                78));

            // Bind TextState.
            stamp.BindTextState(ts);

            // Set stamp properties.
            stamp.SetOrigin(100, 100);
            stamp.Opacity = 5;
            stamp.BlendingSpace = BlendingColorSpace.DeviceRGB;
            stamp.Rotation = 45.0F;
            stamp.IsBackground = false;

            // Add stamp to the document.
            fileStamp.AddStamp(stamp);

            // Save the output PDF.
            fileStamp.Save(outputPath);
            fileStamp.Close();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in FillStrokeText.Run: {ex.Message}");
        }
    }
}