using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.StampsWatermarks;

/// <summary>
/// Demonstrates adding a page stamp to a PDF using Aspose.Pdf.Facades.
/// </summary>
public class AddPageStampPage
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

        // Input and output file paths.
        string inputPdfPath = Path.Combine(inputDir, "AddPageStamp-Page.pdf");
        string stampPdfPath = Path.Combine(inputDir, "temp.pdf");
        string outputPdfPath = Path.Combine(outputDir, "AddPageStamp-Page_out.pdf");

        try
        {
            // Create PdfFileStamp object.
            using var fileStamp = new PdfFileStamp();

            // Open the source PDF document.
            fileStamp.BindPdf(inputPdfPath);

            // Create a stamp from another PDF page.
            var stamp = new Aspose.Pdf.Facades.Stamp(); // Fully qualified to avoid ambiguity
            stamp.BindPdf(stampPdfPath, 1);
            stamp.SetOrigin(200, 200);
            stamp.Rotation = 90.0F;
            stamp.IsBackground = true;

            // Apply the stamp only to page 2.
            stamp.Pages = new[] { 2 };

            // Add the stamp to the source PDF.
            fileStamp.AddStamp(stamp);

            // Save the updated PDF.
            fileStamp.Save(outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF stamping: {ex.Message}");
        }
    }
}