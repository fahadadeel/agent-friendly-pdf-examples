using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates how to delete a form field from a PDF using Aspose.Pdf.Facades.
/// </summary>
public class DeleteField
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Input and output file paths.
        string inputFile = Path.Combine(inputDir, "DeleteFormField.pdf");
        string outputFile = Path.Combine(outputDir, "DeleteFormField_out.pdf");

        try
        {
            // Initialize FormEditor.
            FormEditor formEditor = new FormEditor();

            // Open the PDF document.
            formEditor.BindPdf(inputFile);

            // Delete the specified field.
            formEditor.RemoveField("textfield");

            // Save the updated PDF.
            formEditor.Save(outputFile);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during DeleteField example: {ex.Message}");
        }
    }
}