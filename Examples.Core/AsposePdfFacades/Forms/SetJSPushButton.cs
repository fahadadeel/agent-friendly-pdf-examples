using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates setting JavaScript for a push button field using Aspose.Pdf Facades.
/// </summary>
public class SetJSPushButton
{
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "SetJSPushButton_out.pdf");

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open the document and create a FormEditor object.
            var form = new FormEditor();
            form.BindPdf(inputPath);

            // Set JavaScript for the push button field named "pushbutton".
            form.SetFieldScript("pushbutton", "app.alert('Hello World!');");

            // Save the updated document.
            form.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SetJSPushButton.Run: {ex.Message}");
        }
    }
}