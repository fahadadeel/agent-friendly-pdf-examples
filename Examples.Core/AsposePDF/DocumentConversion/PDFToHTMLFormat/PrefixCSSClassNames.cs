using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion.PDFToHTMLFormat;

public class PrefixCSSClassNames
{
    /// <summary>
    /// Converts a PDF document to HTML with prefixed CSS class names.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "PrefixCSSClassNames_out.html");

            // Load the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Set HTML save options with CSS class name prefix.
            HtmlSaveOptions saveOptions = new HtmlSaveOptions();
            saveOptions.CssClassNamesPrefix = ".gDV__ .stl_";

            // Save the document as HTML.
            pdfDocument.Save(outputPath, saveOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}