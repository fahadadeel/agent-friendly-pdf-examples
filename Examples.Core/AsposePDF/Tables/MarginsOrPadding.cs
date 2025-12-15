using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Tables;

public class MarginsOrPadding
{
    /// <summary>
    /// Demonstrates setting margins, padding, and borders for a table in a PDF document using Aspose.Pdf.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Output file path
            string outputPath = Path.Combine(outputDir, "MarginsOrPadding_out.pdf");

            // Create a new PDF document
            Document doc = new Document();
            Page page = doc.Pages.Add();

            // Instantiate a table object
            Aspose.Pdf.Table tab1 = new Aspose.Pdf.Table();

            // Add the table to the page's paragraphs collection
            page.Paragraphs.Add(tab1);

            // Set column widths of the table
            tab1.ColumnWidths = "50 50 50";

            // Set default cell border using BorderInfo object
            tab1.DefaultCellBorder = new BorderInfo(BorderSide.All, 0.1F);

            // Set table border using another customized BorderInfo object
            tab1.Border = new BorderInfo(BorderSide.All, 1F);

            // Create MarginInfo object and set its margins
            MarginInfo margin = new MarginInfo
            {
                Top = 5f,
                Left = 5f,
                Right = 5f,
                Bottom = 5f
            };

            // Set the default cell padding to the MarginInfo object
            tab1.DefaultCellPadding = margin;

            // Create rows in the table and then cells in the rows
            Row row1 = tab1.Rows.Add();
            row1.Cells.Add("col1");
            row1.Cells.Add("col2");
            row1.Cells.Add(); // empty cell

            TextFragment mytext = new TextFragment("col3 with large text string");
            row1.Cells[2].Paragraphs.Add(mytext);
            row1.Cells[2].IsWordWrapped = false;

            Row row2 = tab1.Rows.Add();
            row2.Cells.Add("item1");
            row2.Cells.Add("item2");
            row2.Cells.Add("item3");

            // Save the PDF
            doc.Save(outputPath);

            Console.WriteLine("\nCell and table border width setup successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("An error occurred while creating the PDF: " + ex.Message);
        }
    }
}