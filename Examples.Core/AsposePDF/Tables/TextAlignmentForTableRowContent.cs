using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using Aspose.Pdf;

/// <summary>
/// Demonstrates setting text alignment for table row content using Aspose.Pdf.
/// </summary>
public class TextAlignmentForTableRowContent
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine output directory and ensure it exists
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "43620_ByWords_out.pdf");

            // Create PDF document
            Document doc = new Document();

            // Initialize a new instance of the Table
            Table table = new Table();

            // Set the table border color as LightGray
            table.Border = new BorderInfo(BorderSide.All, 0.5f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.LightGray));

            // Set the border for table cells
            table.DefaultCellBorder = new BorderInfo(BorderSide.All, 0.5f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.LightGray));

            // Create a loop to add 10 rows
            for (int row_count = 0; row_count < 10; row_count++)
            {
                // Add row to table
                Row row = table.Rows.Add();
                row.VerticalAlignment = VerticalAlignment.Center;

                row.Cells.Add($"Column ({row_count}, 1){DateTime.Now.Ticks}");
                row.Cells.Add($"Column ({row_count}, 2)");
                row.Cells.Add($"Column ({row_count}, 3)");
            }

            // Add a page and place the table on it
            Page tocPage = doc.Pages.Add();
            tocPage.Paragraphs.Add(table);

            // Save the document
            doc.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in TextAlignmentForTableRowContent.Run: {ex.Message}");
        }
    }
}