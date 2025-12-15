using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;


/// <summary>
/// Demonstrates how to load an SVG file, adjust its page size, set zero margins, and save it as a PDF.
/// </summary>
public class GetSVGDimensions
{
    /// <summary>
    /// Executes the SVG to PDF conversion example.
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

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "GetSVGDimensions.svg");
            string outputPath = Path.Combine(outputDir, "GetSVGDimensions_out.pdf");

            // Load options for SVG conversion.
            var loadopt = new SvgLoadOptions
            {
                AdjustPageSize = true
            };

            // Load the SVG document.
            var svgDoc = new Document(inputPath, loadopt);

            // Set all margins of the first page to zero.
            var page = svgDoc.Pages[1];
            page.PageInfo.Margin.Top = 0;
            page.PageInfo.Margin.Left = 0;
            page.PageInfo.Margin.Bottom = 0;
            page.PageInfo.Margin.Right = 0;

            // Save the resulting PDF.
            svgDoc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during SVG to PDF conversion: {ex.Message}");
        }
    }
}