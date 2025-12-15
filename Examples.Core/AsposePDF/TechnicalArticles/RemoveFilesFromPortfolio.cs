using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.TechnicalArticles;

/// <summary>
/// Demonstrates how to remove files from a PDF portfolio using Aspose.Pdf.
/// </summary>
public class RemoveFilesFromPortfolio
{
    /// <summary>
    /// Executes the example.
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

            // Input PDF portfolio file.
            string inputPath = Path.Combine(inputDir, "PDFPortfolio.pdf");
            // Output PDF without portfolio.
            string outputPath = Path.Combine(outputDir, "No_PortFolio_out.pdf");

            // Load source PDF Portfolio.
            Document pdfDocument = new Document(inputPath);
            // Delete the portfolio collection.
            pdfDocument.Collection.Delete();
            // Save the modified document.
            pdfDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in RemoveFilesFromPortfolio: {ex.Message}");
        }
    }
}