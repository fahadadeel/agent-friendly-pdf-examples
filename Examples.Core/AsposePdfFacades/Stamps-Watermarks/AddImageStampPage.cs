using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Stamps_Watermarks;

/// <summary>
/// Demonstrates adding an image stamp to a specific page of a PDF using Aspose.Pdf.Facades.
/// </summary>
public class AddImageStampPage
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
        Directory.CreateDirectory(outputDir);

        // Define file names.
        string inputPdf = Path.Combine(inputDir, "AddImageStamp-Page.pdf");
        string inputImage = Path.Combine(inputDir, "aspose-logo.jpg");
        string outputPdf = Path.Combine(outputDir, "AddImageStamp-Page_out.pdf");

        try
        {
            // Create PdfFileStamp object.
            using var fileStamp = new PdfFileStamp();

            // Open the PDF document.
            fileStamp.BindPdf(inputPdf);

            // Create and configure the image stamp.
            var stamp = new Aspose.Pdf.Facades.Stamp(); // AUTOFIX: specify fully qualified type to resolve ambiguity
            stamp.BindImage(inputImage);
            stamp.SetOrigin(200, 200);
            stamp.Rotation = 90.0F;
            stamp.IsBackground = true;
            stamp.Pages = new int[] { 1 };

            // Add the stamp to the PDF.
            fileStamp.AddStamp(stamp);

            // Save the updated PDF.
            fileStamp.Save(outputPdf);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error adding image stamp: {ex.Message}");
        }
    }
}