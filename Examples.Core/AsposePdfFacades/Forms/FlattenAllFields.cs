using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

public class FlattenAllFields
{
    /// <summary>
    /// Flattens all form fields in a PDF document.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "FlattenAllFields_out.pdf");

            // Validate input file existence.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Initialize the Form facade.
            Form pdfForm = new Form();

            // Open the PDF document.
            pdfForm.BindPdf(inputPath);

            // Flatten all fields.
            pdfForm.FlattenAllFields();

            // Save the modified PDF.
            pdfForm.Save(outputPath);

            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}