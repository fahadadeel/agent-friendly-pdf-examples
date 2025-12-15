using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion.PDFToHTMLFormat;

public class SplitCSSToPages
{
    /// <summary>
    /// Demonstrates converting a PDF to HTML with split CSS pages and custom CSS saving strategy.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories relative to the application base path.
            string baseDataDir = Path.Combine(AppContext.BaseDirectory, "data");
            string inputDir = Path.Combine(baseDataDir, "inputs");
            string outputDir = Path.Combine(baseDataDir, "outputs");

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            // Paths for input PDF and output HTML.
            string inputPdfPath = Path.Combine(inputDir, "input.pdf");
            string htmlFile = Path.Combine(outputDir, "resultant.html");

            // Directories that Aspose will create for images and CSS files.
            string imagesDir = Path.Combine(Path.GetDirectoryName(htmlFile) ?? outputDir, "35942_files");
            string cssDir = Path.Combine(Path.GetDirectoryName(htmlFile) ?? outputDir, "35942_css_files");

            // Clean-up target folders if they already exist.
            if (Directory.Exists(imagesDir))
            {
                Directory.Delete(imagesDir, true);
            }

            if (Directory.Exists(cssDir))
            {
                Directory.Delete(cssDir, true);
            }

            // Load the PDF document.
            Document pdfDocument = new Document(inputPdfPath);

            // Configure HTML save options.
            HtmlSaveOptions options = new HtmlSaveOptions
            {
                RasterImagesSavingMode = HtmlSaveOptions.RasterImagesSavingModes.AsPngImagesEmbeddedIntoSvg,
                SplitIntoPages = true,
                SplitCssIntoPages = true,
                CustomCssSavingStrategy = new HtmlSaveOptions.CssSavingStrategy(Strategy_4_CSS_MULTIPAGE_SAVING_RIGHT_WAY),
                CustomStrategyOfCssUrlCreation = new HtmlSaveOptions.CssUrlMakingStrategy(Strategy_5_CSS_MAKING_CUSTOM_URL_FOR_MULTIPAGING)
            };

            // Perform the conversion.
            pdfDocument.Save(htmlFile, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // Helper method for custom CSS saving strategy.
    private static void Strategy_4_CSS_MULTIPAGE_SAVING_RIGHT_WAY(HtmlSaveOptions.CssSavingInfo partSavingInfo)
    {
        // Resolve output directory for CSS files.
        string baseDataDir = Path.Combine(AppContext.BaseDirectory, "data");
        string outputDir = Path.Combine(baseDataDir, "outputs");

        string outPath = Path.Combine(outputDir, $"style_xyz_page{partSavingInfo.CssNumber}.css");

        using var reader = new BinaryReader(partSavingInfo.ContentStream);
        byte[] bytes = reader.ReadBytes((int)partSavingInfo.ContentStream.Length);
        File.WriteAllBytes(outPath, bytes);
    }

    // Helper method for custom CSS URL creation strategy.
    private static string Strategy_5_CSS_MAKING_CUSTOM_URL_FOR_MULTIPAGING(HtmlSaveOptions.CssUrlRequestInfo requestInfo)
    {
        return "/document-viewer/GetCss?cssId=4544554445_page{0}";
    }
}