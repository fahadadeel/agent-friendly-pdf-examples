using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates copying an outer field from one PDF document to another using Aspose.Pdf.Facades.
/// </summary>
public class CopyOuterField
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

            // Define file paths.
            string sourcePdfPath = Path.Combine(inputDir, "CopyOuterField.pdf");
            string outerPdfPath = Path.Combine(inputDir, "input.pdf");
            string outputPdfPath = Path.Combine(outputDir, "CopyOuterField_out.pdf");

            // Open document with FormEditor.
            using var formEditor = new FormEditor();
            formEditor.BindPdf(sourcePdfPath);

            // Copy a text field from the outer PDF into the opened document.
            // Parameters: outer PDF path, field name, page number (1‑based).
            formEditor.CopyOuterField(outerPdfPath, "textfield", 1);

            // Save the modified document.
            formEditor.Save(outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}\nThis example will only work if you apply a valid Aspose License. You can purchase a full license or get a 30‑day temporary license from http://www.aspose.com/purchase/default.aspx.");
        }
    }
}