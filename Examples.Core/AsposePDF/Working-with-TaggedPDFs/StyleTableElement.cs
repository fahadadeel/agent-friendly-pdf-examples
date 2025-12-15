using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using Aspose.Pdf.Text;
using System;
using System.IO;

/// <summary>
/// Example demonstrating how to create a styled table in a tagged PDF using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

public class StyleTableElement
{
    /// <summary>
    /// Creates a tagged PDF with a styled table, saves it, and checks PDF/UA compliance.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Define output file paths.
        string pdfPath = Path.Combine(outputDir, "StyleTableElement.pdf");
        string validationXmlPath = Path.Combine(outputDir, "StyleTableElement.xml");

        try
        {
            // Create a new PDF document.
            Document document = new Document();
            ITaggedContent taggedContent = document.TaggedContent;

            taggedContent.SetTitle("Example table style");
            taggedContent.SetLanguage("en-US");

            // Get root structure element.
            StructureElement rootElement = taggedContent.RootElement;

            // Create table structure element and attach it to the root.
            TableElement tableElement = taggedContent.CreateTableElement();
            rootElement.AppendChild(tableElement);

            // Configure table appearance.
            tableElement.BackgroundColor = Color.Beige;
            tableElement.Border = new BorderInfo(BorderSide.All, 0.80F, Color.Gray);
            tableElement.Alignment = HorizontalAlignment.Center;
            tableElement.Broken = TableBroken.Vertical;
            tableElement.ColumnAdjustment = ColumnAdjustment.AutoFitToWindow;
            tableElement.ColumnWidths = "80 80 80 80 80";
            tableElement.DefaultCellBorder = new BorderInfo(BorderSide.All, 0.50F, Color.DarkBlue);
            tableElement.DefaultCellPadding = new MarginInfo(16.0, 2.0, 8.0, 2.0);
            tableElement.DefaultCellTextState.ForegroundColor = Color.DarkCyan;
            tableElement.DefaultCellTextState.FontSize = 8F;
            tableElement.DefaultColumnWidth = "70";

            tableElement.IsBroken = false;
            tableElement.IsBordersIncluded = true;

            tableElement.Left = 0F;
            tableElement.Top = 40F;

            tableElement.RepeatingColumnsCount = 2;
            tableElement.RepeatingRowsCount = 3;

            TextState rowStyle = new TextState
            {
                BackgroundColor = Color.LightCoral
            };
            tableElement.RepeatingRowsStyle = rowStyle;

            // Create table sections.
            TableTHeadElement tableTHeadElement = tableElement.CreateTHead();
            TableTBodyElement tableTBodyElement = tableElement.CreateTBody();
            TableTFootElement tableTFootElement = tableElement.CreateTFoot();

            int rowCount = 10;
            int colCount = 5;

            // Header row.
            TableTRElement headTrElement = tableTHeadElement.CreateTR();
            headTrElement.AlternativeText = "Head Row";

            for (int colIndex = 0; colIndex < colCount; colIndex++)
            {
                TableTHElement thElement = headTrElement.CreateTH();
                thElement.SetText(string.Format("Head {0}", colIndex));
            }

            // Body rows.
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                TableTRElement trElement = tableTBodyElement.CreateTR();
                trElement.AlternativeText = string.Format("Row {0}", rowIndex);

                for (int colIndex = 0; colIndex < colCount; colIndex++)
                {
                    TableTDElement tdElement = trElement.CreateTD();
                    tdElement.SetText(string.Format("Cell [{0}, {1}]", rowIndex, colIndex));
                }
            }

            // Footer row.
            TableTRElement footTrElement = tableTFootElement.CreateTR();
            footTrElement.AlternativeText = "Foot Row";

            for (int colIndex = 0; colIndex < colCount; colIndex++)
            {
                TableTDElement tdElement = footTrElement.CreateTD();
                tdElement.SetText(string.Format("Foot {0}", colIndex));
            }

            // Save the tagged PDF document.
            document.Save(pdfPath);

            // Validate PDF/UA compliance.
            Document loadedDoc = new Document(pdfPath);
            bool isPdfUaCompliance = loadedDoc.Validate(validationXmlPath, PdfFormat.PDF_UA_1);
            Console.WriteLine(string.Format("PDF/UA compliance: {0}", isPdfUaCompliance));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while processing the PDF: {ex.Message}");
        }
    }
}