using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;

/// <summary>
/// Demonstrates conversion of a dynamic XFA form to a standard AcroForm using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Forms;

public class DynamicXFAToAcroForm
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

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "DynamicXFAToAcroForm.pdf");
            string outputPath = Path.Combine(outputDir, "Standard_AcroForm_out.pdf");

            // Load dynamic XFA form.
            Document document = new Document(inputPath);

            // Set the form fields type as standard AcroForm.
            document.Form.Type = FormType.Standard;

            // Save the resultant PDF.
            document.Save(outputPath);

            Console.WriteLine($"\nDynamic XFA form converted to standard AcroForm successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during DynamicXFAToAcroForm execution: {ex.Message}");
        }
    }
}