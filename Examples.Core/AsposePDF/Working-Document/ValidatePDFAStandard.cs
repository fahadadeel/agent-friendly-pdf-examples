using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.WorkingDocument;

public class ValidatePDFAStandard
{
    /// <summary>
    /// Validates a PDF file against the PDF/A-1a standard and writes the validation result to an XML file.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory ?? Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Input PDF file.
            string inputPdfPath = Path.Combine(inputDir, "ValidatePDFAStandard.pdf");
            // Output validation result file.
            string outputXmlPath = Path.Combine(outputDir, "validation-result-A1A.xml");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPdfPath);

            // Validate PDF for PDF/A-1a and write the result.
            pdfDocument.Validate(outputXmlPath, PdfFormat.PDF_A_1A);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF/A validation: {ex.Message}");
        }
    }
}