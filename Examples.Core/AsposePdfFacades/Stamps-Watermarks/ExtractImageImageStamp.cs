using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Stamps_Watermarks;

/// <summary>
/// Demonstrates how to extract an image from an image stamp on the first page of a PDF document
/// using Aspose.Pdf.Facades.
/// </summary>
public class ExtractImageImageStamp
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

            // Define full paths for the input PDF and the extracted image.
            string inputPath = Path.Combine(inputDir, "ExtractImage-ImageStamp.pdf");
            string outputPath = Path.Combine(outputDir, "image_out.jpg");

            // Instantiate PdfContentEditor.
            PdfContentEditor pdfContentEditor = new PdfContentEditor();

            // Bind the input PDF file.
            pdfContentEditor.BindPdf(inputPath);

            // Retrieve stamp information for the first page (page number 1).
            StampInfo[] infos = pdfContentEditor.GetStamps(1);

            // Extract the image from the first stamp, if available.
            if (infos != null && infos.Length > 0 && infos[0].Image != null)
            {
                System.Drawing.Image image = infos[0].Image;
                image.Save(outputPath);
                Console.WriteLine($"Image extracted and saved to: {outputPath}");
            }
            else
            {
                Console.WriteLine("No image stamp found on the first page.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}