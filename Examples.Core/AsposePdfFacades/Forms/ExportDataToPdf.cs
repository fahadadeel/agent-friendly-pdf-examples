using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates exporting form data from a PDF to an FDF file using Aspose.Pdf.Facades.
/// </summary>
public class ExportDataToPdf
{
    /// <summary>
    /// Executes the export operation.
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

            // Define file paths.
            string inputPdfPath = Path.Combine(inputDir, "input.pdf");
            string fdfOutputPath = Path.Combine(outputDir, "student.fdf");
            string outputPdfPath = Path.Combine(outputDir, "ExportDataToPdf_out.pdf");

            // Initialize the Form facade.
            var form = new Form();

            // Bind the source PDF document.
            form.BindPdf(inputPdfPath);

            // Export form data to an FDF file.
            using (var fdfStream = new FileStream(fdfOutputPath, FileMode.Create, FileAccess.Write))
            {
                form.ExportFdf(fdfStream);
            }

            // Save the (potentially updated) PDF document.
            form.Save(outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ExportDataToPdf: {ex.Message}");
        }
    }
}