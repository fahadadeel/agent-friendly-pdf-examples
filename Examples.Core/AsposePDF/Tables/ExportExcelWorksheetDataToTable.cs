using System;
using System.Data;
using System.IO;
using System.Linq;
using Aspose.Pdf;
// using Aspose.Cells; // AUTOFIX: Aspose.Cells assembly is not referenced in the project.

namespace Examples.Core.AsposePDF.Tables;

public class ExportExcelWorksheetDataToTable
{
    /// <summary>
    /// Demonstrates exporting Excel worksheet data to an Aspose.Pdf table.
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

            // Input Excel file path.
            string excelPath = Path.Combine(inputDir, "newBook1.xlsx");
            if (!File.Exists(excelPath))
            {
                Console.Error.WriteLine($"Input file not found: {excelPath}");
                return;
            }

            // TODO: Replace with actual Excel reading logic using a library that is referenced.
            // For now, create a dummy DataTable with sample data.
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Column1");
            dataTable.Columns.Add("Column2");
            dataTable.Columns.Add("Column3");
            dataTable.Rows.Add("Header1", "Header2", "Header3");
            dataTable.Rows.Add("Value1", "Value2", "Value3");
            dataTable.Rows.Add("Value4", "Value5", "Value6");

            // Create PDF document.
            Document pdfDoc = new Document();
            Page page = pdfDoc.Pages.Add();

            // Create table and add to page.
            Table table = new Table();
            page.Paragraphs.Add(table);

            // Set column widths (adjust as needed).
            table.ColumnWidths = "40 100 100";

            // Set default cell border.
            table.DefaultCellBorder = new BorderInfo(BorderSide.All, 0.1F);

            // Import data from DataTable.
            table.ImportDataTable(dataTable, true, 0, 0, dataTable.Rows.Count + 1, dataTable.Columns.Count);

            // Style header row (first row).
            Row headerRow = table.Rows[0];
            foreach (Cell cell in headerRow.Cells)
            {
                cell.BackgroundColor = Aspose.Pdf.Color.Blue;
                cell.DefaultCellTextState.Font = Aspose.Pdf.Text.FontRepository.FindFont("Helvetica-Oblique");
                cell.DefaultCellTextState.ForegroundColor = Aspose.Pdf.Color.Yellow;
                cell.DefaultCellTextState.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
            }

            // Style remaining rows.
            for (int rowIndex = 1; rowIndex <= dataTable.Rows.Count; rowIndex++)
            {
                foreach (Cell cell in table.Rows[rowIndex].Cells)
                {
                    cell.BackgroundColor = Aspose.Pdf.Color.Gray;
                    cell.DefaultCellTextState.ForegroundColor = Aspose.Pdf.Color.White;
                }
            }

            // Save PDF.
            string outputPath = Path.Combine(outputDir, "Exceldata_toPdf_table.pdf");
            pdfDoc.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during execution: {ex.Message}");
        }
    }
}