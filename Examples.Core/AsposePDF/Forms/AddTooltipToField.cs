using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates how to add a tooltip to a form field in a PDF document using Aspose.Pdf.
/// </summary>
public class AddTooltipToField
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "AddTooltipToField.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load source PDF form.
            Document doc = new Document(inputPath);

            // Set the tooltip for the text field named "textbox1".
            if (doc.Form["textbox1"] is Field field)
            {
                field.AlternateName = "Text box tool tip";
            }
            else
            {
                Console.WriteLine("Field 'textbox1' not found in the PDF form.");
                return;
            }

            // Output PDF file path.
            string outputPath = Path.Combine(outputDir, "AddTooltipToField_out.pdf");

            // Save the updated document.
            doc.Save(outputPath);

            Console.WriteLine($"\nTooltip added successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}