using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates filling an Arabic text into a PDF form field using Aspose.Pdf.
/// </summary>
public class ArabicTextFilling
{
    /// <summary>
    /// Executes the Arabic text filling example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Define input and output file paths.
        string inputPath = Path.Combine(inputDir, "FillFormField.pdf");
        string outputPath = Path.Combine(outputDir, "ArabicTextFilling_out.pdf");

        try
        {
            // Open the PDF form file for read/write access.
            using var fs = new FileStream(inputPath, FileMode.Open, FileAccess.ReadWrite);
            // Load the PDF document from the stream.
            var pdfDocument = new Document(fs);

            // Retrieve the specific TextBoxField by its name.
            if (pdfDocument.Form["textbox1"] is TextBoxField txtFld)
            {
                // Fill the form field with Arabic text.
                txtFld.Value = "يولد جميع الناس أحراراً متساوين في";
            }
            else
            {
                Console.WriteLine("The field 'textbox1' was not found or is not a TextBoxField.");
                return;
            }

            // Save the updated document to the output path.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nArabic text filled successfully in form field.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while processing the PDF: {ex.Message}");
        }
    }
}