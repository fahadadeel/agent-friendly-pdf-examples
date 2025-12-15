using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

public class AddTextImagesUsingPdfFileMend
{
    /// <summary>
    /// Demonstrates adding an image and formatted text to a PDF using PdfFileMend.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve data directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputFile = Path.Combine(inputDir, "inFile.pdf");
            string outputFile = Path.Combine(outputDir, "AddTextImagesUsingPdfFileMend_out.pdf");
            string imageFile = Path.Combine(inputDir, "aspose-logo.jpg");

            // Open streams for the image and the output PDF.
            using var inImgStream = new FileStream(imageFile, FileMode.Open, FileAccess.Read);
            using var outputStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write);

            // Load the source PDF document.
            Document doc = new Document(inputFile);

            // Create an instance of PdfFileMend.
            PdfFileMend mendor = new PdfFileMend(doc);

            // Add image to page 1 at the specified location.
            mendor.AddImage(inImgStream, 1, 50, 50, 100, 100);

            // Create formatted text to add.
            FormattedText ft = new FormattedText(
                "PdfFileMend testing! 0 rotation.",
                System.Drawing.Color.FromArgb(0, 200, 0), // TODO: platform-specific API — review and implement with guard
                FontStyle.TimesRoman,
                EncodingType.Winansi,
                false,
                12);

            // Add the formatted text to page 1.
            mendor.AddText(ft, 1, 50, 100, 100, 200);

            // Close the PdfFileMend object.
            mendor.Close();

            // The output stream will be closed automatically by the using statement.
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddTextImagesUsingPdfFileMend: {ex.Message}");
        }
    }
}