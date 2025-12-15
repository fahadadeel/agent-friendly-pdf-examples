using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates how to read values from all form fields in a PDF document using Aspose.Pdf.
/// </summary>
public class GetValuesFromAllFields
{
    /// <summary>
    /// Entry point for the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input PDF path relative to the application base directory.
            string inputPath = Path.Combine(AppContext.BaseDirectory, "data", "inputs", "GetValuesFromAllFields.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (not used in this example but created per requirements).
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Open document using path overload.
            Document pdfDocument = new Document(inputPath);

            // Get values from all fields.
            foreach (Field formField in pdfDocument.Form)
            {
                Console.WriteLine("Field Name : {0} ", formField.PartialName);
                Console.WriteLine("Value : {0} ", formField.Value);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}