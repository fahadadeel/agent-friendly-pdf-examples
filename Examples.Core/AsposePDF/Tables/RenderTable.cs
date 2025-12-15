using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Tables;

/// <summary>
/// Demonstrates rendering tables on a PDF document using Aspose.Pdf.
/// </summary>
public class RenderTable
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new PDF document.
            Document doc = new Document();
            PageInfo pageInfo = doc.PageInfo;
            Aspose.Pdf.MarginInfo marginInfo = pageInfo.Margin;

            marginInfo.Left = 37;
            marginInfo.Right = 37;
            marginInfo.Top = 37;
            marginInfo.Bottom = 37;

            pageInfo.IsLandscape = true;

            // First table.
            Aspose.Pdf.Table table = new Aspose.Pdf.Table
            {
                ColumnWidths = "50 100"
            };

            // Add a page to the document.
            Page curPage = doc.Pages.Add();

            for (int i = 1; i <= 120; i++)
            {
                Aspose.Pdf.Row row = table.Rows.Add();
                row.FixedRowHeight = 15;

                Aspose.Pdf.Cell cell1 = row.Cells.Add();
                cell1.Paragraphs.Add(new TextFragment("Content 1"));

                Aspose.Pdf.Cell cell2 = row.Cells.Add();
                cell2.Paragraphs.Add(new TextFragment("HHHHH"));
            }

            Aspose.Pdf.Paragraphs paragraphs = curPage.Paragraphs;
            paragraphs.Add(table);

            // Second table.
            Aspose.Pdf.Table table1 = new Aspose.Pdf.Table
            {
                ColumnWidths = "100 100"
            };

            for (int i = 1; i <= 10; i++)
            {
                Aspose.Pdf.Row row = table1.Rows.Add();

                Aspose.Pdf.Cell cell1 = row.Cells.Add();
                cell1.Paragraphs.Add(new TextFragment("LAAAAAAA"));

                Aspose.Pdf.Cell cell2 = row.Cells.Add();
                cell2.Paragraphs.Add(new TextFragment("LAAGGGGGG"));
            }

            table1.IsInNewPage = true; // Keep table1 on a new page.
            paragraphs.Add(table1);

            // Save the document to the output directory.
            string outputPath = Path.Combine(outputDir, "IsNewPageProperty_Test_out.pdf");
            doc.Save(outputPath);

            Console.WriteLine($"\nTable rendered successfully on a page.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while rendering tables: {ex.Message}");
        }
    }
}