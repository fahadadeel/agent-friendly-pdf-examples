using System;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Demonstrates converting a PDF to HTML with custom CSS handling using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.DocumentConversion.PDFToHTMLFormat;

public class PrefixToImportDirectives
{
    private static string _folderForReferencedResources_36435;

    /// <summary>
    /// Executes the PDF to HTML conversion example.
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
            string outHtmlFile = Path.Combine(outputDir, "PrefixToImportDirectives_out.html");

            // Set folder for referenced resources (used by CSS saving logic).
            _folderForReferencedResources_36435 = outputDir + Path.DirectorySeparatorChar;

            // Optional: set license if you have one.
            string licenseFile = ""; // e.g., @"F:\_Sources\Aspose.Total.lic"
            if (!string.IsNullOrEmpty(licenseFile) && File.Exists(licenseFile))
            {
                (new Aspose.Pdf.License()).SetLicense(licenseFile);
            }

            // Load the PDF document.
            Document pdfDocument = new Document(inputPdfPath);

            // Configure HTML save options with custom CSS handling.
            HtmlSaveOptions saveOptions = new HtmlSaveOptions();
            saveOptions.CustomStrategyOfCssUrlCreation = new HtmlSaveOptions.CssUrlMakingStrategy(Strategy_10_CSS_ReturnResultPathInPredefinedTestFolder);
            saveOptions.CustomCssSavingStrategy = new HtmlSaveOptions.CssSavingStrategy(Strategy_10_CSS_WriteCssToResourceFolder);

            // Perform the conversion.
            pdfDocument.Save(outHtmlFile, saveOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // Helper method to write CSS content to a resource folder.
    private static void Strategy_10_CSS_WriteCssToResourceFolder(HtmlSaveOptions.CssSavingInfo resourceInfo)
    {
        // Generate a GUID to simulate the placeholder in the URL template.
        string guid = Guid.NewGuid().ToString();

        // Obtain a full URL template and inject the GUID.
        string fullPathWithGuid = Strategy_10_CSS_ReturnResultPathInPredefinedTestFolder(new HtmlSaveOptions.CssUrlRequestInfo());
        fullPathWithGuid = string.Format(fullPathWithGuid, guid);

        // Determine the positions of the GUID within the template.
        int prefixLength = fullPathWithGuid.IndexOf(guid);
        int suffixLength = fullPathWithGuid.Length - (fullPathWithGuid.IndexOf(guid) + guid.Length);

        // Extract the CSS file name part from the requested URL.
        string fullPath = resourceInfo.SupposedURL;
        fullPath = fullPath.Substring(prefixLength);
        string cssFileNameCore = fullPath.Substring(0, fullPath.Length - suffixLength);

        // Build the final CSS file name and path.
        string cssFileName = "style" + cssFileNameCore + ".css";
        string path = Path.Combine(_folderForReferencedResources_36435, cssFileName);

        // Write the CSS bytes to the file.
        using var reader = new BinaryReader(resourceInfo.ContentStream);
        byte[] bytes = reader.ReadBytes((int)resourceInfo.ContentStream.Length);
        File.WriteAllBytes(path, bytes);
    }

    // Helper method that returns a URL template for CSS resources.
    private static string Strategy_10_CSS_ReturnResultPathInPredefinedTestFolder(HtmlSaveOptions.CssUrlRequestInfo requestInfo)
    {
        // The template contains a placeholder {0} that will be replaced with a GUID.
        string template = "http://Localhost:24661/document-viewer/GetResourceForHtmlHandler?documentPath=Deutschland201207Arbeit.pdf&resourcePath=style{0}.css&fileNameOnly=false";
        return template;
    }
}