using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using System.Drawing;

namespace Examples.Core.AsposePdfFacades.Stamps_Watermarks;

/// <summary>
/// Demonstrates how to add a header to a PDF document using Aspose.Pdf.Facades.
/// </summary>
public class AddHeader
{
    /// <summary>
    /// Executes the AddHeader example.
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

            // Define full paths for the source PDF and the resulting PDF.
            string inputPath = Path.Combine(inputDir, "AddHeader.pdf");
            string outputPath = Path.Combine(outputDir, "AddHeader_out.pdf");

            // Create PdfFileStamp object and bind the source PDF.
            PdfFileStamp fileStamp = new PdfFileStamp();
            fileStamp.BindPdf(inputPath);

            // Create formatted text for the header.
            FormattedText formattedText = new FormattedText(
                "Aspose - Your File Format Experts!",
                System.Drawing.Color.Blue,
                System.Drawing.Color.Gray,
                Aspose.Pdf.Facades.FontStyle.Courier,
                EncodingType.Winansi,
                false,
                14);

            // Add the header to each page of the document.
            fileStamp.AddHeader(formattedText, 10);

            // Save the updated PDF file.
            fileStamp.Save(outputPath);

            // Close the stamp object.
            fileStamp.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in AddHeader example: {ex.Message}");
        }
    }
}