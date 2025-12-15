using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Stamps_Watermarks;

/// <summary>
/// Demonstrates how to add an image footer to a PDF document using Aspose.Pdf.Facades.
/// </summary>
public class AddImageFooter
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

            // Input file paths.
            string pdfPath = Path.Combine(inputDir, "AddImage-Footer.pdf");
            string imagePath = Path.Combine(inputDir, "aspose-logo.jpg");

            // Output file path.
            string outputPath = Path.Combine(outputDir, "AddImage-Footer_out.pdf");

            // Create PdfFileStamp object.
            var fileStamp = new PdfFileStamp();

            // Open the PDF document.
            fileStamp.BindPdf(pdfPath);

            // Add footer image. The second parameter is the vertical offset from the bottom.
            using var imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            fileStamp.AddFooter(imageStream, 10);

            // Save the updated PDF.
            fileStamp.Save(outputPath);

            // Close the stamp object.
            fileStamp.Close();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddImageFooter.Run: {ex.Message}");
        }
    }
}