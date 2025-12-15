using System;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Example demonstrating how to add an image inside a table cell using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Tables;

public class AddImageInATableCell
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Input image file.
        string imagePath = Path.Combine(inputDir, "aspose.jpg");
        // Output PDF file.
        string outputPath = Path.Combine(outputDir, "AddImageInTableCell_out.pdf");

        try
        {
            // Instantiate a Document object.
            Document pdfDocument = new Document();

            // Create a page in the PDF document.
            Page page = pdfDocument.Pages.Add();

            // Instantiate a table object.
            Table table = new Table();

            // Add the table to the paragraphs collection of the desired page.
            page.Paragraphs.Add(table);

            // Set default cell border using BorderInfo object.
            table.DefaultCellBorder = new BorderInfo(BorderSide.All, 0.1F);

            // Set column widths of the table.
            table.ColumnWidths = "100 100 120";

            // Create an image and set its source file.
            Image img = new Image
            {
                File = imagePath
            };

            // Create rows in the table and then cells in the rows.
            Row row1 = table.Rows.Add();
            row1.Cells.Add("Sample text in cell");

            // Add the cell which holds the image.
            Cell cellWithImage = row1.Cells.Add();
            cellWithImage.Paragraphs.Add(img);

            // Add another cell after the image cell.
            row1.Cells.Add("Previous cell with image");

            // Align the third cell vertically to the center.
            row1.Cells[2].VerticalAlignment = VerticalAlignment.Center;

            // Save the document.
            pdfDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing AddImageInATableCell example: {ex.Message}");
        }
    }
}