using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion.PDFToHTMLFormat;

/// <summary>
/// Demonstrates converting a PDF to HTML with custom font file naming and location.
/// </summary>
public class PrefixForFonts
{
    private static int _fontNumberForUniqueFontFileNames;
    private static string _desiredFontDir;

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
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPdfPath = Path.Combine(inputDir, "input.pdf");
            // Output HTML file.
            string outHtmlFile = Path.Combine(outputDir, "PrefixForFonts_out.html");

            // Directory where custom‑named font files will be written.
            _desiredFontDir = Path.Combine(Path.GetDirectoryName(outHtmlFile) ?? "", "36296_files");
            if (!Directory.Exists(_desiredFontDir))
                Directory.CreateDirectory(_desiredFontDir);

            // Reset counter for unique font file names.
            _fontNumberForUniqueFontFileNames = 0;

            // Load the PDF document.
            Document doc = new Document(inputPdfPath);

            // Configure HTML save options with a custom resource‑saving strategy.
            HtmlSaveOptions saveOptions = new HtmlSaveOptions();
            saveOptions.CustomResourceSavingStrategy = new HtmlSaveOptions.ResourceSavingStrategy(CustomResourcesProcessing);

            // Save the document as HTML.
            doc.Save(outHtmlFile, saveOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // Custom processing for resources referenced in the generated HTML.
    private static string CustomResourcesProcessing(SaveOptions.ResourceSavingInfo resourceSavingInfo)
    {
        // Process only font resources; let the converter handle everything else.
        if (resourceSavingInfo.ResourceType != SaveOptions.NodeLevelResourceType.Font)
        {
            resourceSavingInfo.CustomProcessingCancelled = true;
            return string.Empty;
        }

        // Generate a short, unique font file name.
        _fontNumberForUniqueFontFileNames++;
        string shortFontFileName = _fontNumberForUniqueFontFileNames.ToString() + Path.GetExtension(resourceSavingInfo.SupposedFileName);
        string outFontPath = Path.Combine(_desiredFontDir, shortFontFileName);

        // Write the font bytes to the desired location.
        using var fontBinaryReader = new BinaryReader(resourceSavingInfo.ContentStream);
        byte[] fontBytes = fontBinaryReader.ReadBytes((int)resourceSavingInfo.ContentStream.Length);
        File.WriteAllBytes(outFontPath, fontBytes);

        // Return the URL that will be used in the generated CSS.
        string fontUrl = "http://Localhost:255/document-viewer/GetFont/" + shortFontFileName;
        return fontUrl;
    }
}