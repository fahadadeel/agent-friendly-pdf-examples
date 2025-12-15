using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates exporting form data to XFDF and saving the updated PDF using Aspose.Pdf.Facades.
/// </summary>
public class ExportDataToXFDF
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Define file paths.
            string inputPdfPath = Path.Combine(inputDir, "input.pdf");
            string xfdfOutputPath = Path.Combine(outputDir, "student1.xfdf");
            string outputPdfPath = Path.Combine(outputDir, "ExportDataToXFDF_out.pdf");

            // Load the PDF document.
            var form = new Form();
            form.BindPdf(inputPdfPath);

            // Export form data to XFDF.
            using (var xfdfStream = new FileStream(xfdfOutputPath, FileMode.Create, FileAccess.Write))
            {
                form.ExportXfdf(xfdfStream);
            }

            // Save the updated PDF document.
            form.Save(outputPdfPath);

            Console.WriteLine("Export completed successfully.");
            Console.WriteLine($"XFDF file saved to: {xfdfOutputPath}");
            Console.WriteLine($"Updated PDF saved to: {outputPdfPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during ExportDataToXFDF execution: {ex.Message}");
        }
    }
}