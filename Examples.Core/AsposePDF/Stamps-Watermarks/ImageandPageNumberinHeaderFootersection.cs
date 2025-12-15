using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Stamps_Watermarks;

/// <summary>
/// Demonstrates adding an image to the header and a page number text to the footer of a PDF document.
/// </summary>
public class ImageAndPageNumberinHeaderFooterSection
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Path to the image used in the header.
            string imagePath = Path.Combine(inputDir, "aspose-logo.jpg");
            if (!File.Exists(imagePath))
            {
                Console.Error.WriteLine($"Image file not found: {imagePath}");
                return;
            }

            // Create a new PDF document.
            Document doc = new Document();

            // Add a page to the document.
            Page page = doc.Pages.Add();

            // ----- Header -----
            HeaderFooter header = new HeaderFooter();
            page.Header = header;

            // Create an image object and set its source file.
            Image image = new Image
            {
                File = imagePath
            };
            // Add the image to the header.
            header.Paragraphs.Add(image);

            // ----- Footer -----
            HeaderFooter footer = new HeaderFooter();
            page.Footer = footer;

            // Create a text fragment with page number placeholders.
            TextFragment txt = new TextFragment("Page: ($p of $P ) ");
            // Add the text fragment to the footer.
            footer.Paragraphs.Add(txt);

            // Save the PDF to the output directory.
            string outputPath = Path.Combine(outputDir, "ImageAndPageNumberInHeaderFooter_out.pdf");
            doc.Save(outputPath);

            Console.WriteLine($"PDF created successfully at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}