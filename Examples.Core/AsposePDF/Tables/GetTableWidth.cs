using System;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Tables;

/// <summary>
/// Demonstrates how to get the width of a table using Aspose.Pdf.
/// </summary>
public class GetTableWidth
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Create a new document
            var doc = new Document();

            // Add a page to the document
            var page = doc.Pages.Add();

            // Initialize a new table with auto‑fit column adjustment
            var table = new Table
            {
                ColumnAdjustment = ColumnAdjustment.AutoFitToContent
            };

            // Add a row to the table
            var row = table.Rows.Add();

            // Add cells to the row
            var cell = row.Cells.Add("Cell 1 text");
            cell = row.Cells.Add("Cell 2 text");

            // Get and display the table width
            Console.WriteLine(table.GetWidth());

            Console.WriteLine("Extracted table width successfully!");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in GetTableWidth.Run: {ex.Message}");
        }
    }
}