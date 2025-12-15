using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion.PDFToHTMLFormat;

/// <summary>
/// Demonstrates PDF to HTML conversion with various font saving options using Aspose.Pdf.
/// </summary>
public class SaveFonts
{
    /// <summary>
    /// Executes the example that saves fonts as TTF during PDF to HTML conversion.
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

            // Input PDF file.
            string inputPdfPath = Path.Combine(inputDir, "input.pdf");

            // Output HTML file.
            string outFile = Path.Combine(outputDir, "36192_out.html");

            // Load the source PDF document.
            Document doc = new Document(inputPdfPath);

            // Create HtmlSaveOptions with the required settings.
            HtmlSaveOptions saveOptions = new HtmlSaveOptions
            {
                FixedLayout = true,
                SplitIntoPages = false,
                FontSavingMode = HtmlSaveOptions.FontSavingModes.AlwaysSaveAsTTF
            };

            // Determine the folder where linked files (fonts, images, etc.) will be stored.
            string linkedFilesFolder = Path.Combine(Path.GetDirectoryName(outFile) ?? string.Empty, "36192_files");

            // Remove the folder if it already exists to ensure a clean output.
            if (Directory.Exists(linkedFilesFolder))
            {
                Directory.Delete(linkedFilesFolder, true);
            }

            // Save the PDF as HTML using the configured options.
            doc.Save(outFile, saveOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void WOFFFormat()
    {
        // Create HtmlSaveOption with tested feature
        HtmlSaveOptions saveOptions = new HtmlSaveOptions();
        // ExStart:WOFFFormat
        saveOptions.FontSavingMode = HtmlSaveOptions.FontSavingModes.AlwaysSaveAsWOFF;
        // ExEnd:WOFFFormat
        // Note: This method demonstrates setting the WOFF font saving mode.
        // The saveOptions instance can be used with Document.Save as needed.
    }

    /// <summary>
    /// Demonstrates saving fonts in all supported formats with additional HTML conversion settings.
    /// </summary>
    public static void ThreeSetFonts()
    {
        try
        {
            // Resolve input and output directories.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            Directory.CreateDirectory(outputDir);

            string inputPdfPath = Path.Combine(inputDir, "input.pdf");
            string outputHtmlPath = Path.Combine(outputDir, "ThreeSetFonts_out.html");

            Document doc = new Document(inputPdfPath);
            HtmlSaveOptions htmlOptions = new HtmlSaveOptions
            {
                FixedLayout = true,
                RasterImagesSavingMode = HtmlSaveOptions.RasterImagesSavingModes.AsExternalPngFilesReferencedViaSvg,
                FontSavingMode = HtmlSaveOptions.FontSavingModes.SaveInAllFormats
            };

            doc.Save(outputHtmlPath, htmlOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.