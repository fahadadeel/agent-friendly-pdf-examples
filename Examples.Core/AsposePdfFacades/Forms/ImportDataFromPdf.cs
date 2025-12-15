using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates importing data from an FDF file into a PDF document using Aspose.Pdf.Facades.
/// </summary>
public class ImportDataFromPdf
{
    /// <summary>
    /// Executes the import operation.
    /// </summary>
    public static void Run()
    {
        // ExStart:ImportDataFromPdf
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Define file paths.
            string pdfPath = Path.Combine(inputDir, "input.pdf");
            string fdfPath = Path.Combine(inputDir, "student.fdf");
            string outputPdfPath = Path.Combine(outputDir, "ImportDataFromPdf_out.pdf");

            // Initialize the Form facade.
            var form = new Aspose.Pdf.Facades.Form();

            // Open the PDF document.
            form.BindPdf(pdfPath);

            // Open the FDF file stream.
            using var fdfInputStream = new FileStream(fdfPath, FileMode.Open, FileAccess.Read);

            // Import data from the FDF stream into the PDF.
            form.ImportFdf(fdfInputStream);

            // Save the updated PDF document.
            form.Save(outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ImportDataFromPdf: {ex.Message}");
        }
        // ExEnd:ImportDataFromPdf
    }
}