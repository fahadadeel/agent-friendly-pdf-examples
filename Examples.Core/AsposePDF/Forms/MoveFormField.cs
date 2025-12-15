using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates moving a form field within a PDF document using Aspose.Pdf.
/// </summary>
public class MoveFormField
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

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "MoveFormField.pdf");
            string outputPath = Path.Combine(outputDir, "MoveFormField_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Retrieve the text box field named "textbox1".
            TextBoxField textBoxField = pdfDocument.Form["textbox1"] as TextBoxField;
            if (textBoxField == null)
            {
                Console.WriteLine("The field 'textbox1' was not found in the document.");
                return;
            }

            // Modify the field's location.
            textBoxField.Rect = new Rectangle(300, 400, 600, 500);

            // Save the modified document.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nForm field moved successfully to a new location.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while moving the form field: {ex.Message}");
        }
    }
}