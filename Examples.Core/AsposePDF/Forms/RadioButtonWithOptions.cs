using System;
using System.IO;
using Aspose.Pdf.Forms;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;

// TODO: import or include helper class RunExamples from original source if needed

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates adding a radio button field with three options to a PDF document.
/// </summary>
public class RadioButtonWithOptions
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new PDF document
            Document doc = new Document();
            Page page = doc.Pages.Add();

            // Create a table with three columns
            Aspose.Pdf.Table table = new Aspose.Pdf.Table
            {
                ColumnWidths = "120 120 120"
            };
            page.Paragraphs.Add(table);
            Row r1 = table.Rows.Add();
            Cell c1 = r1.Cells.Add();
            Cell c2 = r1.Cells.Add();
            Cell c3 = r1.Cells.Add();

            // Create a radio button field
            RadioButtonField rf = new RadioButtonField(page)
            {
                PartialName = "radio"
            };
            doc.Form.Add(rf, 1);

            // Create three radio button options
            RadioButtonOptionField opt1 = new RadioButtonOptionField();
            RadioButtonOptionField opt2 = new RadioButtonOptionField();
            RadioButtonOptionField opt3 = new RadioButtonOptionField();

            opt1.OptionName = "Item1";
            opt2.OptionName = "Item2";
            opt3.OptionName = "Item3";

            opt1.Width = 15;
            opt1.Height = 15;
            opt2.Width = 15;
            opt2.Height = 15;
            opt3.Width = 15;
            opt3.Height = 15;

            rf.Add(opt1);
            rf.Add(opt2);
            rf.Add(opt3);

            // Configure appearance for each option
            opt1.Border = new Border(opt1)
            {
                Width = 1,
                Style = BorderStyle.Solid
            };
            opt1.Characteristics.Border = System.Drawing.Color.Black; // TODO: verify cross‑platform color handling
            opt1.DefaultAppearance.TextColor = System.Drawing.Color.Red;
            opt1.Caption = new TextFragment("Item1");

            opt2.Border = new Border(opt1)
            {
                Width = 1,
                Style = BorderStyle.Solid
            };
            opt2.Characteristics.Border = System.Drawing.Color.Black;
            opt2.DefaultAppearance.TextColor = System.Drawing.Color.Red;
            opt2.Caption = new TextFragment("Item2");

            opt3.Border = new Border(opt1)
            {
                Width = 1,
                Style = BorderStyle.Solid
            };
            opt3.Characteristics.Border = System.Drawing.Color.Black;
            opt3.DefaultAppearance.TextColor = System.Drawing.Color.Red;
            opt3.Caption = new TextFragment("Item3");

            // Add options to table cells
            c1.Paragraphs.Add(opt1);
            c2.Paragraphs.Add(opt2);
            c3.Paragraphs.Add(opt3);

            // Save the PDF file
            string outputPath = Path.Combine(outputDir, "RadioButtonWithOptions_out.pdf");
            doc.Save(outputPath);

            Console.WriteLine("\nRadio button field with three options added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}