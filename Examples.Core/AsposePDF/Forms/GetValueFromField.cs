using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates retrieving values from form fields and submit button URLs using Aspose.Pdf.
/// </summary>
public class GetValueFromField
{
    /// <summary>
    /// Reads a PDF form and writes field information to the console.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input directory relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            // Ensure the directory exists.
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDir}");
                return;
            }

            string pdfPath = Path.Combine(inputDir, "GetValueFromField.pdf");
            if (!File.Exists(pdfPath))
            {
                Console.Error.WriteLine($"Input file not found: {pdfPath}");
                return;
            }

            // Open document
            Document pdfDocument = new Document(pdfPath);

            // Get a field
            if (pdfDocument.Form["textbox1"] is TextBoxField textBoxField)
            {
                // Get field value
                Console.WriteLine("PartialName : {0} ", textBoxField.PartialName);
                Console.WriteLine("Value : {0} ", textBoxField.Value);
            }
            else
            {
                Console.WriteLine("Field 'textbox1' not found or not a TextBoxField.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in Run: {ex.Message}");
        }
    }

    /// <summary>
    /// Retrieves the URL associated with a submit button in the PDF form.
    /// </summary>
    public static void GetSubmitButtonURL()
    {
        try
        {
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string pdfPath = Path.Combine(inputDir, "GetValueFromField.pdf");
            if (!File.Exists(pdfPath))
            {
                Console.Error.WriteLine($"Input file not found: {pdfPath}");
                return;
            }

            // Open document
            Document pdfDocument = new Document(pdfPath);

            // Assuming the second form field is a submit button.
            // Access by index; ensure the index exists.
            if (pdfDocument.Form.Count > 1 && pdfDocument.Form[1].OnActivated is SubmitFormAction act && act != null)
            {
                Console.WriteLine(act.Url.Name);
            }
            else
            {
                Console.WriteLine("Submit button action not found at index 1.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in GetSubmitButtonURL: {ex.Message}");
        }
    }
}