using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Stamps_Watermarks;

/// <summary>
/// Demonstrates adding an image stamp as a header to each page of a PDF document.
/// </summary>
public class ImageInHeader
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

            // Input file paths.
            string pdfInputPath = Path.Combine(inputDir, "ImageinHeader.pdf");
            string imageInputPath = Path.Combine(inputDir, "aspose-logo.jpg");

            // Output file path.
            string pdfOutputPath = Path.Combine(outputDir, "ImageinHeader_out.pdf");

            // Open the PDF document.
            using var pdfDocument = new Document(pdfInputPath);

            // Create the image stamp.
            var imageStamp = new ImageStamp(imageInputPath)
            {
                TopMargin = 10,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };

            // Add the stamp to each page.
            foreach (Page page in pdfDocument.Pages)
            {
                page.AddStamp(imageStamp);
            }

            // Save the updated document.
            pdfDocument.Save(pdfOutputPath);

            Console.WriteLine($"\nImage in header added successfully.\nFile saved at {pdfOutputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding the image header: {ex.Message}");
        }
    }
}