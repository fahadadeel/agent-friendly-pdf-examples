using Aspose.Pdf;
using Aspose.Pdf.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates retrieving form fields in tab order, modifying the order,
/// and saving the document using Aspose.Pdf.
/// </summary>
public class RetrieveFormFieldInTabOrder
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
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "Test2.pdf");
            string outputPath = Path.Combine(outputDir, "39522_out.pdf");

            // Load the source PDF document.
            Document doc = new Document(inputPath);
            Page page = doc.Pages[1];

            // Retrieve fields in tab order.
            IList<Field> fields = page.FieldsInTabOrder;
            string concatenatedNames = string.Empty;
            foreach (Field field in fields)
            {
                concatenatedNames += field.PartialName;
            }

            // Modify tab order of specific fields.
            (doc.Form[3] as Field).TabOrder = 1;
            (doc.Form[1] as Field).TabOrder = 2;
            (doc.Form[2] as Field).TabOrder = 3;

            // Save the modified document.
            doc.Save(outputPath);

            // Load the saved document to verify changes.
            Document doc1 = new Document(outputPath);
            concatenatedNames = string.Empty;
            foreach (Field field in doc1.Pages[1].FieldsInTabOrder)
            {
                concatenatedNames += field.PartialName;
            }

            string tabOrderIndices = string.Empty;
            foreach (Field field in doc1.Form)
            {
                tabOrderIndices += field.TabOrder;
            }

            // Optionally, output results to console for verification.
            Console.WriteLine("Concatenated field names (original): " + concatenatedNames);
            Console.WriteLine("Tab order indices (after reordering): " + tabOrderIndices);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}