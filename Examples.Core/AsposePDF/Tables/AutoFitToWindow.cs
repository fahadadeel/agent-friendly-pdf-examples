using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Tables;

/// <summary>
/// Demonstrates AutoFitToWindow table column adjustment using Aspose.Pdf.
/// </summary>
public class AutoFitToWindow
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

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input directory is not used in this example, but kept for parity with legacy code.
            // string dataDir = inputDir; // legacy placeholder

            // Instantiate the Pdf object by calling its empty constructor
            Document doc = new Document();

            // Create the section in the Pdf object
            Page sec1 = doc.Pages.Add();

            // Instantiate a table object
            Table tab1 = new Table();

            // Add the table in paragraphs collection of the desired section
            sec1.Paragraphs.Add(tab1);

            // Set column widths of the table
            tab1.ColumnWidths = "50 50 50";
            tab1.ColumnAdjustment = ColumnAdjustment.AutoFitToWindow;

            // Set default cell border using BorderInfo object
            tab1.DefaultCellBorder = new BorderInfo(BorderSide.All, 0.1F);

            // Set table border using another customized BorderInfo object
            tab1.Border = new BorderInfo(BorderSide.All, 1F);

            // Create MarginInfo object and set its left, bottom, right and top margins
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
            row1.Cells.Add("col3");

            Row row2 = tab1.Rows.Add();
            row2.Cells.Add("item1");
            row2.Cells.Add("item2");
            row2.Cells.Add("item3");

            // Define output file path
            string outputPath = Path.Combine(outputDir, "AutoFitToWindow_out.pdf");

            // Save updated document containing table object
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AutoFitToWindow.Run: {ex.Message}");
        }
    }
}