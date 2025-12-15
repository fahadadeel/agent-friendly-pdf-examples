using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates importing form data from an XML file into a PDF using Aspose.Pdf.Facades.
/// </summary>
public class ImportDataFromXML
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // ExStart:ImportDataFromXML
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Define file paths.
            string inputXmlPath = Path.Combine(inputDir, "input.xml");
            string outputPdfPath = Path.Combine(outputDir, "ImportDataFromXML_out.pdf");

            // Open document facade.
            Form form = new Form();

            // Open XML file stream.
            using (FileStream xmlInputStream = File.OpenRead(inputXmlPath))
            {
                // Import data from XML.
                form.ImportXml(xmlInputStream);
            }

            // Save updated document.
            form.Save(outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during ImportDataFromXML example: {ex.Message}");
        }
        // ExEnd:ImportDataFromXML
    }
}