using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.WorkingDocument;

/// <summary>
/// Demonstrates how to validate a PDF document against the PDF/A-1B standard using Aspose.Pdf.
/// </summary>
public class ValidatePDFABStandard
{
    /// <summary>
    /// Executes the validation example.
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
            string inputPath = Path.Combine(inputDir, "ValidatePDFAStandard.pdf");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Output validation result file.
            string outputPath = Path.Combine(outputDir, "validation-result-A1A.xml");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Validate PDF for PDF/A-1B (as per original example).
            pdfDocument.Validate(outputPath, PdfFormat.PDF_A_1B);

            Console.WriteLine($"Validation completed. Result saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during PDF validation: {ex.Message}");
        }
    }
}