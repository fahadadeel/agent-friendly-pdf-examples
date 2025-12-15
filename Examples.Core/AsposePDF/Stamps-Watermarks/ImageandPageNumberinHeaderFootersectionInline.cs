using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Stamps_Watermarks;

public class ImageandPageNumberinHeaderFooterSectionInline
{
    /// <summary>
    /// Demonstrates adding an image and inline text to a PDF header/footer using Aspose.Pdf.
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

            // Input image file path.
            string imagePath = Path.Combine(inputDir, "aspose-logo.jpg");

            // Create a new PDF document.
            Document pdf = new Document();

            // Add a page.
            Page page = pdf.Pages.Add();

            // Create header/footer and assign to page.
            HeaderFooter header = new HeaderFooter();
            page.Header = header;

            // First text fragment.
            TextFragment txt1 = new TextFragment("Aspose.Pdf is a Robust component by")
            {
                IsInLineParagraph = true
            };
            txt1.TextState.ForegroundColor = Color.Blue;

            // Image fragment.
            Image image1 = new Image
            {
                File = imagePath,
                FixWidth = 50,
                FixHeight = 20,
                IsInLineParagraph = true
            };

            // Second text fragment.
            TextFragment txt2 = new TextFragment(" Pty Ltd.")
            {
                IsInLineParagraph = true
            };
            txt2.TextState.ForegroundColor = Color.Maroon;

            // Add fragments to header.
            header.Paragraphs.Add(txt1);
            header.Paragraphs.Add(image1);
            header.Paragraphs.Add(txt2);

            // Save the PDF.
            string outputPath = Path.Combine(outputDir, "ImageAndPageNumberInHeaderFooter_UsingInlineParagraph_out.pdf");
            pdf.Save(outputPath);

            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ImageandPageNumberinHeaderFooterSectionInline.Run: {ex.Message}");
        }
    }
}