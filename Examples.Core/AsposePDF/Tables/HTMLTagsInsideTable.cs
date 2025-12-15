using System;
using System.Data;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Tables;

/// <summary>
/// Demonstrates how to insert HTML tags inside a table cell using Aspose.Pdf.
/// </summary>
public class HTMLTagsInsideTable
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory (data/outputs) relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "HTMLInsideTableCell_out.pdf");

            // Create a DataTable with a single column containing HTML list items.
            DataTable dt = new DataTable("Employee");
            dt.Columns.Add("data", typeof(string));

            DataRow dr = dt.NewRow();
            dr[0] = "<li>Department of Emergency Medicine: 3400 Spruce Street Ground Silverstein Bldg Philadelphia PA 19104-4206</li>";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "<li>Penn Observation Medicine Service: 3400 Spruce Street Ground Floor Donner Philadelphia PA 19104-4206</li>";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "<li>UPHS/Presbyterian - Dept. of Emergency Medicine: 51 N. 39th Street . Philadelphia PA 19104-2640</li>";
            dt.Rows.Add(dr);

            // Create a new PDF document and add a page.
            Document doc = new Document();
            doc.Pages.Add();

            // Initialize a new table.
            Table tableProvider = new Table
            {
                // Set column widths.
                ColumnWidths = "400 50 ",
                // Set table border color (LightGray: RGB 211,211,211).
                Border = new BorderInfo(BorderSide.All, 0.5F, Color.FromRgb(211, 211, 211)),
                // Set cell border.
                DefaultCellBorder = new BorderInfo(BorderSide.All, 0.5F, Color.FromRgb(211, 211, 211))
            };

            // Set default cell padding.
            MarginInfo margin = new MarginInfo
            {
                Top = 2.5F,
                Left = 2.5F,
                Bottom = 1.0F
            };
            tableProvider.DefaultCellPadding = margin;

            // Import the DataTable into the Aspose.Pdf.Table.
            tableProvider.ImportDataTable(dt, false, 0, 0, 3, 1, true);

            // Add the table to the first page.
            doc.Pages[1].Paragraphs.Add(tableProvider);

            // Save the PDF document.
            doc.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing HTMLTagsInsideTable example: {ex.Message}");
        }
    }
}