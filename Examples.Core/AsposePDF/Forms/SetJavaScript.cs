using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates how to attach JavaScript actions to a PDF form field using Aspose.Pdf.
/// </summary>
public class SetJavaScript
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Define input and output file paths.
        string inputPath = Path.Combine(inputDir, "SetJavaScript.pdf");
        string outputPath = Path.Combine(outputDir, "Restricted_out.pdf");

        try
        {
            // Load input PDF file.
            Document doc = new Document(inputPath);

            // Access the text box field named "textbox1".
            if (doc.Form["textbox1"] is not TextBoxField field)
            {
                Console.WriteLine($"Field 'textbox1' not found in the document.");
                return;
            }

            // Attach JavaScript actions.
            field.Actions.OnModifyCharacter = new JavascriptAction("AFNumber_Keystroke(2, 1, 1, 0, \"\", true)");
            field.Actions.OnFormat = new JavascriptAction("AFNumber_Format(2, 1, 1, 0, \"\", true)");

            // Set initial field value.
            field.Value = "123";

            // Save the resultant PDF.
            doc.Save(outputPath);

            Console.WriteLine($"\nJavaScript on form field setup successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}