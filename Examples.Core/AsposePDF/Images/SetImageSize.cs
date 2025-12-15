using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates how to set an image size within a PDF document using Aspose.Pdf.
/// </summary>
public class SetImageSize
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

            // Path to the source image file.
            string imagePath = Path.Combine(inputDir, "aspose-logo.jpg");
            if (!File.Exists(imagePath))
            {
                Console.WriteLine($"Input image not found at '{imagePath}'.");
                return;
            }

            // Create a new PDF document.
            Document doc = new Document();

            // Add a page to the document.
            Page page = doc.Pages.Add();

            // Create an image instance and configure its size.
            Image img = new Image
            {
                FixWidth = 100,
                FixHeight = 100,
                // Set image type as Unknown (covers formats like JPEG, PNG, etc.).
                FileType = ImageFileType.Unknown,
                // Assign the image file.
                File = imagePath
            };

            // Add the image to the page.
            page.Paragraphs.Add(img);

            // Set page dimensions.
            page.PageInfo.Width = 800;
            page.PageInfo.Height = 800;

            // Define the output PDF file path.
            string outputPath = Path.Combine(outputDir, "SetImageSize_out.pdf");

            // Save the PDF document.
            doc.Save(outputPath);

            Console.WriteLine($"\nImage size added successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}