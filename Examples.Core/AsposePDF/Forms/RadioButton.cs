using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.Forms;

public class RadioButton
{
    /// <summary>
    /// Demonstrates adding a radio button field to a PDF document and saving the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory relative to the application base path.
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Define the output file path.
            string outputPath = Path.Combine(outputDir, "RadioButton_out.pdf");

            // Instantiate a new PDF document.
            Document pdfDocument = new Document();

            // Add a page to the PDF.
            pdfDocument.Pages.Add();

            // Create a RadioButtonField on the first page.
            RadioButtonField radio = new RadioButtonField(pdfDocument.Pages[1]);

            // Add radio button options with their positions.
            radio.AddOption("Test", new Rectangle(0, 0, 20, 20));
            radio.AddOption("Test1", new Rectangle(20, 20, 40, 40));

            // Add the radio button field to the document's form.
            pdfDocument.Form.Add(radio);

            // Save the PDF to the output path.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nRadio button field added successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}