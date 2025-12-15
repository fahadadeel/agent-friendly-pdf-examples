using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

public class PDFAToPDF
{
    /// <summary>
    /// Demonstrates removing PDF/A compliance information from a PDF/A document and saving the result.
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

            string inputPath = Path.Combine(inputDir, "PDFAToPDF.pdf");
            string outputPath = Path.Combine(outputDir, "PDFAToPDF_out.pdf");

            // Open document
            Document doc = new Document(inputPath);

            // Remove PDF/A compliance information
            doc.RemovePdfaCompliance();

            // Save updated document
            doc.Save(outputPath);

            Console.WriteLine($"Document processed successfully. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error processing PDF/A document: {ex.Message}");
        }
    }
}