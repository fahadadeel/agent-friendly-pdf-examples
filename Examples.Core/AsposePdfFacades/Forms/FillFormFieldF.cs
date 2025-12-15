using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates filling a form field in a PDF using Aspose.Pdf.Facades.
/// </summary>
public class FillFormFieldF
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "FormField.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "FillFormFieldF_out.pdf");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Create Form object.
            Form pdfForm = new Form();

            // Open the PDF document.
            pdfForm.BindPdf(inputPath);

            // Fill the field "textfield" with "Mike".
            pdfForm.FillField("textfield", "Mike");

            // Save the updated PDF.
            pdfForm.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in FillFormFieldF.Run: {ex.Message}");
        }
    }
}