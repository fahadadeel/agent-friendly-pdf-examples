using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

public class PdfContainsTextOrImages
{
    /// <summary>
    /// Demonstrates how to determine whether a PDF contains text, images, both, or neither.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve the input PDF path relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string inputPath = Path.Combine(inputDir, "FilledForm.pdf");

            // Ensure the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (not used in this example but created per requirements).
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            using var ms = new MemoryStream();
            var extractor = new PdfExtractor();

            // Bind the input PDF document to the extractor.
            extractor.BindPdf(inputPath);

            // Extract text.
            extractor.ExtractText();
            extractor.GetText(ms);
            bool containsText = ms.Length >= 1;

            // Extract images.
            extractor.ExtractImage();
            bool containsImage = extractor.HasNextImage();

            // Report the result.
            if (containsText && !containsImage)
                Console.WriteLine("PDF contains text only");
            else if (!containsText && containsImage)
                Console.WriteLine("PDF contains image only");
            else if (containsText && containsImage)
                Console.WriteLine("PDF contains both text and image");
            else
                Console.WriteLine("PDF contains neither text nor image");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing PDF: {ex.Message}");
        }
    }
}