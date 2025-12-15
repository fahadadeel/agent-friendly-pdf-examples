using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Stamps_Watermarks;

public class AddImageHeader
{
    /// <summary>
    /// Adds an image header to a PDF document.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base, input, and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Define file paths.
            string inputPdfPath = Path.Combine(inputDir, "AddImage-Header.pdf");
            string headerImagePath = Path.Combine(inputDir, "AddImageHeader.jpg");
            string outputPdfPath = Path.Combine(outputDir, "AddImage-Header_out.pdf");

            // Create PdfFileStamp object.
            PdfFileStamp fileStamp = new PdfFileStamp();

            // Open the source PDF document.
            fileStamp.BindPdf(inputPdfPath);

            // Add the header image.
            using (FileStream imageStream = new FileStream(headerImagePath, FileMode.Open, FileAccess.Read))
            {
                fileStamp.AddHeader(imageStream, 10);
            }

            // Save the updated PDF.
            fileStamp.Save(outputPdfPath);

            // Close the stamp object.
            fileStamp.Close();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddImageHeader.Run: {ex.Message}");
        }
    }
}