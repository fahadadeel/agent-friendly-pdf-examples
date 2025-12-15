using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Images;

/// <summary>
/// Demonstrates replacing an image in a PDF using Aspose.Pdf.Facades.
/// </summary>
public class ReplaceImage
{
    /// <summary>
    /// Executes the ReplaceImage example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine the application base directory.
            string baseDir = AppContext.BaseDirectory;

            // Resolve input and output directories.
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Define file paths.
            string inputPdfPath = Path.Combine(inputDir, "ReplaceImage.pdf");
            string imagePath = Path.Combine(inputDir, "aspose-logo.jpg");
            string outputPdfPath = Path.Combine(outputDir, "ReplaceImage_out.pdf");

            // Open the input PDF.
            PdfContentEditor pdfContentEditor = new PdfContentEditor();
            pdfContentEditor.BindPdf(inputPdfPath);

            // Replace the image on page 1, image index 1.
            pdfContentEditor.ReplaceImage(1, 1, imagePath);

            // Save the modified PDF.
            pdfContentEditor.Save(outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ReplaceImage example: {ex.Message}");
        }
    }
}