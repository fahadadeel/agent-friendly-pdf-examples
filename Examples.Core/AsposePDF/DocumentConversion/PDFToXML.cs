using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

public class PDFToXML
{
    /// <summary>
    /// Converts a PDF document to XML (MobiXml) format.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine the base directory of the application.
            string baseDir = AppContext.BaseDirectory;

            // Resolve input and output paths.
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "PDFToXML_out.xml");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load source PDF file.
            Document doc = new Document(inputPath);

            // Save output in XML format (MobiXml).
            doc.Save(outputPath, SaveFormat.MobiXml);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF to XML conversion: {ex.Message}");
        }
    }
}