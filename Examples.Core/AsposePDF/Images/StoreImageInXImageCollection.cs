using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Operators;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates storing an image in the XImage collection and drawing it on a PDF page.
/// </summary>
public class StoreImageInXImageCollection
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        try
        {
            Directory.CreateDirectory(outputDir);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to create output directory '{outputDir}': {ex.Message}");
            return;
        }

        string inputImagePath = Path.Combine(inputDir, "aspose-logo.jpg");
        string outputPdfPath = Path.Combine(outputDir, "FlateDecodeCompression.pdf");

        try
        {
            // Initialize a new PDF document with a single page.
            Document document = new Document();
            document.Pages.Add();
            Page page = document.Pages[1];

            // Load the image stream and add it to the page resources using Flate compression.
            using (FileStream imageStream = new FileStream(inputImagePath, FileMode.Open, FileAccess.Read))
            {
                page.Resources.Images.Add(imageStream, ImageFilterType.Flate);
                XImage ximage = page.Resources.Images[page.Resources.Images.Count];

                // Begin content stream.
                page.Contents.Add(new GSave());

                // Define the rectangle where the image will be placed.
                int lowerLeftX = 0;
                int lowerLeftY = 0;
                int upperRightX = 600;
                int upperRightY = 600;
                Rectangle rectangle = new Rectangle(lowerLeftX, lowerLeftY, upperRightX, upperRightY);

                // Create a transformation matrix for positioning the image.
                Matrix matrix = new Matrix(new double[]
                {
                    rectangle.URX - rectangle.LLX,
                    0,
                    0,
                    rectangle.URY - rectangle.LLY,
                    rectangle.LLX,
                    rectangle.LLY
                });

                // Apply the matrix and draw the image.
                page.Contents.Add(new ConcatenateMatrix(matrix));
                page.Contents.Add(new Do(ximage.Name));

                // End content stream.
                page.Contents.Add(new GRestore());

                // Save the PDF document.
                document.Save(outputPdfPath);
            }

            Console.WriteLine($"PDF saved to: {outputPdfPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while processing the PDF: {ex.Message}");
        }
    }
}