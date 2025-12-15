using System;
using System.Collections;
using System.IO;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

/// <summary>
/// Demonstrates various features of <see cref="PdfExtractor"/> such as text, image, and attachment extraction.
/// </summary>
public class PdfExtractorFeatures
{
    /// <summary>
    /// Executes the PDF extraction example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Input PDF file.
        string inputPdfPath = Path.Combine(inputDir, "inFile.pdf");

        if (!File.Exists(inputPdfPath))
        {
            Console.Error.WriteLine($"Input PDF not found: {inputPdfPath}");
            return;
        }

        try
        {
            // Create an instance of PdfExtractor class.
            PdfExtractor extractor = new PdfExtractor();

            // Set PDF file password (empty if none).
            extractor.Password = string.Empty;

            // Specify start and end pages of the PDF.
            extractor.StartPage = 1;
            extractor.EndPage = 10;

            // Bind PDF file with the extractor object.
            extractor.BindPdf(inputPdfPath);

            // -------------------- Text Extraction --------------------
            extractor.ExtractText();

            // Save extracted text in a text file.
            string textOutputPath = Path.Combine(outputDir, "PdfExtractorFeatures_text_out.txt");
            extractor.GetText(textOutputPath);

            // Text of individual pages can also be saved individually in separate text files.
            if (extractor.HasNextPageText())
            {
                string pageTextPath = Path.Combine(outputDir, $"{DateTime.Now.Ticks}_out.txt");
                extractor.GetNextPageText(pageTextPath);
            }

            // -------------------- Image Extraction --------------------
            extractor.ExtractImage();

            // Save each individual image in an image file.
            if (extractor.HasNextImage())
            {
                string imageOutputPath = Path.Combine(outputDir, $"{DateTime.Now.Ticks}_out.jpg");
                extractor.GetNextImage(imageOutputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            // -------------------- Attachment Extraction --------------------
            extractor.ExtractAttachment();

            // Extract all attachments to the output directory.
            extractor.GetAttachment(outputDir);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during PDF extraction: {ex.Message}");
        }
    }
}