using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates placing text around an image using Aspose.Pdf.
/// </summary>
public class PlacingTextAroundImage
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
        try
        {
            Directory.CreateDirectory(outputDir);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to create output directory '{outputDir}': {ex.Message}");
            return;
        }

        // Paths for resources.
        string logoPath = Path.Combine(inputDir, "aspose-logo.jpg");
        string outputPath = Path.Combine(outputDir, "PlacingTextAroundImage_out.pdf");

        try
        {
            // Instantiate document object.
            Document doc = new Document();

            // Create a page in the PDF.
            Page page = doc.Pages.Add();

            // Instantiate a table object.
            Table table1 = new Table();

            // Add the table to the page's paragraphs collection.
            page.Paragraphs.Add(table1);

            // Set column widths of the table.
            table1.ColumnWidths = "120 270";

            // Create MarginInfo object and set its margins.
            MarginInfo margin = new MarginInfo
            {
                Top = 5f,
                Left = 5f,
                Right = 5f,
                Bottom = 5f
            };

            // Set the default cell padding to the MarginInfo object.
            table1.DefaultCellPadding = margin;

            // Create the first row.
            Row row1 = table1.Rows.Add();

            // Create an image object.
            Image logo = new Image
            {
                File = logoPath,
                FixHeight = 120,
                FixWidth = 110
            };

            // Add a cell for the image and insert the image.
            row1.Cells.Add();
            row1.Cells[0].Paragraphs.Add(logo);

            // Create string variables with HTML content.
            string titleString = "<font face=\"Arial\" size=6 color=\"#101090\"><b> Aspose.Pdf for .NET</b></font>";
            string bodyString1 = "<font face=\"Arial\" size=2><br/>Aspose.Pdf for .NET is a non-graphical PDF� document reporting component that enables .NET applications to <b> create PDF documents from scratch </b> without utilizing Adobe Acrobat�. Aspose.Pdf for .NET is very affordably priced and offers a wealth of strong features including: compression, tables, graphs, images, hyperlinks, security and custom fonts. </font>";

            // Create a text object to be added to the right of the image.
            HtmlFragment titleText = new HtmlFragment(titleString + bodyString1);

            // Add a second cell for the text and insert the HTML fragment.
            row1.Cells.Add();
            row1.Cells[1].Paragraphs.Add(titleText);
            row1.Cells[1].VerticalAlignment = VerticalAlignment.Top;

            // Create the second row.
            Row secondRow = table1.Rows.Add();
            secondRow.Cells.Add();
            // Set the column span for the second row cell.
            secondRow.Cells[0].ColSpan = 2;
            secondRow.Cells[0].VerticalAlignment = VerticalAlignment.Top;

            string secondRowString = "<font face=\"Arial\" size=2>Aspose.Pdf for .NET supports the creation of PDF files through API and XML or XSL-FO templates. Aspose.Pdf for .NET is very easy to use and is provided with 14 fully featured demos written in both C# and Visual Basic.</font>";
            HtmlFragment secondRowText = new HtmlFragment(secondRowString);
            secondRow.Cells[0].Paragraphs.Add(secondRowText);

            // Save the PDF file.
            doc.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while creating the PDF: {ex.Message}");
        }
    }
}