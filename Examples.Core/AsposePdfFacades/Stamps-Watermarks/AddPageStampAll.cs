using System;
using System.IO;
using Aspose.Pdf.Facades; // AUTOFIX: Removed ambiguous using Aspose.Pdf;

namespace Examples.Core.AsposePdfFacades.Stamps_Watermarks;

/// <summary>
/// Demonstrates adding a stamp to every page of a PDF using Aspose.Pdf.Facades.
/// </summary>
public class AddPageStampAll
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

        // Define file paths.
        string sourcePdfPath = Path.Combine(inputDir, "AddPageStampAll.pdf");
        string stampPdfPath = Path.Combine(inputDir, "temp.pdf");
        string outputPdfPath = Path.Combine(outputDir, "AddPageStampAll_out.pdf");

        try
        {
            // Create PdfFileStamp object.
            using var fileStamp = new PdfFileStamp();

            // Open the source document.
            fileStamp.BindPdf(sourcePdfPath);

            // Create a stamp from the second PDF (first page).
            var stamp = new Stamp(); // Uses Aspose.Pdf.Facades.Stamp
            stamp.BindPdf(stampPdfPath, 1);
            stamp.SetOrigin(200, 200);
            stamp.Rotation = 90.0F;
            stamp.IsBackground = true;

            // Add the stamp to all pages of the source PDF.
            fileStamp.AddStamp(stamp);

            // Save the updated PDF.
            fileStamp.Save(outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error processing PDF: {ex.Message}");
        }
    }
}