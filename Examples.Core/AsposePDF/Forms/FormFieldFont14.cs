using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates how to set a custom font for a PDF form field using Aspose.Pdf.
/// </summary>
public class FormFieldFont14
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
            string inputPath = Path.Combine(baseDir, "data", "inputs", "FormFieldFont14.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "FormFieldFont14_out.pdf");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Retrieve the specific form field.
            Field field = pdfDocument.Form["textbox1"] as Field;
            if (field == null)
            {
                Console.WriteLine("Form field 'textbox1' not found.");
                return;
            }

            // Locate the desired font.
            Font font = FontRepository.FindFont("ComicSansMS");

            // Set the font information for the form field.
            // The DefaultAppearance constructor that accepts a color requires System.Drawing.Color,
            // which is platform‑specific. Adjust as needed for your environment.
            // field.DefaultAppearance = new DefaultAppearance(font, 10, System.Drawing.Color.Black);
            // TODO: Replace the above line with a cross‑platform color representation if needed.

            // Save the updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nForm field font setup successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}