using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Tables;

/// <summary>
/// Demonstrates adding an SVG image inside a table cell and saving the PDF.
/// </summary>
public class AddSVGObject
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

            // Input SVG file path.
            string svgPath = Path.Combine(inputDir, "SVGToPDF.svg");
            if (!File.Exists(svgPath))
            {
                Console.WriteLine($"Input SVG file not found: {svgPath}");
                return;
            }

            // Output PDF file path.
            string outputPdfPath = Path.Combine(outputDir, "AddSVGObject_out.pdf");

            // Instantiate Document object.
            Document doc = new Document();

            // Create an image instance and configure it as SVG.
            Aspose.Pdf.Image img = new Aspose.Pdf.Image
            {
                FileType = Aspose.Pdf.ImageFileType.Svg,
                File = svgPath,
                FixWidth = 50,
                FixHeight = 50
            };

            // Create table instance and set column widths.
            Aspose.Pdf.Table table = new Aspose.Pdf.Table
            {
                ColumnWidths = "100 100"
            };

            // Create a row and add cells.
            Aspose.Pdf.Row row = table.Rows.Add();

            // First cell with text.
            Aspose.Pdf.Cell cell = row.Cells.Add();
            cell.Paragraphs.Add(new TextFragment("First cell"));

            // Second cell with SVG image.
            cell = row.Cells.Add();
            cell.Paragraphs.Add(img);

            // Add a page and place the table on it.
            Page page = doc.Pages.Add();
            page.Paragraphs.Add(table);

            // Save the PDF.
            doc.Save(outputPdfPath);

            Console.WriteLine("\nSVG image added successfully inside a table cell.\nFile saved at " + outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing AddSVGObject example: {ex.Message}");
        }
    }
}