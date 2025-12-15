using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates how to retrieve the value of a form field from a PDF document using Aspose.Pdf.Facades.
/// </summary>
public class GetFieldValue
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

            // Path to the input PDF file.
            string inputPath = Path.Combine(inputDir, "input.pdf");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open the PDF document and bind it to the Form facade.
            using var pdfForm = new Form();
            pdfForm.BindPdf(inputPath);

            // Retrieve and display the value of the specified form field.
            string fieldValue = pdfForm.GetField("textfield");
            Console.WriteLine($"Field Value : {fieldValue} ");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

// TODO: import or include any additional helper classes (e.g., RunExamples) from the original source if needed.