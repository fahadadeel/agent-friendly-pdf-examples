using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

public class PDFToHTML
{
    /// <summary>
    /// Converts a PDF document to HTML.
    /// </summary>
    public static void Run()
    {
        try
        {
            string inputPath = GetInputPath("PDFToHTML.pdf");
            string outputPath = GetOutputPath("output_out.html");

            // Open the source PDF document
            Document pdfDocument = new Document(inputPath);

            // Save the file into HTML format
            pdfDocument.Save(outputPath, SaveFormat.Html);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Run failed: {ex.Message}");
        }
    }

    public static void ExcludeFontResources()
    {
        try
        {
            string inputPath = GetInputPath("PDFToHTML.pdf");
            string outputPath = GetOutputPath("ExcludeFontResources.html");

            HtmlSaveOptions htmlOptions = new HtmlSaveOptions
            {
                ExplicitListOfSavedPages = new[] { 1 },
                FixedLayout = true,
                CompressSvgGraphicsIfAny = false,
                SaveTransparentTexts = true,
                SaveShadowedTextsAsTransparentTexts = true,
                // FontSavingMode = HtmlSaveOptions.FontSavingModes.DontSave,
                ExcludeFontNameList = new[] { "ArialMT", "SymbolMT" },
                DefaultFontName = "Comic Sans MS",
                UseZOrder = true,
                LettersPositioningMethod = HtmlSaveOptions.LettersPositioningMethods.UseEmUnitsAndCompensationOfRoundingErrorsInCss,
                PartsEmbeddingMode = HtmlSaveOptions.PartsEmbeddingModes.NoEmbedding,
                RasterImagesSavingMode = HtmlSaveOptions.RasterImagesSavingModes.AsEmbeddedPartsOfPngPageBackground,
                SplitIntoPages = false
            };

            Document pdfDocument = new Document(inputPath);
            pdfDocument.Save(outputPath, htmlOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"ExcludeFontResources failed: {ex.Message}");
        }
    }

    public static void MultiPageHTML()
    {
        try
        {
            string inputPath = GetInputPath("PDFToHTML.pdf");
            string outputPath = GetOutputPath("MultiPageHTML_out.html");

            Document pdfDocument = new Document(inputPath);
            HtmlSaveOptions htmlOptions = new HtmlSaveOptions
            {
                SplitIntoPages = true
            };

            pdfDocument.Save(outputPath, htmlOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"MultiPageHTML failed: {ex.Message}");
        }
    }

    public static void SaveSVGFiles()
    {
        try
        {
            string inputPath = GetInputPath("PDFToHTML.pdf");
            string outputPath = GetOutputPath("SaveSVGFiles_out.html");

            Document doc = new Document(inputPath);
            HtmlSaveOptions newOptions = new HtmlSaveOptions
            {
                SpecialFolderForSvgImages = GetOutputPath(string.Empty) // folder for SVG images
            };

            doc.Save(outputPath, newOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"SaveSVGFiles failed: {ex.Message}");
        }
    }

    public static void CompressSVGImages()
    {
        try
        {
            string inputPath = GetInputPath("PDFToHTML.pdf");
            string outputPath = GetOutputPath("CompressSVGImages_out.html");

            Document doc = new Document(inputPath);
            HtmlSaveOptions newOptions = new HtmlSaveOptions
            {
                CompressSvgGraphicsIfAny = true
            };

            doc.Save(outputPath, newOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"CompressSVGImages failed: {ex.Message}");
        }
    }

    public static void SpecifyingImageFolder()
    {
        try
        {
            string inputPath = GetInputPath("PDFToHTML.pdf");
            string outputPath = GetOutputPath("SpecifyingImageFolder_out.html");

            Document doc = new Document(inputPath);
            HtmlSaveOptions newOptions = new HtmlSaveOptions
            {
                SpecialFolderForAllImages = GetOutputPath(string.Empty) // folder for all images
            };

            doc.Save(outputPath, newOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"SpecifyingImageFolder failed: {ex.Message}");
        }
    }

    public static void CreateSubsequentFiles()
    {
        try
        {
            string inputPath = GetInputPath("PDFToHTML.pdf");
            string outputPath = GetOutputPath("CreateSubsequentFiles_out.html");

            Document doc = new Document(inputPath);
            HtmlSaveOptions options = new HtmlSaveOptions
            {
                HtmlMarkupGenerationMode = HtmlSaveOptions.HtmlMarkupGenerationModes.WriteOnlyBodyContent,
                SplitIntoPages = true
            };

            doc.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"CreateSubsequentFiles failed: {ex.Message}");
        }
    }

    public static void TransparentTextRendering()
    {
        try
        {
            string inputPath = GetInputPath("PDFToHTML.pdf");
            string outputPath = GetOutputPath("TransparentTextRendering_out.html");

            Document doc = new Document(inputPath);
            HtmlSaveOptions htmlOptions = new HtmlSaveOptions
            {
                SaveShadowedTextsAsTransparentTexts = true,
                SaveTransparentTexts = true
            };

            doc.Save(outputPath, htmlOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"TransparentTextRendering failed: {ex.Message}");
        }
    }

    public static void LayersRendering()
    {
        try
        {
            string inputPath = GetInputPath("PDFToHTML.pdf");
            string outputPath = GetOutputPath("LayersRendering_out.html");

            Document doc = new Document(inputPath);
            HtmlSaveOptions htmlOptions = new HtmlSaveOptions
            {
                ConvertMarkedContentToLayers = true
            };

            doc.Save(outputPath, htmlOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"LayersRendering failed: {ex.Message}");
        }
    }

    public static void CreatingHtmlWithFullContentWidth()
    {
        try
        {
            string inputPath = GetInputPath("FlowLayoutParagraphFullWidth.Pdf");
            string outputPath = GetOutputPath("FlowLayoutParagraphFullWidth_out.html");

            HtmlSaveOptions saveOptions = new HtmlSaveOptions
            {
                FixedLayout = false,
                FlowLayoutParagraphFullWidth = true
            };

            Document doc = new Document(inputPath);
            doc.Save(outputPath, saveOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"CreatingHtmlWithFullContentWidth failed: {ex.Message}");
        }
    }

    public static void CenterAlignText()
    {
        // This method demonstrates configuration only; no file I/O is performed.
        HtmlSaveOptions htmlOptions = new HtmlSaveOptions();

        var commonMargin = new SaveOptions.MarginPartStyle(20);
        var autoMargin = new SaveOptions.MarginPartStyle(true);

        htmlOptions.PageMarginIfAny = new HtmlSaveOptions.MarginInfo(commonMargin);
        htmlOptions.PageMarginIfAny.LeftMarginIfAny = autoMargin;
        htmlOptions.PageMarginIfAny.RightMarginIfAny = autoMargin;
    }

    private static string GetInputPath(string fileName)
    {
        string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
        return Path.Combine(inputDir, fileName);
    }

    private static string GetOutputPath(string fileName)
    {
        string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
        Directory.CreateDirectory(outputDir);
        return Path.Combine(outputDir, fileName);
    }
}

// TODO: import or include helper class RunExamples from original source if needed.