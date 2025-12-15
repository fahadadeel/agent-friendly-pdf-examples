using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Working_Document;

/// <summary>
/// Demonstrates how to validate a PDF document against the PDF/UA standard using Aspose.Pdf.
/// </summary>
public class ValidatePDFUAStandard
{
    /// <summary>
    /// Runs the validation example.
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

            // Input PDF file.
            string inputPdfPath = Path.Combine(inputDir, "ValidatePDFUAStandard.pdf");
            // Output validation result file.
            string validationResultPath = Path.Combine(outputDir, "validation-result-UA.xml");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPdfPath);

            // Validate PDF for PDF/UA.
            bool isValidPdfUa = pdfDocument.Validate(validationResultPath, PdfFormat.PDF_UA_1);

            Console.WriteLine($"PDF/UA validation result: {(isValidPdfUa ? "Valid" : "Invalid")}");
            Console.WriteLine($"Validation report saved to: {validationResultPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during PDF/UA validation: {ex.Message}");
        }
    }
}