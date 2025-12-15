using System;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Demonstrates adding a repeating column to a table using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Tables;

public class AddRepeatingColumn
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Output file path.
            string outFile = Path.Combine(outputDir, "AddRepeatingColumn_out.pdf");

            // Create a new PDF document.
            Document doc = new Document();
            Page page = doc.Pages.Add();

            // Instantiate an outer table that takes up the entire page.
            Table outerTable = new Table
            {
                ColumnWidths = "100%",
                HorizontalAlignment = HorizontalAlignment.Left
            };

            // Instantiate a nested table that will break inside the same page.
            Table mytable = new Table
            {
                Broken = TableBroken.VerticalInSamePage,
                ColumnAdjustment = ColumnAdjustment.AutoFitToContent
            };

            // Add the outer table to the page.
            page.Paragraphs.Add(outerTable);
            Row bodyRow = outerTable.Rows.Add();
            Cell bodyCell = bodyRow.Cells.Add();
            bodyCell.Paragraphs.Add(mytable);

            // Configure repeating columns.
            mytable.RepeatingColumnsCount = 5;

            // Also add the nested table directly to the page (as in the original example).
            page.Paragraphs.Add(mytable);

            // Add header row.
            Row headerRow = mytable.Rows.Add();
            headerRow.Cells.Add("header 1");
            headerRow.Cells.Add("header 2");
            headerRow.Cells.Add("header 3");
            headerRow.Cells.Add("header 4");
            headerRow.Cells.Add("header 5");
            headerRow.Cells.Add("header 6");
            headerRow.Cells.Add("header 7");
            headerRow.Cells.Add("header 11");
            headerRow.Cells.Add("header 12");
            headerRow.Cells.Add("header 13");
            headerRow.Cells.Add("header 14");
            headerRow.Cells.Add("header 15");
            headerRow.Cells.Add("header 16");
            headerRow.Cells.Add("header 17");

            // Add data rows.
            for (int rowCounter = 0; rowCounter <= 5; rowCounter++)
            {
                Row dataRow = mytable.Rows.Add();
                dataRow.Cells.Add("col " + rowCounter + ", 1");
                dataRow.Cells.Add("col " + rowCounter + ", 2");
                dataRow.Cells.Add("col " + rowCounter + ", 3");
                dataRow.Cells.Add("col " + rowCounter + ", 4");
                dataRow.Cells.Add("col " + rowCounter + ", 5");
                dataRow.Cells.Add("col " + rowCounter + ", 6");
                dataRow.Cells.Add("col " + rowCounter + ", 7");
                dataRow.Cells.Add("col " + rowCounter + ", 11");
                dataRow.Cells.Add("col " + rowCounter + ", 12");
                dataRow.Cells.Add("col " + rowCounter + ", 13");
                dataRow.Cells.Add("col " + rowCounter + ", 14");
                dataRow.Cells.Add("col " + rowCounter + ", 15");
                dataRow.Cells.Add("col " + rowCounter + ", 16");
                dataRow.Cells.Add("col " + rowCounter + ", 17");
            }

            // Save the document.
            doc.Save(outFile);
            Console.WriteLine($"PDF saved to: {outFile}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing AddRepeatingColumn example: {ex.Message}");
        }
    }
}