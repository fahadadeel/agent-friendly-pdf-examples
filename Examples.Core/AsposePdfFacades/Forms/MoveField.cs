using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates moving a form field within a PDF using Aspose.Pdf.Facades.
/// </summary>
public class MoveField
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "MoveFormField_out.pdf");

            // Initialize FormEditor and bind the PDF.
            FormEditor formEditor = new FormEditor();
            formEditor.BindPdf(inputPath);

            // Move the field named "textfield" to the new rectangle (300,300)-(400,400).
            formEditor.MoveField("textfield", 300, 300, 400, 400);

            // Save the updated PDF.
            formEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing MoveField example: {ex.Message}");
        }
    }
}