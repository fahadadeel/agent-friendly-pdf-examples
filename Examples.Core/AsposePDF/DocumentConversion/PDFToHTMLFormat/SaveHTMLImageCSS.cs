using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion.PDFToHTMLFormat;

/// <summary>
/// Demonstrates converting a PDF to HTML with custom image, CSS and resource handling.
/// </summary>
public class SaveHTMLImageCSS
{
    /// <summary>
    /// Executes the PDF‑to‑HTML conversion example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base path.
            string baseDir = Path.Combine(AppContext.BaseDirectory, "data");
            string inputDir = Path.Combine(baseDir, "inputs");
            string outputDir = Path.Combine(baseDir, "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPdf = Path.Combine(inputDir, "input.pdf");
            // Output HTML file.
            string outHtmlFile = Path.Combine(outputDir, "SaveHTMLImageCSS_out.html");

            // Load the PDF document.
            Document doc = new Document(inputPdf);

            // Configure HTML save options with custom strategies.
            HtmlSaveOptions saveOptions = new HtmlSaveOptions
            {
                SplitIntoPages = true,
                CustomHtmlSavingStrategy = new HtmlSaveOptions.HtmlPageMarkupSavingStrategy(StrategyOfSavingHtml),
                CustomResourceSavingStrategy = new HtmlSaveOptions.ResourceSavingStrategy(CustomSaveOfFontsAndImages),
                CustomStrategyOfCssUrlCreation = new HtmlSaveOptions.CssUrlMakingStrategy(CssUrlMakingStrategy),
                CustomCssSavingStrategy = new HtmlSaveOptions.CssSavingStrategy(CustomSavingOfCss),
                FontSavingMode = HtmlSaveOptions.FontSavingModes.SaveInAllFormats,
                RasterImagesSavingMode = HtmlSaveOptions.RasterImagesSavingModes.AsEmbeddedPartsOfPngPageBackground
            };

            // Save the document as HTML using the configured options.
            doc.Save(outHtmlFile, saveOptions);

            Console.WriteLine("Done");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // ExStart:SaveHTMLImageCSSHelper
    private static void StrategyOfSavingHtml(HtmlSaveOptions.HtmlPageMarkupSavingInfo htmlSavingInfo)
    {
        // Get target file name and write content to it
        using var reader = new BinaryReader(htmlSavingInfo.ContentStream);
        byte[] htmlAsByte = reader.ReadBytes((int)htmlSavingInfo.ContentStream.Length);
        Console.WriteLine("Html page processed with handler. Length of page's text in bytes is " + htmlAsByte.Length);

        // Example: store HTML content to a memory stream (could be a DB, file system, etc.)
        using var targetStream = new MemoryStream();
        targetStream.Write(htmlAsByte, 0, htmlAsByte.Length);
    }

    private static string CssUrlMakingStrategy(HtmlSaveOptions.CssUrlRequestInfo requestInfo)
    {
        string template = "style{0}.css";
        // Example of a remote template:
        // string template = "http://localhost:24661/document-viewer/GetResourceForHtmlHandler?documentPath=sample.pdf&resourcePath=style{0}.css&fileNameOnly=false";
        return template;
    }

    private static void CustomSavingOfCss(HtmlSaveOptions.CssSavingInfo resourceInfo)
    {
        using var reader = new BinaryReader(resourceInfo.ContentStream);
        byte[] cssAsBytes = reader.ReadBytes((int)resourceInfo.ContentStream.Length);
        Console.WriteLine("Css page processed with handler. Length of css in bytes is " + cssAsBytes.Length);

        // Example: store CSS content to a memory stream (could be a DB, file system, etc.)
        using var targetStream = new MemoryStream();
        targetStream.Write(cssAsBytes, 0, cssAsBytes.Length);
    }

    private static string CustomSaveOfFontsAndImages(SaveOptions.ResourceSavingInfo resourceSavingInfo)
    {
        using var reader = new BinaryReader(resourceSavingInfo.ContentStream);
        byte[] resourceAsBytes = reader.ReadBytes((int)resourceSavingInfo.ContentStream.Length);

        if (resourceSavingInfo.ResourceType == SaveOptions.NodeLevelResourceType.Font)
        {
            Console.WriteLine("Font processed with handler. Length of content in bytes is " + resourceAsBytes.Length);
            // Example: store font data to a memory stream (could be a DB, file system, etc.)
            using var targetStream = new MemoryStream();
            targetStream.Write(resourceAsBytes, 0, resourceAsBytes.Length);
        }
        else if (resourceSavingInfo.ResourceType == SaveOptions.NodeLevelResourceType.Image)
        {
            Console.WriteLine("Image processed with handler. Length of content in bytes is " + resourceAsBytes.Length);
            // Example: store image data to a memory stream (could be a DB, file system, etc.)
            using var targetStream = new MemoryStream();
            targetStream.Write(resourceAsBytes, 0, resourceAsBytes.Length);
        }

        // Return the file name (or a URI) that will be referenced in the generated CSS/HTML.
        return resourceSavingInfo.SupposedFileName;
    }
    // ExEnd:SaveHTMLImageCSSHelper
}