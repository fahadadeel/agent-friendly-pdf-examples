using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Working_Document;

/// <summary>
/// Demonstrates how to capture font substitution warnings using Aspose.Pdf.
/// </summary>
public class GetWarningsForFontSubstitution
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "input.pdf");

            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Subscribe to the FontSubstitution event.
            doc.FontSubstitution += OnFontSubstitution;

            // Optional: save the document if further processing is required.
            // string outputPath = Path.Combine(outputDir, "output.pdf");
            // doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in GetWarningsForFontSubstitution: {ex.Message}");
        }
    }

    private static void OnFontSubstitution(Font oldFont, Font newFont)
    {
        // This handler is invoked when Aspose.Pdf substitutes a font.
        Console.WriteLine(string.Format("Font '{0}' was substituted with another font '{1}'",
            oldFont.FontName, newFont.FontName));
    }
}