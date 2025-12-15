using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates converting an XML file to PDF while setting an image path using Aspose.Pdf.
/// </summary>
public class XMLToPDFSetImagePath
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

            // Input files.
            string inXml = Path.Combine(inputDir, "input.xml");
            string inFile = Path.Combine(inputDir, "aspose-logo.jpg");

            // Output file.
            string outFile = Path.Combine(outputDir, "output_out.pdf");

            // Create a new PDF document and bind the XML.
            Document doc = new Document();
            doc.BindXml(inXml);

            // Retrieve the image object by its ID and set the external image file.
            Image image = (Image)doc.GetObjectById("testImg");
            image.File = inFile;

            // Save the resulting PDF.
            doc.Save(outFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}