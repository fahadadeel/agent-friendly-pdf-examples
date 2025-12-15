using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Pages;

/// <summary>
/// Demonstrates concatenating two PDF files using Aspose.Pdf.
/// </summary>
public class ConcatenatePdfFiles
{
    /// <summary>
    /// Concatenates two PDF documents and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input directory (data/inputs) relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            // Resolve output directory (data/outputs) and ensure it exists.
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Input file paths
            string firstPdfPath = Path.Combine(inputDir, "Concat1.pdf");
            string secondPdfPath = Path.Combine(inputDir, "Concat2.pdf");

            // Open first document
            Document pdfDocument1 = new Document(firstPdfPath);
            // Open second document
            Document pdfDocument2 = new Document(secondPdfPath);

            // Add pages of second document to the first
            pdfDocument1.Pages.Add(pdfDocument2.Pages);

            // Output file path
            string outputPath = Path.Combine(outputDir, "ConcatenatePdfFiles_out.pdf");

            // Save concatenated output file
            pdfDocument1.Save(outputPath);

            Console.WriteLine($"\nPDFs are concatenated successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF concatenation: {ex.Message}");
        }
    }
}