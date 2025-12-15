using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion.PDFToHTMLFormat;

/// <summary>
/// Demonstrates saving a PDF as HTML with images extracted as external PNG files referenced via SVG.
/// </summary>
public class SaveImages
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

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            // Output HTML file path.
            string outputPath = Path.Combine(outputDir, "SaveImages_out.html");

            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Configure HTML save options.
            HtmlSaveOptions saveOptions = new HtmlSaveOptions
            {
                FixedLayout = true,
                SplitIntoPages = false,
                RasterImagesSavingMode = HtmlSaveOptions.RasterImagesSavingModes.AsExternalPngFilesReferencedViaSvg
            };

            // Save the document as HTML.
            doc.Save(outputPath, saveOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}