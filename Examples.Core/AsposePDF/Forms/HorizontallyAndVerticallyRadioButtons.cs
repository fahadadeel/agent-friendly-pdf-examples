using System;
using System.IO;
using Aspose.Pdf.Facades;
using Aspose.Pdf;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates adding horizontally and vertically laid out radio buttons to a PDF form.
/// </summary>
public class HorizontallyAndVerticallyRadioButtons
{
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

            // Path to the source PDF.
            string inputPath = Path.Combine(inputDir, "input.pdf");

            // Load the previously saved document.
            var formEditor = new FormEditor();
            formEditor.BindPdf(inputPath);

            // RadioGap is distance between two radio button options.
            formEditor.RadioGap = 4;

            // Add horizontal radio button.
            formEditor.RadioHoriz = true;
            // RadioButtonItemSize is size of radio button item.
            formEditor.RadioButtonItemSize = 20;
            formEditor.Facade.BorderWidth = 1;
            formEditor.Facade.BorderColor = System.Drawing.Color.Black;
            formEditor.Items = new string[] { "First", "Second", "Third" };
            formEditor.AddField(FieldType.Radio, "NewField1", 1, 40, 600, 120, 620);

            // Add other radio button situated vertically.
            formEditor.RadioHoriz = false;
            formEditor.Items = new string[] { "First", "Second", "Third" };
            formEditor.AddField(FieldType.Radio, "NewField2", 1, 40, 500, 60, 550);

            // Save the PDF document.
            string outputPath = Path.Combine(outputDir, "HorizontallyAndVerticallyRadioButtons_out.pdf");
            formEditor.Save(outputPath);

            Console.WriteLine("\nHorizontally and vertically laid out radio buttons successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}