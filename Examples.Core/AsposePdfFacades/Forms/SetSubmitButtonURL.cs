using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates setting a submit button URL in a PDF form using Aspose.Pdf.Facades.
/// </summary>
public class SetSubmitButtonURL
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
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "SetSubmitButtonURL_out.pdf");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a FormEditor and bind the PDF.
            using var form = new FormEditor();
            form.BindPdf(inputPath);

            // Set the submit URL for the button named "submitbutton".
            form.SetSubmitUrl("submitbutton", "http:// Www.aspose.com");

            // Save the updated PDF.
            form.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SetSubmitButtonURL.Run: {ex.Message}");
        }
    }
}