using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates how to retrieve the coordinates of radio button options in a PDF form.
/// </summary>
public class GetCoordinates
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

            // Path to the input PDF file.
            string inputPath = Path.Combine(inputDir, "input.pdf");

            // Load the PDF document.
            Document doc1 = new Document(inputPath);

            // Retrieve radio button fields by their names.
            RadioButtonField field0 = doc1.Form["Item1"] as RadioButtonField;
            RadioButtonField field1 = doc1.Form["Item2"] as RadioButtonField;
            RadioButtonField field2 = doc1.Form["Item3"] as RadioButtonField;

            // Display the rectangle (position) of each option within the fields.
            if (field0 != null)
            {
                foreach (RadioButtonOptionField option in field0)
                {
                    Console.WriteLine(option.Rect);
                }
            }

            if (field1 != null)
            {
                foreach (RadioButtonOptionField option in field1)
                {
                    Console.WriteLine(option.Rect);
                }
            }

            if (field2 != null)
            {
                foreach (RadioButtonOptionField option in field2)
                {
                    Console.WriteLine(option.Rect);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}