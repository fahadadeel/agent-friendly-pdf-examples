using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

public class AddListItem
{
    /// <summary>
    /// Demonstrates adding list items to a PDF form using Aspose.Pdf.Facades.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine input and output directories.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "AddListItem.pdf");
            string outputPath = Path.Combine(outputDir, "AddListItem_out.pdf");

            // Ensure input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create FormEditor and bind PDF.
            using var form = new FormEditor();
            form.BindPdf(inputPath);

            // Add list field.
            form.AddField(FieldType.ListBox, "listbox", 1, 300, 200, 350, 225);

            // Add list items.
            form.AddListItem("listbox", "Item 1");
            form.AddListItem("listbox", "Item 2");

            // Add multiple list items at once.
            string[] listItems = { "Item 3", "Item 4", "Item 5" };
            form.AddListItem("listbox", listItems);

            // Save updated PDF.
            form.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during AddListItem example: {ex.Message}");
        }
    }
}