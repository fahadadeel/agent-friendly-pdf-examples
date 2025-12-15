using System;
using System.IO;
using Aspose.Pdf;
using System.Drawing.Imaging;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates extracting an image from a PDF using Aspose.Pdf.
/// </summary>
public class ExtractImages
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine base directories.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input PDF path.
            string inputPdfPath = Path.Combine(inputDir, "ExtractImages.pdf");
            if (!File.Exists(inputPdfPath))
            {
                Console.WriteLine($"Input PDF not found at '{inputPdfPath}'.");
                return;
            }

            // Open document.
            Document pdfDocument = new Document(inputPdfPath);

            // Extract a particular image (first page, first image).
            XImage xImage = pdfDocument.Pages[1].Resources.Images[1];

            // Output image path.
            string outputImagePath = Path.Combine(outputDir, "output.jpg");

            // Save output image.
            using (FileStream outputImage = new FileStream(outputImagePath, FileMode.Create, FileAccess.Write))
            {
                xImage.Save(outputImage, ImageFormat.Jpeg);
            }

            // Output PDF path.
            string outputPdfPath = Path.Combine(outputDir, "ExtractImages_out.pdf");

            // Save updated PDF file.
            pdfDocument.Save(outputPdfPath);

            Console.WriteLine("\nImages extracted successfully.\nFile saved at " + outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during image extraction: {ex.Message}");
        }
    }
}