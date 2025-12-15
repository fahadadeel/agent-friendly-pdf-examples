using System;
using System.Collections;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates how to retrieve button option values and the current selected value from a PDF form using Aspose.Pdf.Facades.
/// </summary>
public class GetButtonOptionValue
{
    /// <summary>
    /// Executes the example that lists all option values for the "Gender" button field.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve the input PDF path (data/inputs/FormField.pdf relative to the application base directory).
            string inputPath = Path.Combine(AppContext.BaseDirectory, "data", "inputs", "FormField.pdf");

            // Ensure the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create Form object.
            Form pdfForm = new Form();

            // Open the document.
            pdfForm.BindPdf(inputPath);

            // Get button option values for the field named "Gender".
            IDictionary optionValues = pdfForm.GetButtonOptionValues("Gender");

            // Enumerate and display the option values.
            IDictionaryEnumerator enumerator = optionValues.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine("Key : {0} , Value : {1} ", enumerator.Key, enumerator.Value);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Retrieves and displays the currently selected option value for the "Gender" button field.
    /// </summary>
    public static void GetCurrentValue()
    {
        try
        {
            // Resolve the input PDF path (data/inputs/FormField.pdf relative to the application base directory).
            string inputPath = Path.Combine(AppContext.BaseDirectory, "data", "inputs", "FormField.pdf");

            // Ensure the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create Form object.
            Form pdfForm = new Form();

            // Open the document.
            pdfForm.BindPdf(inputPath);

            // Get the current selected value for the field named "Gender".
            string currentValue = pdfForm.GetButtonOptionCurrentValue("Gender");

            Console.WriteLine("Current Value : {0} ", currentValue);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}