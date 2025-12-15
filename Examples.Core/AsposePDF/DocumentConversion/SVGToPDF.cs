using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates conversion of an SVG file to PDF using Aspose.Pdf.
/// </summary>
public class SVGToPDF
{
    /// <summary>
    /// Executes the SVG to PDF conversion.
    /// </summary>
    public static void Run()
    {
        // ExStart:SVGToPDF
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Define full paths for the input SVG and the output PDF.
            string inputPath = Path.Combine(inputDir, "SVGToPDF.svg");
            string outputPath = Path.Combine(outputDir, "SVGToPDF_out.pdf");

            // Instantiate LoadOption object using SVG load option.
            LoadOptions loadopt = new SvgLoadOptions();

            // Create Document object from the SVG file.
            Document doc = new Document(inputPath, loadopt);

            // Save the resultant PDF document.
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during SVG to PDF conversion: {ex.Message}");
        }
        // ExEnd:SVGToPDF
    }
}