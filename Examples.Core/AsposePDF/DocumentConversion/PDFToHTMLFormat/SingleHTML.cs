using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion.PDFToHTMLFormat;

/// <summary>
/// Demonstrates converting a PDF document to a single HTML file with all resources embedded.
/// </summary>
public class SingleHTML
{
    /// <summary>
    /// Executes the PDF‑to‑HTML conversion example.
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

            // Input PDF file path.
            string inputPdfPath = Path.Combine(inputDir, "input.pdf");
            if (!File.Exists(inputPdfPath))
            {
                Console.WriteLine($"Input file not found: {inputPdfPath}");
                return;
            }

            // Load source PDF file.
            Document doc = new Document(inputPdfPath);

            // Instantiate HTML save options.
            HtmlSaveOptions htmlOptions = new HtmlSaveOptions
            {
                // Embed all resources (images, fonts, CSS) directly into the HTML.
                PartsEmbeddingMode = HtmlSaveOptions.PartsEmbeddingModes.EmbedAllIntoHtml,

                // Optimization for IE – can be omitted if not needed.
                LettersPositioningMethod = HtmlSaveOptions.LettersPositioningMethods.UseEmUnitsAndCompensationOfRoundingErrorsInCss,

                // Save raster images as embedded PNG background parts.
                RasterImagesSavingMode = HtmlSaveOptions.RasterImagesSavingModes.AsEmbeddedPartsOfPngPageBackground,

                // Preserve fonts in all supported formats.
                FontSavingMode = HtmlSaveOptions.FontSavingModes.SaveInAllFormats
            };

            // Output HTML file path.
            string outputHtmlPath = Path.Combine(outputDir, "SingleHTML_out.html");

            // Save the document as a single HTML file.
            doc.Save(outputHtmlPath, htmlOptions);

            Console.WriteLine($"Conversion completed. Output saved to: {outputHtmlPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during PDF to HTML conversion: {ex.Message}");
        }
    }
}