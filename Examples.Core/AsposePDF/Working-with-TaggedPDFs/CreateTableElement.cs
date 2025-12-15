using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

/// <summary>
/// Demonstrates how to create a tagged PDF with a table element using Aspose.Pdf.
/// </summary>
public class CreateTableElement
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string outputPdfPath = Path.Combine(outputDir, "CreateTableElement.pdf");
            string validationXmlPath = Path.Combine(inputDir, "table.xml");

            // Create a new PDF document.
            Document document = new Document();
            ITaggedContent taggedContent = document.TaggedContent;

            taggedContent.SetTitle("Example table");
            taggedContent.SetLanguage("en-US");

            // Get root structure element.
            StructureElement rootElement = taggedContent.RootElement;

            // Create table element and add it to the root.
            TableElement tableElement = taggedContent.CreateTableElement();
            rootElement.AppendChild(tableElement);

            tableElement.Border = new BorderInfo(BorderSide.All, 1.2F, Color.DarkBlue);

            TableTHeadElement tableTHeadElement = tableElement.CreateTHead();
            TableTBodyElement tableTBodyElement = tableElement.CreateTBody();
            TableTFootElement tableTFootElement = tableElement.CreateTFoot();

            int rowCount = 50;
            int colCount = 4;

            // Header row.
            TableTRElement headTrElement = tableTHeadElement.CreateTR();
            headTrElement.AlternativeText = "Head Row";
            headTrElement.BackgroundColor = Color.LightGray;

            for (int colIndex = 0; colIndex < colCount; colIndex++)
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
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                TableTRElement trElement = tableTBodyElement.CreateTR();
                trElement.AlternativeText = string.Format("Row {0}", rowIndex);

                for (int colIndex = 0; colIndex < colCount; colIndex++)
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
            footTrElement.BackgroundColor = Color.LightSeaGreen;

            for (int colIndex = 0; colIndex < colCount; colIndex++)
            {
                TableTDElement tdElement = footTrElement.CreateTD();
                tdElement.SetText(string.Format("Foot {0}", colIndex));
                tdElement.Alignment = HorizontalAlignment.Center;
                tdElement.StructureTextState.FontSize = 7F;
                tdElement.StructureTextState.FontStyle = FontStyles.Bold;
            }

            // Add summary attribute to the table.
            StructureAttributes tableAttributes = tableElement.Attributes.GetAttributes(AttributeOwnerStandard.Table);
            StructureAttribute summaryAttribute = new StructureAttribute(AttributeKey.Summary);
            summaryAttribute.SetStringValue("The summary text for table");
            tableAttributes.SetAttribute(summaryAttribute);

            // Save the tagged PDF document.
            document.Save(outputPdfPath);

            // Validate PDF/UA compliance.
            Document loadedDoc = new Document(outputPdfPath);
            bool isPdfUaCompliance = loadedDoc.Validate(validationXmlPath, PdfFormat.PDF_UA_1);
            Console.WriteLine(string.Format("PDF/UA compliance: {0}", isPdfUaCompliance));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing CreateTableElement example: {ex.Message}");
        }
    }
}