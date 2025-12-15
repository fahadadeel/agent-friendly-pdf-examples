using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates retrieving and setting XFA form field properties using Aspose.Pdf.
/// </summary>
public class GetXFAProperties
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input PDF file name.
            string inputFile = Path.Combine(inputDir, "GetXFAProperties.pdf");
            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"Input file not found: {inputFile}");
                return;
            }

            // Load XFA form.
            Document doc = new Document(inputFile);

            // Retrieve field names.
            string[] names = doc.Form.XFA.FieldNames;

            if (names.Length >= 2)
            {
                // Set field values.
                doc.Form.XFA[names[0]] = "Field 0";
                doc.Form.XFA[names[1]] = "Field 1";

                // Get field position attributes.
                Console.WriteLine(doc.Form.XFA.GetFieldTemplate(names[0]).Attributes["x"].Value);
                Console.WriteLine(doc.Form.XFA.GetFieldTemplate(names[0]).Attributes["y"].Value);
            }
            else
            {
                Console.WriteLine("Not enough XFA fields found in the document.");
            }

            // Save the updated document.
            string outputFile = Path.Combine(outputDir, "Filled_XFA_out.pdf");
            doc.Save(outputFile);

            Console.WriteLine("\nXFA fields properties retrieved successfully.\nFile saved at " + outputFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during GetXFAProperties execution: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.