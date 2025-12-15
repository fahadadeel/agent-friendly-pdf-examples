using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Tables;

/// <summary>
/// Demonstrates how to determine when a table will break across pages in a PDF document using Aspose.Pdf.
/// </summary>
public class DetermineTableBreak
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory (data/outputs relative to the application base directory)
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Output file path
            string outputPath = Path.Combine(outputDir, "DetermineTableBreak_out.pdf");

            // Instantiate a PDF document
            Document pdf = new Document();

            // Add a page to the document
            Page page = pdf.Pages.Add();

            // Create a table and configure its layout
            Table table1 = new Table
            {
                Margin = { Top = 300 },
                ColumnWidths = "100 100 100",
                DefaultCellBorder = new BorderInfo(BorderSide.All, 0.1F),
                Border = new BorderInfo(BorderSide.All, 1F)
            };

            // Set default cell padding
            MarginInfo margin = new MarginInfo
            {
                Top = 5f,
                Left = 5f,
                Right = 5f,
                Bottom = 5f
            };
            table1.DefaultCellPadding = margin;

            // Add the table to the page's paragraphs collection
            page.Paragraphs.Add(table1);

            // Populate the table with rows (0..16). Adding more rows would cause a break.
            for (int rowCounter = 0; rowCounter <= 16; rowCounter++)
            {
                Row row = table1.Rows.Add();
                row.Cells.Add("col " + rowCounter.ToString() + ", 1");
                row.Cells.Add("col " + rowCounter.ToString() + ", 2");
                row.Cells.Add("col " + rowCounter.ToString() + ", 3");
            }

            // Retrieve page and table height information
            float pageHeight = (float)pdf.PageInfo.Height;
            float totalObjectsHeight = (float)page.PageInfo.Margin.Top +
                                       (float)page.PageInfo.Margin.Bottom +
                                       (float)table1.Margin.Top +
                                       (float)table1.GetHeight();

            // Display diagnostic information
            Console.WriteLine(
                "PDF document Height = " + pdf.PageInfo.Height.ToString() + "\n" +
                "Top Margin Info = " + page.PageInfo.Margin.Top.ToString() + "\n" +
                "Bottom Margin Info = " + page.PageInfo.Margin.Bottom.ToString() + "\n\n" +
                "Table-Top Margin Info = " + table1.Margin.Top.ToString() + "\n" +
                "Average Row Height = " + table1.Rows[0].MinRowHeight.ToString() + "\n" +
                "Table height = " + table1.GetHeight().ToString() + "\n" +
                "----------------------------------------\n" +
                "Total Page Height = " + pageHeight.ToString() + "\n" +
                "Cumulative height including Table = " + totalObjectsHeight.ToString());

            // Determine if adding another row would exceed the page height
            if ((pageHeight - totalObjectsHeight) <= 10)
            {
                Console.WriteLine("Page Height - Objects Height < 10, so table will break");
            }

            // Save the PDF document
            pdf.Save(outputPath);

            Console.WriteLine("\nTable break determined successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("An error occurred while executing DetermineTableBreak: " + ex.Message);
        }
    }
}