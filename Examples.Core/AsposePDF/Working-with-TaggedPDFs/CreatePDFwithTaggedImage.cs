using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using System;
using System.IO;

namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

public class CreatePDFWithTaggedImage
{
    /// <summary>
    /// Creates a PDF document containing a tagged image.
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
            string imagePath = Path.Combine(inputDir, "aspose-logo.png");
            if (!File.Exists(imagePath))
            {
                Console.Error.WriteLine($"Input image not found: {imagePath}");
                return;
            }

            // Output PDF path.
            string outputPdfPath = Path.Combine(outputDir, "PDFwithTaggedImage.pdf");

            // Create a new PDF document.
            Document document = new Document();
            ITaggedContent taggedContent = document.TaggedContent;

            // Set document metadata.
            taggedContent.SetTitle("CreatePDFwithTaggedImage");
            taggedContent.SetLanguage("en-US");

            // Create a figure element and configure its properties.
            IllustrationElement figure1 = taggedContent.CreateFigureElement();
            taggedContent.RootElement.AppendChild(figure1);
            figure1.AlternativeText = "Aspose Logo";
            figure1.Title = "Image 1";
            figure1.SetTag("Fig");

            // Add the image (300 DPI by default).
            figure1.SetImage(imagePath);

            // Save the PDF document.
            document.Save(outputPdfPath);

            Console.WriteLine($"PDF created successfully at: {outputPdfPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}