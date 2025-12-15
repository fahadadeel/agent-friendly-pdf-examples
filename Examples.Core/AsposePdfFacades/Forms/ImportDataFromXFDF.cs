using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates importing XFDF data into a PDF using Aspose.Pdf.Facades.Form.
/// </summary>
public class ImportDataFromXFDF
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPdfPath = Path.Combine(inputDir, "input.pdf");
            string xfdfPath = Path.Combine(inputDir, "student1.xfdf");
            string outputPdfPath = Path.Combine(outputDir, "ImportDataFromXFDF_out.pdf");

            // Initialize the Form facade.
            var form = new Form();

            // Bind the PDF document.
            form.BindPdf(inputPdfPath);

            // Import XFDF data.
            using var xfdfStream = new FileStream(xfdfPath, FileMode.Open, FileAccess.Read);
            form.ImportXfdf(xfdfStream);

            // Save the updated PDF.
            form.Save(outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ImportDataFromXFDF: {ex.Message}");
        }
    }
}