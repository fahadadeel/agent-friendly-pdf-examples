using System;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Example demonstrating creation of a PDF by binding XML and XSLT files.
/// </summary>
namespace Examples.Core.AsposePDF.Working_With_XML_XSLT;

public class HelloWorldPDFUsingXmlAndXslt
{
    /// <summary>
    /// Runs the example.
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

            // Define file paths.
            string xmlPath = Path.Combine(inputDir, "HelloWorld.xml");
            string xsltPath = Path.Combine(inputDir, "HelloWorld.xslt");
            string outputPath = Path.Combine(outputDir, "HelloWorldPDFUsingXmlAndXslt.pdf");

            // Create PDF document.
            Document pdf = new Document();

            // Bind XML and XSLT files to the document.
            pdf.BindXml(xmlPath, xsltPath);

            // Save the document.
            pdf.Save(outputPath);

            Console.WriteLine($"PDF successfully created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF creation: {ex.Message}");
        }
    }
}