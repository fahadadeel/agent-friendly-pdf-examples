using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates filling XFA fields in a PDF form using Aspose.Pdf.
/// </summary>
public class FillXFAFields
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // ExStart:FillXFAFields
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "FillXFAFields.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load XFA form.
            Document doc = new Document(inputPath);

            // Get names of XFA form fields.
            string[] names = doc.Form.XFA.FieldNames;

            // Set field values if fields are present.
            if (names != null && names.Length > 0)
            {
                doc.Form.XFA[names[0]] = "Field 0";
                if (names.Length > 1)
                {
                    doc.Form.XFA[names[1]] = "Field 1";
                }
            }

            // Output PDF file.
            string outputPath = Path.Combine(outputDir, "Filled_XFA_out.pdf");

            // Save the updated document.
            doc.Save(outputPath);

            Console.WriteLine("\nXFA fields filled successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while filling XFA fields: {ex.Message}");
        }
        // ExEnd:FillXFAFields
    }
}