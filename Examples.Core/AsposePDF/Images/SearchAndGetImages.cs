using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates how to search for images in a PDF document and retrieve their placement properties using Aspose.Pdf.
/// </summary>
public class SearchAndGetImages
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input directory and PDF file path.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string pdfPath = Path.Combine(inputDir, "SearchAndGetImages.pdf");

            if (!File.Exists(pdfPath))
            {
                Console.Error.WriteLine($"Input file not found: {pdfPath}");
                return;
            }

            // Open the PDF document.
            Document doc = new Document(pdfPath);

            // Create an absorber to find image placements.
            ImagePlacementAbsorber absorber = new ImagePlacementAbsorber();

            // Accept the absorber for all pages.
            doc.Pages.Accept(absorber);

            // Iterate through found image placements and display their properties.
            foreach (ImagePlacement imagePlacement in absorber.ImagePlacements)
            {
                // Retrieve the image (not used further here, but shown for completeness).
                XImage image = imagePlacement.Image;

                Console.Out.WriteLine("image width:" + imagePlacement.Rectangle.Width);
                Console.Out.WriteLine("image height:" + imagePlacement.Rectangle.Height);
                Console.Out.WriteLine("image LLX:" + imagePlacement.Rectangle.LLX);
                Console.Out.WriteLine("image LLY:" + imagePlacement.Rectangle.LLY);
                Console.Out.WriteLine("image horizontal resolution:" + imagePlacement.Resolution.X);
                Console.Out.WriteLine("image vertical resolution:" + imagePlacement.Resolution.Y);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}