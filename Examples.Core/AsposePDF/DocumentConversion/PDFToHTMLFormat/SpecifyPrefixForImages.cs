using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion.PDFToHTMLFormat;

public class SpecifyPrefixForImages
{
    /// <summary>
    /// Converts a PDF to HTML while specifying a custom prefix for images.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories relative to the application base path.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outFile = Path.Combine(outputDir, "SpecifyImages_out.html");

            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Create HtmlSaveOptions with custom resource saving strategy.
            HtmlSaveOptions saveOptions = new HtmlSaveOptions
            {
                SplitIntoPages = false,
                CustomResourceSavingStrategy = new HtmlSaveOptions.ResourceSavingStrategy(SavingTestStrategy_1)
            };

            // Save the document as HTML.
            doc.Save(outFile, saveOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // ExStart:SpecifyPrefixForImagesHelper
    private static string SavingTestStrategy_1(SaveOptions.ResourceSavingInfo resourceSavingInfo)
    {
        // This sample method saving strategy saves only SVG files in a specific folder
        // and returns a custom path to be used in the generated HTML.
        // All other resources are processed by the converter itself.

        // Resolve base directories.
        string baseDir = AppContext.BaseDirectory;
        string outputDir = Path.Combine(baseDir, "data", "outputs");
        string outFile = Path.Combine(outputDir, "SpecifyImages_out.html");

        if (!(resourceSavingInfo is HtmlSaveOptions.HtmlImageSavingInfo))
        {
            resourceSavingInfo.CustomProcessingCancelled = true;
            return string.Empty;
        }

        HtmlSaveOptions.HtmlImageSavingInfo asHtmlImageSavingInfo =
            (HtmlSaveOptions.HtmlImageSavingInfo)resourceSavingInfo;

        if (asHtmlImageSavingInfo.ImageType != HtmlSaveOptions.HtmlImageType.Svg &&
            asHtmlImageSavingInfo.ImageType != HtmlSaveOptions.HtmlImageType.ZippedSvg)
        {
            resourceSavingInfo.CustomProcessingCancelled = true;
            return string.Empty;
        }

        // Determine the folder where SVG images will be stored.
        string imageOutFolder = Path.GetFullPath(
            Path.Combine(Path.GetDirectoryName(outFile) ?? string.Empty, "35956_svg_files"));

        if (!Directory.Exists(imageOutFolder))
        {
            Directory.CreateDirectory(imageOutFolder);
        }

        // Write the image bytes to the target folder.
        string outPath = Path.Combine(imageOutFolder, Path.GetFileName(resourceSavingInfo.SupposedFileName));

        using (BinaryReader reader = new BinaryReader(resourceSavingInfo.ContentStream))
        {
            byte[] bytes = reader.ReadBytes((int)resourceSavingInfo.ContentStream.Length);
            File.WriteAllBytes(outPath, bytes);
        }

        // Return a custom URL that can be used in the generated HTML.
        return "/document-viewer/GetImage?path=CRWU-NDWAC-Final-Report-12-09-10-2.pdf&name=" +
               resourceSavingInfo.SupposedFileName;
    }
    // ExEnd:SpecifyPrefixForImagesHelper
}