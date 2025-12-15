using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates how to replace an image in a PDF document using Aspose.Pdf.
/// </summary>
public class ReplaceImage
{
    /// <summary>
    /// Executes the image replacement example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Define file paths.
        string inputPdfPath = Path.Combine(inputDir, "ReplaceImage.pdf");
        string inputImagePath = Path.Combine(inputDir, "aspose-logo.jpg");
        string outputPdfPath = Path.Combine(outputDir, "ReplaceImage_out.pdf");

        try
        {
            // Open the PDF document.
            Document pdfDocument = new Document(inputPdfPath);

            // Replace a particular image (image index 1) on the first page.
            using FileStream imageStream = new FileStream(inputImagePath, FileMode.Open, FileAccess.Read);
            pdfDocument.Pages[1].Resources.Images.Replace(1, imageStream);

            // Save the updated PDF file.
            pdfDocument.Save(outputPdfPath);

            Console.WriteLine("\nImage replaced successfully.\nFile saved at " + outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during image replacement: {ex.Message}");
        }
    }
}

// TODO: import or include any additional helper classes referenced in the original source, if required.