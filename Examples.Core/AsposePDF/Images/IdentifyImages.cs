using System;
using System.IO;
using Aspose.Pdf;
using System.Drawing.Imaging;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates how to identify grayscale and RGB images within a PDF document using Aspose.Pdf.
/// </summary>
public class IdentifyImages
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve base directories
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure output directory exists
        try
        {
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to create output directory: {ex.Message}");
            return;
        }

        // Input PDF file
        string inputPath = Path.Combine(inputDir, "ExtractImages.pdf");
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        // Counters for image types
        int grayscaled = 0;
        int rgd = 0;

        try
        {
            using Document document = new Document(inputPath);
            foreach (Page page in document.Pages)
            {
                Console.WriteLine("--------------------------------");
                ImagePlacementAbsorber absorber = new ImagePlacementAbsorber();
                page.Accept(absorber);

                Console.WriteLine(
                    "Total Images = {0} over page number {1}",
                    absorber.ImagePlacements.Count,
                    page.Number);

                int imageCounter = 1;
                foreach (ImagePlacement placement in absorber.ImagePlacements)
                {
                    ColorType colorType = placement.Image.GetColorType();
                    switch (colorType)
                    {
                        case ColorType.Grayscale:
                            ++grayscaled;
                            Console.WriteLine($"Image {imageCounter} is GrayScale...");
                            break;
                        case ColorType.Rgb:
                            ++rgd;
                            Console.WriteLine($"Image {imageCounter} is RGB...");
                            break;
                        default:
                            // Other color types are ignored for this example
                            break;
                    }

                    imageCounter++;
                }
            }

            Console.WriteLine($"Summary: Grayscale images = {grayscaled}, RGB images = {rgd}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while processing the PDF: {ex.Message}");
        }
    }
}