using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates adding various form fields to a PDF document using Aspose.Pdf.Facades.
/// </summary>
public class AddFormField
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

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "AddFormField.pdf");
            string outputPath = Path.Combine(outputDir, "AddFormField_out.pdf");

            // Validate input file existence.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Initialize FormEditor and bind the PDF.
            FormEditor formEditor = new FormEditor();
            formEditor.BindPdf(inputPath);

            // Add various form fields.
            formEditor.AddField(FieldType.Text, "textfield", 1, 100, 100, 200, 150);
            formEditor.AddField(FieldType.CheckBox, "checkboxfield", 1, 100, 200, 200, 250);
            formEditor.AddField(FieldType.ComboBox, "comboboxfield", 1, 100, 300, 200, 350);
            formEditor.AddField(FieldType.ListBox, "listboxfield", 1, 100, 400, 200, 450);
            formEditor.AddField(FieldType.MultiLineText, "multilinetextfield", 1, 100, 500, 200, 550);

            // Save the updated PDF.
            formEditor.Save(outputPath);

            Console.WriteLine($"PDF saved successfully to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.