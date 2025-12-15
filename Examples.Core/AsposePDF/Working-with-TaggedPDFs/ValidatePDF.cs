using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

public class ValidatePDF
{
    /// <summary>
    /// Validates a PDF document against PDF/UA 1.0 standard and writes the validation log.
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

            string inputFilePath = Path.Combine(inputDir, "StructureElements.pdf");
            string outputLogPath = Path.Combine(outputDir, "ua-20.xml");

            // Validate the PDF.
            using var document = new Document(inputFilePath);
            bool isValid = document.Validate(outputLogPath, PdfFormat.PDF_UA_1);

            Console.WriteLine(isValid
                ? $"PDF validation succeeded. Log written to '{outputLogPath}'."
                : $"PDF validation failed. See log at '{outputLogPath}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during PDF validation: {ex.Message}");
        }
    }
}