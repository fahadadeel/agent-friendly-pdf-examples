using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.Text;

public class TextAndImageAsParagraph
{
    /// <summary>
    /// Demonstrates adding text and an image as inline paragraphs in a PDF document.
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

            // Path to the image file used in the example.
            string imagePath = Path.Combine(inputDir, "aspose-logo.jpg");
            if (!File.Exists(imagePath))
            {
                Console.WriteLine($"Image file not found: {imagePath}");
                return;
            }

            // Create a new PDF document.
            Document doc = new Document();

            // Add a page to the document.
            Page page = doc.Pages.Add();

            // First text fragment.
            TextFragment text = new TextFragment("Hello World.. ");
            page.Paragraphs.Add(text);

            // Image as an inline paragraph.
            Aspose.Pdf.Image image = new Aspose.Pdf.Image
            {
                IsInLineParagraph = true,
                File = imagePath,
                FixHeight = 30,
                FixWidth = 100
            };
            page.Paragraphs.Add(image);

            // Second text fragment as inline.
            text = new TextFragment(" Hello Again..")
            {
                IsInLineParagraph = true
            };
            page.Paragraphs.Add(text);

            // Save the document.
            string outputPath = Path.Combine(outputDir, "TextAndImageAsParagraph_out.pdf");
            doc.Save(outputPath);

            Console.WriteLine($"\nText and image added successfully as inline paragraphs.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}