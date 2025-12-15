using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Tables;

/// <summary>
/// Demonstrates setting double borders on a table cell using Aspose.Pdf.
/// </summary>
public class SetBorder
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

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // The example does not read any input file, but the input directory is prepared for consistency.
            // string dataDir = inputDir; // Not used further.

            // Instantiate Document object.
            Document doc = new Document();

            // Add page to PDF document.
            Page page = doc.Pages.Add();

            // Create BorderInfo object with all sides.
            BorderInfo border = new BorderInfo(BorderSide.All);

            // Specify that Top and Bottom borders will be double.
            border.Top.IsDoubled = true;
            border.Bottom.IsDoubled = true;

            // Instantiate Table object.
            Table table = new Table
            {
                ColumnWidths = "100"
            };

            // Create Row object.
            Row row = table.Rows.Add();

            // Add a Table cell to cells collection of row.
            Cell cell = row.Cells.Add("some text");

            // Set the border for cell object (double border).
            cell.Border = border;

            // Add table to paragraphs collection of Page.
            page.Paragraphs.Add(table);

            // Define output file path.
            string outputPath = Path.Combine(outputDir, "TableBorderTest_out.pdf");

            // Save the PDF document.
            doc.Save(outputPath);

            Console.WriteLine($"\nBorder setup successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing SetBorder example: {ex.Message}");
        }
    }
}