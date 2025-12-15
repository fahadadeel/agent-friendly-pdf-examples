using System;
using System.IO;
using Aspose.Pdf;
using System.Data;

namespace Examples.Core.AsposePDF.Tables;

/// <summary>
/// Demonstrates integrating a DataTable with an Aspose.Pdf document.
/// </summary>
public class IntegrateWithDatabase
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
            Directory.CreateDirectory(outputDir);

            // Create sample DataTable
            DataTable dt = new DataTable("Employee");
            dt.Columns.Add("Employee_ID", typeof(int));
            dt.Columns.Add("Employee_Name", typeof(string));
            dt.Columns.Add("Gender", typeof(string));

            DataRow dr = dt.NewRow();
            dr[0] = 1;
            dr[1] = "John Smith";
            dr[2] = "Male";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = 2;
            dr[1] = "Mary Miller";
            dr[2] = "Female";
            dt.Rows.Add(dr);

            // Create PDF document
            Document doc = new Document();
            doc.Pages.Add();

            // Initialize table
            Aspose.Pdf.Table table = new Aspose.Pdf.Table
            {
                ColumnWidths = "40 100 100 100",
                Border = new BorderInfo(BorderSide.All, 0.5f, Color.FromRgb(System.Drawing.Color.LightGray)),
                DefaultCellBorder = new BorderInfo(BorderSide.All, 0.5f, Color.FromRgb(System.Drawing.Color.LightGray))
            };

            // Import DataTable into the table (skip header row)
            table.ImportDataTable(dt, true, 0, 1, 3, 3);

            // Add table to the first page
            doc.Pages[1].Paragraphs.Add(table);

            // Save output PDF
            string outputPath = Path.Combine(outputDir, "DataIntegrated_out.pdf");
            doc.Save(outputPath);

            Console.WriteLine("\nDatabase integrated successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error during PDF generation: " + ex.Message);
        }
    }
}