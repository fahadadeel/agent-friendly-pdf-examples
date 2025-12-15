using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates converting an XML file to PDF using Aspose.Pdf.
/// </summary>
public class XMLToPDF
{
    /// <summary>
    /// Executes the XML to PDF conversion example.
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

            // Input XML file path.
            string inputXmlPath = Path.Combine(inputDir, "sample.xml");
            if (!File.Exists(inputXmlPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputXmlPath}");
                return;
            }

            // Output PDF file path.
            string outputPdfPath = Path.Combine(outputDir, "XMLToPDF_out.pdf");

            // Instantiate Document object.
            Document doc = new Document();

            // Bind source XML file.
            doc.BindXml(inputXmlPath);

            // Get reference of page object from XML (optional usage example).
            Page page = (Page)doc.GetObjectById("mainSection");

            // Get reference of first TextSegment with ID boldHtml (optional usage example).
            TextSegment segment = (TextSegment)doc.GetObjectById("boldHtml");

            // Get reference of second TextSegment with ID strongHtml (optional usage example).
            segment = (TextSegment)doc.GetObjectById("strongHtml");

            // Save resultant PDF file.
            doc.Save(outputPdfPath);

            Console.WriteLine($"PDF successfully created at: {outputPdfPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during XML to PDF conversion: {ex.Message}");
        }
    }
}