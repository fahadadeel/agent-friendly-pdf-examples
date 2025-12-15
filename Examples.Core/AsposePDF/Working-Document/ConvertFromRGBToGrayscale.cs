using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.WorkingDocument;

/// <summary>
/// Demonstrates converting all RGB images in a PDF document to grayscale using Aspose.Pdf.
/// </summary>
public class ConvertFromRGBToGrayscale
{
    /// <summary>
    /// Executes the conversion example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "Test-gray_out.pdf");

            // Load source PDF file.
            using Document document = new Document(inputPath);

            // Create the conversion strategy.
            RgbToDeviceGrayConversionStrategy strategy = new RgbToDeviceGrayConversionStrategy();

            // Apply the strategy to each page.
            for (int idxPage = 1; idxPage <= document.Pages.Count; idxPage++)
            {
                Page page = document.Pages[idxPage];
                strategy.Convert(page);
            }

            // Save the resultant file.
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during ConvertFromRGBToGrayscale execution: {ex.Message}");
        }
    }
}