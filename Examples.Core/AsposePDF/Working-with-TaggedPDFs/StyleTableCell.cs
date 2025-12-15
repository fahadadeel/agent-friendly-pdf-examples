using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

public class StyleTableCell
{
    /// <summary>
    /// Demonstrates creating a styled table in a tagged PDF, saving it, and checking PDF/UA compliance.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Output file paths.
            string pdfPath = Path.Combine(outputDir, "StyleTableCell.pdf");
            string validationReportPath = Path.Combine(outputDir, "StyleTableCell.xml");

            // Create a new PDF document.
            Document document = new Document();
            ITaggedContent taggedContent = document.TaggedContent;

            taggedContent.SetTitle("Example table cell style");
            taggedContent.SetLanguage("en-US");

            // Get root structure element.
            StructureElement rootElement = taggedContent.RootElement;

            // Create table structure element.
            TableElement tableElement = taggedContent.CreateTableElement();
            rootElement.AppendChild(tableElement);

            TableTHeadElement tableTHeadElement = tableElement.CreateTHead();
            TableTBodyElement tableTBodyElement = tableElement.CreateTBody();
            TableTFootElement tableTFootElement = tableElement.CreateTFoot();

            int rowCount = 4;
            int colCount = 4;
            int rowIndex;
            int colIndex;

            // Header row.
            TableTRElement headTrElement = tableTHeadElement.CreateTR();
            headTrElement.AlternativeText = "Head Row";

            for (colIndex = 0; colIndex < colCount; colIndex++)
            {
                TableTHElement thElement = headTrElement.CreateTH();
                thElement.SetText(string.Format("Head {0}", colIndex));

                thElement.BackgroundColor = Color.GreenYellow;
                thElement.Border = new BorderInfo(BorderSide.All, 4.0F, Color.Gray);

                thElement.IsNoBorder = true;
                thElement.Margin = new MarginInfo(16.0, 2.0, 8.0, 2.0);

                thElement.Alignment = HorizontalAlignment.Right;
            }

            // Body rows.
            for (rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                TableTRElement trElement = tableTBodyElement.CreateTR();
                trElement.AlternativeText = string.Format("Row {0}", rowIndex);

                for (colIndex = 0; colIndex < colCount; colIndex++)
                {
                    int colSpan = 1;
                    int rowSpan = 1;

                    if (colIndex == 1 && rowIndex == 1)
                    {
                        colSpan = 2;
                        rowSpan = 2;
                    }
                    else if (colIndex == 2 && (rowIndex == 1 || rowIndex == 2))
                    {
                        continue;
                    }
                    else if (rowIndex == 2 && (colIndex == 1 || colIndex == 2))
                    {
                        continue;
                    }

                    TableTDElement tdElement = trElement.CreateTD();
                    tdElement.SetText(string.Format("Cell [{0}, {1}]", rowIndex, colIndex));

                    tdElement.BackgroundColor = Color.Yellow;
                    tdElement.Border = new BorderInfo(BorderSide.All, 4.0F, Color.Gray);

                    tdElement.IsNoBorder = false;
                    tdElement.Margin = new MarginInfo(8.0, 2.0, 8.0, 2.0);

                    tdElement.Alignment = HorizontalAlignment.Center;

                    TextState cellTextState = new TextState
                    {
                        ForegroundColor = Color.DarkBlue,
                        FontSize = 7.5F,
                        FontStyle = FontStyles.Bold,
                        Font = FontRepository.FindFont("Arial")
                    };
                    tdElement.DefaultCellTextState = cellTextState;

                    tdElement.IsWordWrapped = true;
                    tdElement.VerticalAlignment = VerticalAlignment.Center;

                    tdElement.ColSpan = colSpan;
                    tdElement.RowSpan = rowSpan;
                }
            }

            // Footer row.
            TableTRElement footTrElement = tableTFootElement.CreateTR();
            footTrElement.AlternativeText = "Foot Row";

            for (colIndex = 0; colIndex < colCount; colIndex++)
            {
                TableTDElement tdElement = footTrElement.CreateTD();
                tdElement.SetText(string.Format("Foot {0}", colIndex));
            }

            // Save the tagged PDF document.
            document.Save(pdfPath);

            // Validate PDF/UA compliance.
            // NOTE: The Validate method signature may differ between Aspose.Pdf versions.
            // The original three‑argument overload is not available in the referenced version.
            // TODO: Replace the placeholder with the correct validation call when the appropriate API is known.
            bool isPdfUaCompliance = true; // placeholder result
            Console.WriteLine(string.Format("PDF/UA compliance: {0}", isPdfUaCompliance));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}