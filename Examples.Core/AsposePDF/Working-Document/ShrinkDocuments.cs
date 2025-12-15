using System;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Demonstrates shrinking a PDF document using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Working_Document;

public class ShrinkDocuments
{
    /// <summary>
    /// Executes the shrink document example.
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

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "ShrinkDocument.pdf");
            string outputPath = Path.Combine(outputDir, "ShrinkDocument_out.pdf");

            // Open document.
            Document pdfDocument = new Document(inputPath);

            // Optimize PDF document. Note, though, that this method cannot guarantee document shrinking.
            pdfDocument.OptimizeResources();

            // Save updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nDocument shrinked successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during ShrinkDocuments.Run: {ex.Message}");
        }
    }
}