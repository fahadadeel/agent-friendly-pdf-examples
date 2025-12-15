using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Pages;

/// <summary>
/// Demonstrates adding an image as a page background using Aspose.Pdf.
/// </summary>
public class ImageAsBackground
{
    /// <summary>
    /// Runs the example.
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

            string inputImagePath = Path.Combine(inputDir, "aspose-total-for-net.jpg");
            string outputPdfPath = Path.Combine(outputDir, "ImageAsBackground_out.pdf");

            // Verify that the input image exists.
            if (!File.Exists(inputImagePath))
            {
                Console.WriteLine($"Input image not found at '{inputImagePath}'.");
                return;
            }

            // Create a new Document object.
            Document doc = new Document();

            // Add a new page to the document.
            Page page = doc.Pages.Add();

            // Create a BackgroundArtifact object.
            BackgroundArtifact background = new BackgroundArtifact();

            // Open the image stream and assign it as the background image.
            FileStream imageStream = File.OpenRead(inputImagePath);
            background.BackgroundImage = imageStream;

            // Add the background artifact to the page's artifacts collection.
            page.Artifacts.Add(background);

            // Save the document to the output path.
            doc.Save(outputPdfPath);

            // Dispose the image stream after saving.
            imageStream.Dispose();

            Console.WriteLine("\nImage as page background added successfully.\nFile saved at " + outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in ImageAsBackground example: {ex.Message}");
        }
    }
}