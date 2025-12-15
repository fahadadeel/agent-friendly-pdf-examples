using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates adding a TextBox field to a PDF document using Aspose.Pdf.
/// </summary>
public class TextBox
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "TextField.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "TextBox_out.pdf");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Open document
            Document pdfDocument = new Document(inputPath);

            // Create a TextBox field
            TextBoxField textBoxField = new TextBoxField(pdfDocument.Pages[1],
                new Rectangle(100, 200, 300, 300));
            textBoxField.PartialName = "textbox1";
            textBoxField.Value = "Text Box";

            // Configure border
            Border border = new Border(textBoxField);
            border.Width = 5;
            border.Dash = new Dash(1, 1);
            textBoxField.Border = border;

            // Set field color
            textBoxField.Color = Color.Green;

            // Add field to the document
            pdfDocument.Form.Add(textBoxField, 1);

            // Save modified PDF
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nTextbox field added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error adding TextBox field: " + ex.Message);
        }
    }
}