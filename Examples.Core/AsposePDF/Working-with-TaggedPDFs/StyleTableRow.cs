using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using Aspose.Pdf.Text;
using System;
using System.IO;

/// <summary>
/// Example demonstrating how to style table rows in a tagged PDF using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

public class StyleTableRow
{
    /// <summary>
    /// Executes the example. Creates a tagged PDF with styled table rows,
    /// saves it to the output directory, and validates PDF/UA compliance
    /// using an external XML file from the input directory.
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

            // Paths for the generated PDF and the validation XML.
            string pdfPath = Path.Combine(outputDir, "StyleTableRow.pdf");
            string xmlPath = Path.Combine(inputDir, "StyleTableRow.xml");

            // Create a new PDF document.
            Document document = new Document();
            ITaggedContent taggedContent = document.TaggedContent;

            taggedContent.SetTitle("Example table row style");
            taggedContent.SetLanguage("en-US");

            // Get root structure element.
            StructureElement rootElement = taggedContent.RootElement;

            // Create table structure element.
            TableElement tableElement = taggedContent.CreateTableElement();
            rootElement.AppendChild(tableElement);

            TableTHeadElement tableTHeadElement = tableElement.CreateTHead();
            TableTBodyElement tableTBodyElement = tableElement.CreateTBody();
            TableTFootElement tableTFootElement = tableElement.CreateTFoot();

            int rowCount = 7;
            int colCount = 3;

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

                trElement.BackgroundColor = Color.LightGoldenrodYellow;
                trElement.Border = new BorderInfo(BorderSide.All, 0.75F, Color.DarkGray);

                trElement.DefaultCellBorder = new BorderInfo(BorderSide.All, 0.50F, Color.Blue);
                trElement.MinRowHeight = 100.0;
                trElement.FixedRowHeight = 120.0;
                trElement.IsInNewPage = (rowIndex % 3 == 1);
                trElement.IsRowBroken = true;

                TextState cellTextState = new TextState
                {
                    ForegroundColor = Color.Red
                };
                trElement.DefaultCellTextState = cellTextState;

                trElement.DefaultCellPadding = new MarginInfo(16.0, 2.0, 8.0, 2.0);
                trElement.VerticalAlignment = VerticalAlignment.Bottom;

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

            // Validate PDF/UA compliance using the external XML file.
            document = new Document(pdfPath);
            bool isPdfUaCompliance = document.Validate(xmlPath, PdfFormat.PDF_UA_1);
            Console.WriteLine($"PDF/UA compliance: {isPdfUaCompliance}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred in StyleTableRow.Run: {ex.Message}");
        }
    }
}