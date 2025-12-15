using System;
using System.IO;
using System.Drawing;
using Aspose.Pdf;
using AsposeImage = Aspose.Pdf.Image;

/// <summary>
/// Demonstrates setting page orientation based on image dimensions using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.DocumentConversion;

public class PageOrientationAccordingImageDimensions
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

            // Create a new PDF document.
            Document doc = new Document();

            // Retrieve names of all the JPG files in the input directory.
            string[] fileEntries = Directory.GetFiles(inputDir, "*.JPG");

            for (int i = 0; i < fileEntries.Length; i++)
            {
                // Add a new page to the document.
                Page page = doc.Pages.Add();

                // Create an Aspose.Pdf.Image object and set its source file.
                AsposeImage image = new AsposeImage
                {
                    File = fileEntries[i]
                };

                // Load the image to obtain its dimensions.
                using Bitmap bitmap = new Bitmap(fileEntries[i]);

                // Determine orientation based on image width vs page width.
                if (bitmap.Width > page.PageInfo.Width)
                {
                    page.PageInfo.IsLandscape = true;
                }
                else
                {
                    page.PageInfo.IsLandscape = false;
                }

                // Add the image to the page.
                page.Paragraphs.Add(image);
            }

            // Save the PDF file to the output directory.
            string outputPath = Path.Combine(outputDir, "SetPageOrientation_out.pdf");
            doc.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF conversion: {ex.Message}");
        }
    }
}