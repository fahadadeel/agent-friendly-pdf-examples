using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.WorkingDocument;

/// <summary>
/// Demonstrates optimizing a PDF document for web using Aspose.Pdf.
/// </summary>
public class OptimizeDocument
{
    /// <summary>
    /// Optimizes the PDF document and saves the result.
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

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "OptimizeDocument.pdf");
            string outputPath = Path.Combine(outputDir, "OptimizeDocument_out.pdf");

            // Open document.
            Document pdfDocument = new Document(inputPath);

            // Optimize for web.
            pdfDocument.Optimize();

            // Save output document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nDocument optimized successfully for web.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error optimizing document: {ex.Message}");
        }
    }
}