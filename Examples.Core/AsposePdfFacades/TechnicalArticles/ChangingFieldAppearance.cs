using System;
using System.IO;
using System.Collections;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Drawing;
using Aspose.Pdf; // AUTOFIX

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

/// <summary>
/// Demonstrates how to change the appearance of a PDF form field using Aspose.Pdf.Facades.
/// </summary>
public class ChangingFieldAppearance
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = System.IO.Path.Combine(baseDir, "data", "inputs");
        string outputDir = System.IO.Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        try
        {
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to create output directory: {ex.Message}");
            return;
        }

        string inputPath = System.IO.Path.Combine(inputDir, "FilledForm.pdf");
        string outputPath = System.IO.Path.Combine(outputDir, "ChangingFieldAppearance_out.pdf");

        try
        {
            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Open the document and create a FormEditor object.
            FormEditor formEditor = new FormEditor(doc);

            // Add a text field.
            formEditor.AddField(FieldType.Text, "text1", 1, 200, 550, 300, 575);

            // Set field attribute - PropertyFlag enumeration contains 4 options.
            formEditor.SetFieldAttribute("text1", PropertyFlag.Required);

            // Set field limit - this field will take a maximum of 20 characters as input.
            formEditor.SetFieldLimit("text1", 20);

            // Save the modified document.
            formEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while processing the PDF: {ex.Message}");
        }
    }
}