using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Tables;

public class InsertPageBreak
{
    /// <summary>
    /// Demonstrates inserting page breaks into a PDF table using Aspose.Pdf.
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

            // Instantiate Document instance.
            Document doc = new Document();

            // Add a page to the pages collection of the PDF file.
            doc.Pages.Add();

            // Create table instance.
            Aspose.Pdf.Table tab = new Aspose.Pdf.Table();

            // Set border style for table.
            tab.Border = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, Aspose.Pdf.Color.Red);

            // Set default border style for table with border color as Red.
            tab.DefaultCellBorder = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, Aspose.Pdf.Color.Red);

            // Specify table columns width.
            tab.ColumnWidths = "100 100";

            // Create a loop to add 200 rows for the table.
            for (int counter = 0; counter <= 200; counter++)
            {
                Aspose.Pdf.Row row = new Aspose.Pdf.Row();
                tab.Rows.Add(row);

                Aspose.Pdf.Cell cell1 = new Aspose.Pdf.Cell();
                cell1.Paragraphs.Add(new TextFragment("Cell " + counter + ", 0"));
                row.Cells.Add(cell1);

                Aspose.Pdf.Cell cell2 = new Aspose.Pdf.Cell();
                cell2.Paragraphs.Add(new TextFragment("Cell " + counter + ", 1"));
                row.Cells.Add(cell2);

                // When 10 rows are added, render new row in new page.
                if (counter % 10 == 0 && counter != 0)
                {
                    row.IsInNewPage = true;
                }
            }

            // Add table to paragraphs collection of PDF file.
            doc.Pages[1].Paragraphs.Add(tab);

            // Define output file path.
            string outputPath = Path.Combine(outputDir, "InsertPageBreak_out.pdf");

            // Save the PDF document.
            doc.Save(outputPath);

            Console.WriteLine("\nPage break inserted successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("An error occurred while inserting page breaks: " + ex.Message);
        }
    }
}