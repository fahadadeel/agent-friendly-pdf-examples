using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates how to determine required fields in a PDF form using Aspose.Pdf.
/// </summary>
public class DetermineRequiredField
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input PDF path.
            string inputPath = Path.Combine(AppContext.BaseDirectory, "data", "inputs", "DetermineRequiredField.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (even though this example does not write output).
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Load source PDF file.
            Document pdf = new Document(inputPath);

            // Instantiate Form object.
            Aspose.Pdf.Facades.Form pdfForm = new Aspose.Pdf.Facades.Form(pdf);

            // Iterate through each field inside PDF form.
            foreach (Field field in pdf.Form.Fields)
            {
                // Determine if the field is marked as required.
                bool isRequired = pdfForm.IsRequiredField(field.FullName);
                if (isRequired)
                {
                    Console.WriteLine($"The field named {field.FullName} is required");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}