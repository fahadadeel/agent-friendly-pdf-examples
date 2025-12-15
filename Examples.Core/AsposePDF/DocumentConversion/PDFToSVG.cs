using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates converting a PDF document to SVG using Aspose.Pdf.
/// </summary>
public class PDFToSVG
{
    /// <summary>
    /// Executes the PDF to SVG conversion.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Define full paths for the input PDF and the output SVG.
        string inputPath = Path.Combine(inputDir, "input.pdf");
        string outputPath = Path.Combine(outputDir, "PDFToSVG_out.svg");

        try
        {
            // Load PDF document.
            Document doc = new Document(inputPath);

            // Instantiate an object of SvgSaveOptions.
            SvgSaveOptions saveOptions = new SvgSaveOptions
            {
                // Do not compress SVG image to Zip archive.
                CompressOutputToZipArchive = false
            };

            // Save the output in an SVG file.
            doc.Save(outputPath, saveOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF to SVG conversion: {ex.Message}");
        }
    }
}