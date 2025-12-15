using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeNUp;

/// <summary>
/// Demonstrates making N-up PDF using file paths with Aspose.Pdf.Facades.
/// </summary>
public class MakeNUpUsingPaths
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine base directory (application base)
            string baseDir = AppContext.BaseDirectory;

            // Input directory
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            // Output directory
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input file paths
            string inputPath1 = Path.Combine(inputDir, "input.pdf");
            string inputPath2 = Path.Combine(inputDir, "input2.pdf");
            // Output file path
            string outputPath = Path.Combine(outputDir, "MakeNUpUsingPaths_out.pdf");

            // Create PdfFileEditor object
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Make NUp using paths
            pdfEditor.MakeNUp(inputPath1, inputPath2, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during MakeNUpUsingPaths example: {ex.Message}");
        }
    }
}