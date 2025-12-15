using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates filling a text box field in a PDF form using Aspose.Pdf.
/// </summary>
public class FillFormField
{
    /// <summary>
    /// Fills the text box field named "textbox1" with a value and saves the result.
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
            string inputPath = Path.Combine(inputDir, "FillFormField.pdf");
            string outputPath = Path.Combine(outputDir, "FillFormField_out.pdf");

            // Open document
            Document pdfDocument = new Document(inputPath);

            // Get a field
            if (pdfDocument.Form["textbox1"] is TextBoxField textBoxField)
            {
                // Modify field value
                textBoxField.Value = "Value to be filled in the field";
            }
            else
            {
                Console.WriteLine("The field 'textbox1' was not found or is not a TextBoxField.");
                return;
            }

            // Save updated document
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nForm field filled successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while filling the form: {ex.Message}");
        }
    }
}