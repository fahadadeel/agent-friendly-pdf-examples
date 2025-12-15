using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates adding a ComboBox form field to a PDF document using Aspose.Pdf.
/// </summary>
public class ComboBox
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine output directory and ensure it exists.
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Output file path.
            string outputPath = Path.Combine(outputDir, "ComboBox_out.pdf");

            // Create a new PDF document.
            Document doc = new Document();

            // Add a page to the document.
            doc.Pages.Add();

            // Instantiate a ComboBox field on the first page.
            ComboBoxField combo = new ComboBoxField(doc.Pages[1], new Aspose.Pdf.Rectangle(100, 600, 150, 616));

            // Add options to the ComboBox.
            combo.AddOption("Red");
            combo.AddOption("Yellow");
            combo.AddOption("Green");
            combo.AddOption("Blue");

            // Add the ComboBox to the form fields collection.
            doc.Form.Add(combo);

            // Save the PDF document.
            doc.Save(outputPath);

            Console.WriteLine("\nCombobox field added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}