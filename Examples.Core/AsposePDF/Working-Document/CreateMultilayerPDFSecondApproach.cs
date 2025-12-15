using System;
using System.IO;
using System.Drawing;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.WorkingDocument;

/// <summary>
/// Demonstrates creating a multilayer PDF using a second approach.
/// </summary>
public class CreateMultilayerPDFSecondApproach
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
            Directory.CreateDirectory(outputDir);

            // Input image path.
            string imagePath = Path.Combine(inputDir, "test_image.png");
            // Output PDF path.
            string outputPath = Path.Combine(outputDir, "Multilayer-2ndApproach_out.pdf");

            // Define a custom color (alpha, red, green, blue).
            int alpha = 10;
            int green = 0;
            int red = 100;
            int blue = 0;
            System.Drawing.Color alphaColor = System.Drawing.Color.FromArgb(alpha, red, green, blue);

            // Create a new PDF document.
            Document doc = new Document();

            // Add a page.
            Page page = doc.Pages.Add();

            // Create a text fragment.
            TextFragment t1 = new TextFragment("paragraph 3 segment");
            t1.TextState.ForegroundColor = Aspose.Pdf.Color.Red;
            t1.IsInLineParagraph = true;
            t1.TextState.FontSize = 12;

            // Create a floating box for the text.
            FloatingBox textFloatingBox = new FloatingBox(117, 21)
            {
                ZIndex = 1,
                Left = -4,
                Top = -4
            };
            page.Paragraphs.Add(textFloatingBox);
            textFloatingBox.Paragraphs.Add(t1);

            // Create an image and assign the file path.
            Aspose.Pdf.Image image1 = new Aspose.Pdf.Image
            {
                File = imagePath
            };

            // Create a floating box for the image.
            FloatingBox imageFloatingBox = new FloatingBox(117, 21)
            {
                Left = -4,
                Top = -4,
                ZIndex = 2
            };
            page.Paragraphs.Add(imageFloatingBox);
            imageFloatingBox.Paragraphs.Add(image1);

            // Save the document.
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing CreateMultilayerPDFSecondApproach: {ex.Message}");
        }
    }
}