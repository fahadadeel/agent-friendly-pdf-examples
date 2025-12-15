using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

public class HTMLToPDF
{
    /// <summary>
    /// Converts an HTML file to PDF using a custom resource loader.
    /// </summary>
    public static void Run()
    {
        try
        {
            // ExStart:HTMLToPDF
            // Resolve input and output directories.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            HtmlLoadOptions options = new HtmlLoadOptions();
            options.CustomLoaderOfExternalResources = new LoadOptions.ResourceLoadingStrategy(SamePictureLoader);

            string inputFile = Path.Combine(inputDir, "HTMLToPDF.html");
            Document pdfDocument = new Document(inputFile, options);

            string outputFile = Path.Combine(outputDir, "HTMLToPDF_out.pdf");
            pdfDocument.Save(outputFile);
            // ExEnd:HTMLToPDF
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // ExStart:HTMLToPDFHelper
    private static LoadOptions.ResourceLoadingResult SamePictureLoader(string resourceURI)
    {
        string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
        string logoPath = Path.Combine(inputDir, "aspose-logo.jpg");
        byte[] resultBytes = File.ReadAllBytes(logoPath);
        LoadOptions.ResourceLoadingResult result = new LoadOptions.ResourceLoadingResult(resultBytes);
        return result;
    }
    // ExEnd:HTMLToPDFHelper

    /// <summary>
    /// Renders HTML content to a single PDF page.
    /// </summary>
    public static void RenderContentToSamePage()
    {
        // ExStart:RenderContentToSamePage
        string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
        string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
        Directory.CreateDirectory(outputDir);

        HtmlLoadOptions options = new HtmlLoadOptions
        {
            IsRenderToSinglePage = true
        };

        string inputFile = Path.Combine(inputDir, "HTMLToPDF.html");
        Document doc = new Document(inputFile, options);

        string outputFile = Path.Combine(outputDir, "RenderContentToSamePage.pdf");
        doc.Save(outputFile);
        // ExEnd:RenderContentToSamePage
    }

    /// <summary>
    /// Renders HTML containing SVG data to PDF.
    /// </summary>
    public static void RenderHTMLwithSVGData()
    {
        // ExStart:RenderHTMLwithSVGData
        string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
        string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
        Directory.CreateDirectory(outputDir);

        string inFile = Path.Combine(inputDir, "HTMLSVG.html");
        string outFile = Path.Combine(outputDir, "RenderHTMLwithSVGData.pdf");

        HtmlLoadOptions options = new HtmlLoadOptions(Path.GetDirectoryName(inFile));
        Document pdfDocument = new Document(inFile, options);
        pdfDocument.Save(outFile);
        // ExEnd:RenderHTMLwithSVGData
    }
}