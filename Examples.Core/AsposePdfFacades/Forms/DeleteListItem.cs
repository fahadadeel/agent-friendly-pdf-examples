using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates deleting a list item from a PDF form using Aspose.Pdf.Facades.
/// </summary>
public class DeleteListItem
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

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "AddListItem.pdf");
            string outputPath = Path.Combine(outputDir, "DeleteListItem_out.pdf");

            // Open the document and create a FormEditor object.
            FormEditor form = new FormEditor();
            form.BindPdf(inputPath);

            // Delete list item.
            form.DelListItem("listbox", "Item 2");

            // Save updated file.
            form.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in DeleteListItem example: {ex.Message}");
        }
    }
}