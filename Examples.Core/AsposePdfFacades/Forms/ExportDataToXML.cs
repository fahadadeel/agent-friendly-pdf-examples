using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

public class ExportDataToXML
{
    /// <summary>
    /// Demonstrates exporting form data from a PDF to an XML file using Aspose.Pdf.Facades.
    /// </summary>
    public static void Run()
    {
        // ExStart:ExportDataToXML
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPdfPath = Path.Combine(inputDir, "input.pdf");
            string outputXmlPath = Path.Combine(outputDir, "input.xml");

            // Open document using Form facade.
            using var form = new Form();

            form.BindPdf(inputPdfPath);

            // Export data to XML using a file stream.
            using var xmlOutputStream = new FileStream(outputXmlPath, FileMode.Create, FileAccess.Write);
            form.ExportXml(xmlOutputStream);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during ExportDataToXML: {ex.Message}");
        }
        // ExEnd:ExportDataToXML
    }
}