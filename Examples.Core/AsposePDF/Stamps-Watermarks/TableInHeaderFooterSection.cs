using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Stamps_Watermarks;

public class TableInHeaderFooterSection
{
    /// <summary>
    /// Demonstrates adding a table with an image to the header section of a PDF document.
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

            // Path to the logo image.
            string logoPath = Path.Combine(inputDir, "aspose-logo.jpg");

            // Create a new PDF document.
            Document pdfDocument = new Document();
            // Add a page.
            Page page = pdfDocument.Pages.Add();

            // Create a header section.
            HeaderFooter header = new HeaderFooter();
            page.Header = header;
            header.Margin.Top = 20;

            // Create a table.
            Table tab1 = new Table();
            header.Paragraphs.Add(tab1);
            tab1.DefaultCellBorder = new BorderInfo(BorderSide.All, 0.1F);
            tab1.ColumnWidths = "60 300";

            // Create an image object.
            Image img = new Image
            {
                File = logoPath
            };

            // First row.
            Row row1 = tab1.Rows.Add();
            row1.Cells.Add("Table in Header Section");
            row1.BackgroundColor = Color.Gray;
            // Span across two columns.
            tab1.Rows[0].Cells[0].ColSpan = 2;
            tab1.Rows[0].Cells[0].DefaultCellTextState.ForegroundColor = Color.Cyan;
            tab1.Rows[0].Cells[0].DefaultCellTextState.Font = FontRepository.FindFont("Helvetica");

            // Second row.
            Row row2 = tab1.Rows.Add();
            row2.BackgroundColor = Color.White;

            // Cell with image.
            Cell cell2 = row2.Cells.Add();
            img.FixWidth = 60;
            cell2.Paragraphs.Add(img);

            // Text cell.
            row2.Cells.Add("Logo is looking fine !");
            row2.Cells[1].DefaultCellTextState.Font = FontRepository.FindFont("Helvetica");
            row2.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row2.Cells[1].Alignment = HorizontalAlignment.Center;

            // Save the PDF.
            string outputPath = Path.Combine(outputDir, "TableInHeaderFooterSection_out.pdf");
            pdfDocument.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in TableInHeaderFooterSection.Run: {ex.Message}");
        }
    }
}