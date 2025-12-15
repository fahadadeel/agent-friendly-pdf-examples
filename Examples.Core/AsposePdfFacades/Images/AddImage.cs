using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Images;

/// <summary>
/// Demonstrates adding an image to a PDF using Aspose.Pdf.Facades.
/// </summary>
public class AddImage
{
    /// <summary>
    /// Runs the AddImage example.
    /// </summary>
    public static void Run()
    {
        // ExStart:AddImage
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Input file paths.
            string inputPdfPath = Path.Combine(inputDir, "AddImage.pdf");
            string imagePath = Path.Combine(inputDir, "aspose-logo.jpg");

            // Output file path.
            string outputPdfPath = Path.Combine(outputDir, "AddImage_out.pdf");

            // Open document using PdfFileMend.
            PdfFileMend mender = new PdfFileMend();

            // Bind the existing PDF.
            mender.BindPdf(inputPdfPath);

            // Add image to the PDF.
            // Parameters: image file path, page number, lower-left X, lower-left Y, upper-right X, upper-right Y
            mender.AddImage(imagePath, 1, 100, 600, 200, 700);

            // Save the modified PDF.
            mender.Save(outputPdfPath);

            // Close the PdfFileMend object.
            mender.Close();

            Console.WriteLine($"Image added successfully. Output saved to: {outputPdfPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddImage example: {ex.Message}");
        }
        // ExEnd:AddImage
    }
}