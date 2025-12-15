using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates conversion of a PDF document to PDF/A-3B format using Aspose.Pdf.
/// </summary>
public class PDFToPDFA3b
{
    /// <summary>
    /// Executes the PDF to PDF/A-3B conversion example.
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

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Convert to PDF/A-3B format.
            pdfDocument.Convert(new MemoryStream(), PdfFormat.PDF_A_3B, ConvertErrorAction.Delete);

            // Output PDF file path.
            string outputPath = Path.Combine(outputDir, "PDFToPDFA3b_out.pdf");

            // Save the converted document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nPDF file converted to PDF/A-3B format.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during conversion: {ex.Message}");
        }
    }
}