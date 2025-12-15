using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates selecting a radio button in a PDF form using Aspose.Pdf.
/// </summary>
public class SelectRadioButton
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // ExStart:SelectRadioButton
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "RadioButton.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "SelectRadioButton_out.pdf");

            // Open document
            Document pdfDocument = new Document(inputPath);

            // Get the radio button field named "radio"
            RadioButtonField radioField = pdfDocument.Form["radio"] as RadioButtonField;
            if (radioField == null)
            {
                Console.WriteLine("Radio button field 'radio' not found.");
                return;
            }

            // Specify the index of the radio button to select (zero‑based)
            radioField.Selected = 2;

            // Save the PDF file
            pdfDocument.Save(outputPath);
            // ExEnd:SelectRadioButton

            Console.WriteLine($"\nRadioButton from group selected successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}