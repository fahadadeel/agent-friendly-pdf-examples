using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates how to modify a form field in a PDF document using Aspose.Pdf.
/// </summary>
public class ModifyFormField
{
    /// <summary>
    /// Modifies the value of a text box field and saves the updated PDF.
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "ModifyFormField.pdf");
            string outputPath = Path.Combine(outputDir, "ModifyFormField_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Get the text box field named "textbox1".
            if (pdfDocument.Form["textbox1"] is TextBoxField textBoxField)
            {
                // Modify field value and set it to read‑only.
                textBoxField.Value = "New Value";
                textBoxField.ReadOnly = true;
            }
            else
            {
                Console.WriteLine("The field 'textbox1' was not found in the document.");
                return;
            }

            // Save the updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nForm field modified successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while modifying the form field: {ex.Message}");
        }
    }
}