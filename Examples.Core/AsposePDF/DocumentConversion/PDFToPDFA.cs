using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates converting a PDF document to PDF/A-1b compliance using Aspose.Pdf.
/// </summary>
public class PDFToPDFA
{
    /// <summary>
    /// Executes the PDF to PDF/A conversion example.
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
            {
                Directory.CreateDirectory(outputDir);
            }

            // Input PDF file.
            string inputPdfPath = Path.Combine(inputDir, "PDFToPDFA.pdf");
            if (!File.Exists(inputPdfPath))
            {
                Console.WriteLine($"Input file not found: {inputPdfPath}");
                return;
            }

            // Open the PDF document.
            Document pdfDocument = new Document(inputPdfPath);

            // Path for the conversion log.
            string logPath = Path.Combine(outputDir, "log.xml");

            // Convert to PDF/A-1b compliant document.
            // During conversion process, the validation is also performed.
            pdfDocument.Convert(logPath, PdfFormat.PDF_A_1B, ConvertErrorAction.Delete);

            // Output PDF/A file.
            string outputPdfPath = Path.Combine(outputDir, "PDFToPDFA_out.pdf");
            pdfDocument.Save(outputPdfPath);

            Console.WriteLine($"\nPDF file converted to PDF/A-1b compliant PDF.\nFile saved at {outputPdfPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during PDF to PDF/A conversion: {ex.Message}");
        }
    }
}