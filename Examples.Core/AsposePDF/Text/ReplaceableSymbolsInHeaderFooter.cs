using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates how to use replaceable symbols in header and footer with Aspose.Pdf.
/// </summary>
public class ReplaceableSymbolsInHeaderFooter
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output path
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "ReplaceableSymbolsInHeaderFooter_out.pdf");

            // Create a new PDF document
            Document doc = new Document();
            Page page = doc.Pages.Add();

            // Set page margins
            MarginInfo marginInfo = new MarginInfo
            {
                Top = 90,
                Bottom = 50,
                Left = 50,
                Right = 50
            };
            page.PageInfo.Margin = marginInfo;

            // Create header
            HeaderFooter hfFirst = new HeaderFooter();
            page.Header = hfFirst;
            hfFirst.Margin.Left = 50;
            hfFirst.Margin.Right = 50;

            // Header title
            TextFragment t1 = new TextFragment("report title")
            {
                TextState =
                {
                    Font = FontRepository.FindFont("Arial"),
                    FontSize = 16,
                    ForegroundColor = Aspose.Pdf.Color.Black,
                    FontStyle = FontStyles.Bold,
                    HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center,
                    LineSpacing = 5f
                }
            };
            hfFirst.Paragraphs.Add(t1);

            // Header subtitle
            TextFragment t2 = new TextFragment("Report_Name")
            {
                TextState =
                {
                    Font = FontRepository.FindFont("Arial"),
                    ForegroundColor = Aspose.Pdf.Color.Black,
                    HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center,
                    LineSpacing = 5f,
                    FontSize = 12
                }
            };
            hfFirst.Paragraphs.Add(t2);

            // Create footer
            HeaderFooter hfFoot = new HeaderFooter();
            page.Footer = hfFoot;
            hfFoot.Margin.Left = 50;
            hfFoot.Margin.Right = 50;

            // Footer text fragments
            TextFragment t3 = new TextFragment("Generated on test date");
            TextFragment t4 = new TextFragment("report name ");
            TextFragment t5 = new TextFragment("Page $p of $P");

            // Footer table
            Table tab2 = new Table
            {
                ColumnWidths = "165 172 165"
            };
            hfFoot.Paragraphs.Add(tab2);

            Row row3 = tab2.Rows.Add();
            row3.Cells.Add();
            row3.Cells.Add();
            row3.Cells.Add();

            row3.Cells[0].Alignment = Aspose.Pdf.HorizontalAlignment.Left;
            row3.Cells[1].Alignment = Aspose.Pdf.HorizontalAlignment.Center;
            row3.Cells[2].Alignment = Aspose.Pdf.HorizontalAlignment.Right;

            row3.Cells[0].Paragraphs.Add(t3);
            row3.Cells[1].Paragraphs.Add(t4);
            row3.Cells[2].Paragraphs.Add(t5);

            // Main content table
            Table table = new Table
            {
                ColumnWidths = "33% 33% 34%",
                DefaultCellPadding = new MarginInfo { Top = 10, Bottom = 10 },
                DefaultCellBorder = new BorderInfo(BorderSide.All, 0.1f),
                Border = new BorderInfo(BorderSide.All, 1f),
                RepeatingRowsCount = 1
            };
            page.Paragraphs.Add(table);

            // Header row for the table
            Row headerRow = table.Rows.Add();
            headerRow.Cells.Add("col1");
            headerRow.Cells.Add("col2");
            headerRow.Cells.Add("col3");

            const string CRLF = "\r\n";
            for (int i = 0; i <= 10; i++)
            {
                Row row = table.Rows.Add();
                row.IsRowBroken = true;

                for (int c = 0; c <= 2; c++)
                {
                    Cell cell;
                    if (c == 2)
                    {
                        cell = row.Cells.Add(
                            "Aspose.Total for Java is a compilation of every Java component offered by Aspose. It is compiled on a" + CRLF +
                            "daily basis to ensure it contains the most up to date versions of each of our Java components. " + CRLF +
                            "daily basis to ensure it contains the most up to date versions of each of our Java components. " + CRLF +
                            "Using Aspose.Total for Java developers can create a wide range of applications.");
                    }
                    else
                    {
                        cell = row.Cells.Add("item1" + c);
                    }

                    cell.Margin = new MarginInfo
                    {
                        Left = 30,
                        Top = 10,
                        Bottom = 10
                    };
                }
            }

            // Save the document
            doc.Save(outputPath);
            Console.WriteLine("\nSymbols replaced successfully in header and footer.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during execution: {ex.Message}");
        }
    }
}