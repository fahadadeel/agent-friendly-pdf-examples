using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Tables;

public class ReplaceTable
{
    /// <summary>
    /// Demonstrates how to replace a table in a PDF document using Aspose.Pdf.
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

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "Table_input.pdf");
            string outputPath = Path.Combine(outputDir, "TableReplaced_out.pdf");

            // Load existing PDF document.
            Document pdfDocument = new Document(inputPath);

            // Create TableAbsorber object to find tables.
            TableAbsorber absorber = new TableAbsorber();

            // Visit first page with absorber.
            absorber.Visit(pdfDocument.Pages[1]);

            // Get first table on the page.
            AbsorbedTable table = absorber.TableList[0];

            // Create new table.
            Table newTable = new Table
            {
                ColumnWidths = "100 100 100",
                DefaultCellBorder = new BorderInfo(BorderSide.All, 1f)
            };

            Row row = newTable.Rows.Add();
            row.Cells.Add("Col 1");
            row.Cells.Add("Col 2");
            row.Cells.Add("Col 3");

            // Replace the table with the new one.
            absorber.Replace(pdfDocument.Pages[1], table, newTable);

            // Save the modified document.
            pdfDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ReplaceTable.Run: {ex.Message}");
        }
    }
}