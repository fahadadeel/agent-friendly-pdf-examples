using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates preserving rights while modifying PDF form fields using Aspose.Pdf.
/// </summary>
public class PreserveRights
{
    /// <summary>
    /// Modifies form fields in a PDF while preserving existing rights.
    /// </summary>
    public static void Run()
    {
        // TODO: import or include helper class RunExamples from original source
        try
        {
            // Resolve input directory (data/inputs) relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string inputPath = Path.Combine(inputDir, "input.pdf");

            // Ensure the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open the PDF with read/write access.
            using var fs = new FileStream(inputPath, FileMode.Open, FileAccess.ReadWrite);
            // Instantiate Document instance.
            var pdfDocument = new Document(fs);

            // Get values from all fields.
            foreach (Field formField in pdfDocument.Form)
            {
                // If the fullname of field contains "A1", perform the operation.
                if (formField.FullName.Contains("A1"))
                {
                    // Cast form field as TextBox.
                    if (formField is TextBoxField textBoxField)
                    {
                        // Modify field value.
                        textBoxField.Value = "Testing";
                    }
                }
            }

            // Save the updated document back to the same stream (preserving rights).
            pdfDocument.Save();

            // The using statement will close the FileStream automatically.
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PreserveRights.Run: {ex.Message}");
        }
    }

    /// <summary>
    /// Demonstrates preserving rights using the Aspose.Pdf.Facades.Form class.
    /// </summary>
    public static void PreserveRightsUsingFormClass()
    {
        try
        {
            // Resolve input and output directories.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "PreserveRightsUsingFormClass_out.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Input and output file paths are equal, this forces incremental update when form saved.
            var form = new Aspose.Pdf.Facades.Form(inputPath); // AUTOFIX
            // Fill value in form field.
            form.FillField("topmostSubform[0].Page1[0].f1_29_0_[0]", "Nayyer");
            // Save updated document.
            form.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PreserveRights.PreserveRightsUsingFormClass: {ex.Message}");
        }
    }
}