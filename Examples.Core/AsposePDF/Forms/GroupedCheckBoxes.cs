using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Forms;
using System.Drawing; // TODO: System.Drawing may be platform-specific; ensure appropriate package/reference

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates adding grouped checkboxes (radio buttons) to a PDF document using Aspose.Pdf.
/// </summary>
public class GroupedCheckBoxes
{
    /// <summary>
    /// Creates a PDF with grouped checkboxes and saves it to the outputs folder.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output path
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "GroupedCheckBoxes_out.pdf");

            // Instantiate Document object
            Document pdfDocument = new Document();

            // Add a page to PDF file
            Page page = pdfDocument.Pages.Add();

            // Instantiate RadioButtonField object with page number as argument
            RadioButtonField radio = new RadioButtonField(pdfDocument.Pages[1]);

            // Add first radio button option and also specify its origin using Rectangle object
            RadioButtonOptionField opt1 = new RadioButtonOptionField(page, new Aspose.Pdf.Rectangle(0, 0, 20, 20));
            RadioButtonOptionField opt2 = new RadioButtonOptionField(page, new Aspose.Pdf.Rectangle(100, 0, 120, 20));

            opt1.OptionName = "Test1";
            opt2.OptionName = "Test2";

            radio.Add(opt1);
            radio.Add(opt2);

            // Set styles
            opt1.Style = BoxStyle.Square;
            opt2.Style = BoxStyle.Square;
            opt1.Style = BoxStyle.Cross;
            opt2.Style = BoxStyle.Cross;

            // Configure borders
            opt1.Border = new Border(opt1);
            opt1.Border.Style = BorderStyle.Solid;
            opt1.Border.Width = 1;
            // Resolve ambiguous Color reference
            opt1.Characteristics.Border = System.Drawing.Color.Black;

            opt2.Border = new Border(opt2);
            opt2.Border.Width = 1;
            opt2.Border.Style = BorderStyle.Solid;
            // Resolve ambiguous Color reference
            opt2.Characteristics.Border = System.Drawing.Color.Black;

            // Add radio button to form object of Document object
            pdfDocument.Form.Add(radio);

            // Save the PDF document
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nGrouped checkboxes added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}