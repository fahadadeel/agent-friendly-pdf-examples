using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Stamps_Watermarks;

/// <summary>
/// Demonstrates adding an image stamp as a footer to each page of a PDF document.
/// </summary>
public class ImageInFooter
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
            {
                Directory.CreateDirectory(outputDir);
            }

            // Input file names.
            string inputPdfPath = Path.Combine(inputDir, "ImageInFooter.pdf");
            string inputImagePath = Path.Combine(inputDir, "aspose-logo.jpg");

            // Validate input files exist.
            if (!File.Exists(inputPdfPath))
            {
                Console.WriteLine($"Input PDF not found: {inputPdfPath}");
                return;
            }

            if (!File.Exists(inputImagePath))
            {
                Console.WriteLine($"Input image not found: {inputImagePath}");
                return;
            }

            // Open the PDF document.
            Document pdfDocument = new Document(inputPdfPath);

            // Create the image stamp for the footer.
            ImageStamp imageStamp = new ImageStamp(inputImagePath)
            {
                BottomMargin = 10,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom
            };

            // Add the stamp to every page.
            foreach (Page page in pdfDocument.Pages)
            {
                page.AddStamp(imageStamp);
            }

            // Define the output file path.
            string outputPdfPath = Path.Combine(outputDir, "ImageInFooter_out.pdf");

            // Save the updated PDF.
            pdfDocument.Save(outputPdfPath);

            Console.WriteLine($"\nImage in footer added successfully.\nFile saved at {outputPdfPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding the image footer: {ex.Message}");
        }
    }
}