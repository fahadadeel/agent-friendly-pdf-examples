using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion.PDFToHTMLFormat;

public class OutPutToStream
{
    /// <summary>
    /// Demonstrates converting a PDF to a single HTML file using a custom stream saving strategy.
    /// Input PDF is read from <c>data/inputs</c> and all outputs are written to <c>data/outputs</c>.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Input and output file paths
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "OutPutToStream_out.html");

            // Load the PDF document
            Document doc = new Document(inputPath);

            // Tune conversion parameters
            HtmlSaveOptions newOptions = new HtmlSaveOptions
            {
                RasterImagesSavingMode = HtmlSaveOptions.RasterImagesSavingModes.AsEmbeddedPartsOfPngPageBackground,
                FontSavingMode = HtmlSaveOptions.FontSavingModes.SaveInAllFormats,
                PartsEmbeddingMode = HtmlSaveOptions.PartsEmbeddingModes.EmbedAllIntoHtml,
                LettersPositioningMethod = HtmlSaveOptions.LettersPositioningMethods.UseEmUnitsAndCompensationOfRoundingErrorsInCss,
                SplitIntoPages = false // Force write HTMLs of all pages into one output document
            };

            // Use custom HTML saving strategy that writes to a stream
            newOptions.CustomHtmlSavingStrategy = new HtmlSaveOptions.HtmlPageMarkupSavingStrategy(SavingToStream);

            // Save the document using the configured options
            doc.Save(outputPath, newOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // ExStart:SavingToStream
    private static void SavingToStream(HtmlSaveOptions.HtmlPageMarkupSavingInfo htmlSavingInfo)
    {
        try
        {
            // Read the generated HTML content from the provided stream
            byte[] resultHtmlAsBytes = new byte[htmlSavingInfo.ContentStream.Length];
            htmlSavingInfo.ContentStream.Read(resultHtmlAsBytes, 0, resultHtmlAsBytes.Length);

            // Resolve output path for the streamed HTML
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string fileName = Path.Combine(outputDir, "stream_out.html");

            // Write the bytes to the output file
            using Stream outStream = File.OpenWrite(fileName);
            outStream.Write(resultHtmlAsBytes, 0, resultHtmlAsBytes.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in SavingToStream: {ex.Message}");
        }
    }
    // ExEnd:SavingToStream

    // ExStart:OutPutToStreamHelper
    static string _folderForReferencedResources_34748;

    public static void PDFNEWNET_34748()
    {
        try
        {
            // -----------------------------------------------------
            // 1) Tune paths and set license
            // -----------------------------------------------------
            (new Aspose.Pdf.License()).SetLicense(@"F:\_Sources\Aspose_5\trunk\testdata\License\Aspose.Total.lic"); // TODO: adjust license path as needed

            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            Directory.CreateDirectory(outputDir);

            string pdfPath = Path.Combine(inputDir, "34748_36189.pdf");
            string outHtmlFile = Path.Combine(outputDir, "34748.html");
            _folderForReferencedResources_34748 = Path.Combine(outputDir, "out_34748") + Path.DirectorySeparatorChar;

            // -----------------------------------------------------
            // 2) Clean results if they already present
            // -----------------------------------------------------
            if (Directory.Exists(_folderForReferencedResources_34748))
            {
                Directory.Delete(_folderForReferencedResources_34748, true);
            }
            if (File.Exists(outHtmlFile))
            {
                File.Delete(outHtmlFile);
            }

            // -----------------------------------------------------
            // Create HtmlSaveOption with tested feature
            // -----------------------------------------------------
            HtmlSaveOptions saveOptions = new HtmlSaveOptions();
            saveOptions.CustomResourceSavingStrategy = new HtmlSaveOptions.ResourceSavingStrategy(Strategy_11_CUSTOM_SAVE_OF_FONTS_AND_IMAGES);
            saveOptions.CustomCssSavingStrategy = new HtmlSaveOptions.CssSavingStrategy(Strategy_11_CSS_WriteCssToPredefinedFolder);
            saveOptions.CustomStrategyOfCssUrlCreation = new HtmlSaveOptions.CssUrlMakingStrategy(Strategy_11_CSS_ReturnResultPathInPredefinedTestFolder);

            using (Stream outStream = File.OpenWrite(outHtmlFile))
            {
                Document pdfDocument = new Document(pdfPath);
                pdfDocument.Save(outStream, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in PDFNEWNET_34748: {ex.Message}");
        }
    }

    private static void Strategy_11_CSS_WriteCssToPredefinedFolder(HtmlSaveOptions.CssSavingInfo resourceInfo)
    {
        if (!Directory.Exists(_folderForReferencedResources_34748))
        {
            Directory.CreateDirectory(_folderForReferencedResources_34748);
        }
        string path = Path.Combine(_folderForReferencedResources_34748, Path.GetFileName(resourceInfo.SupposedURL));
        using BinaryReader reader = new BinaryReader(resourceInfo.ContentStream);
        File.WriteAllBytes(path, reader.ReadBytes((int)resourceInfo.ContentStream.Length));
    }

    private static string Strategy_11_CSS_ReturnResultPathInPredefinedTestFolder(HtmlSaveOptions.CssUrlRequestInfo requestInfo)
    {
        return "file:///" + _folderForReferencedResources_34748.Replace("\\", "/") + "css_style{0}.css";
    }

    private static string Strategy_11_CUSTOM_SAVE_OF_FONTS_AND_IMAGES(SaveOptions.ResourceSavingInfo resourceSavingInfo)
    {
        if (!Directory.Exists(_folderForReferencedResources_34748))
        {
            Directory.CreateDirectory(_folderForReferencedResources_34748);
        }
        string path = Path.Combine(_folderForReferencedResources_34748, Path.GetFileName(resourceSavingInfo.SupposedFileName));
        using BinaryReader contentReader = new BinaryReader(resourceSavingInfo.ContentStream);
        File.WriteAllBytes(path, contentReader.ReadBytes((int)resourceSavingInfo.ContentStream.Length));
        string urlThatWillBeUsedInHtml = "file:///" + _folderForReferencedResources_34748.Replace("\\", "/") + Path.GetFileName(resourceSavingInfo.SupposedFileName);
        return urlThatWillBeUsedInHtml;
    }
    // ExEnd:OutPutToStreamHelper
}