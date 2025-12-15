using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Working_With_XML_XSLT;

/// <summary>
/// Demonstrates creating a PDF document from XML and XSLT files using Aspose.Pdf.
/// </summary>
public class BreakfastMenuUsingXmlAndXslt
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Define input file paths.
            string xmlPath = Path.Combine(inputDir, "Breakfast.xml");
            string xsltPath = Path.Combine(inputDir, "Breakfast.xslt");

            // Define output file path.
            string outputPath = Path.Combine(outputDir, "BreakfastMenu.pdf");

            // Create a new PDF document.
            Document pdf = new Document();

            // Bind the XML and XSLT files to the document.
            pdf.BindXml(xmlPath, xsltPath);

            // Save the resulting PDF.
            pdf.Save(outputPath);

            Console.WriteLine($"PDF successfully created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while generating the PDF: {ex.Message}");
        }
    }
}