using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates copying an inner field to another page using Aspose.Pdf Facades.
/// </summary>
public class CopyInnerField
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "CopyInnerField.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "CopyInnerField_out.pdf");

            // Create FormEditor object.
            FormEditor formEditor = new FormEditor();

            // Open the PDF document.
            formEditor.BindPdf(inputPath);

            // Copy a field to another page.
            formEditor.CopyInnerField("textfield", "newfieldname", 1);

            // Save the modified document.
            formEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}\nThis example will only work if you apply a valid Aspose License. You can purchase a full license or get a 30‑day temporary license from http://www.aspose.com/purchase/default.aspx.");
        }
    }
}