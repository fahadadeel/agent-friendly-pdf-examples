using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion.PDFToHTMLFormat;

/// <summary>
/// Demonstrates converting a PDF to HTML while avoiding saving images as separate files.
/// </summary>
public class AvoidSavingImages
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

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            // Output HTML file path.
            string outputPath = Path.Combine(outputDir, "AvoidSavingImages_out.html");

            // Load PDF document.
            Document pdfDocument = new Document(inputPath);

            // Create HtmlSaveOptions with tested feature.
            HtmlSaveOptions saveOptions = new HtmlSaveOptions();
            saveOptions.FixedLayout = true;
            saveOptions.RasterImagesSavingMode = HtmlSaveOptions.RasterImagesSavingModes.AsEmbeddedPartsOfPngPageBackground;

            // Save as HTML.
            pdfDocument.Save(outputPath, saveOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}