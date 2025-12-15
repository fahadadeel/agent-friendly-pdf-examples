using System;
using System.IO;
using Aspose.Pdf;
using System.Drawing;
using System.Drawing.Imaging;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates how to extract image placements from a PDF document using Aspose.Pdf.
/// </summary>
public class ImagePlacements
{
    /// <summary>
    /// Runs the image placement extraction example.
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

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "ImagePlacement.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the source PDF document.
            Document doc = new Document(inputPath);
            ImagePlacementAbsorber absorber = new ImagePlacementAbsorber();

            // Extract image placements from the first page.
            doc.Pages[1].Accept(absorber);

            int imageIndex = 0;
            foreach (ImagePlacement imagePlacement in absorber.ImagePlacements)
            {
                // Output image placement properties.
                Console.Out.WriteLine("image width: " + imagePlacement.Rectangle.Width);
                Console.Out.WriteLine("image height: " + imagePlacement.Rectangle.Height);
                Console.Out.WriteLine("image LLX: " + imagePlacement.Rectangle.LLX);
                Console.Out.WriteLine("image LLY: " + imagePlacement.Rectangle.LLY);
                Console.Out.WriteLine("image horizontal resolution: " + imagePlacement.Resolution.X);
                Console.Out.WriteLine("image vertical resolution: " + imagePlacement.Resolution.Y);

                // Retrieve image with visible dimensions.
                Bitmap scaledImage;
                using (MemoryStream imageStream = new MemoryStream())
                {
                    // Save the extracted image to a memory stream in PNG format.
                    imagePlacement.Image.Save(imageStream, ImageFormat.Png);
                    imageStream.Position = 0;

                    // Load the image from the stream.
                    using Bitmap resourceImage = (Bitmap)Bitmap.FromStream(imageStream);

                    // Create a bitmap with the actual dimensions of the placement rectangle.
                    scaledImage = new Bitmap(resourceImage,
                        (int)imagePlacement.Rectangle.Width,
                        (int)imagePlacement.Rectangle.Height);
                }

                // Optional: save the scaled image to the output directory.
                string outputPath = Path.Combine(outputDir, $"scaled_image_{imageIndex}.png");
                try
                {
                    scaledImage.Save(outputPath, ImageFormat.Png);
                    Console.Out.WriteLine($"Scaled image saved to: {outputPath}");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Failed to save scaled image: {ex.Message}");
                }
                finally
                {
                    scaledImage.Dispose();
                }

                imageIndex++;
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.