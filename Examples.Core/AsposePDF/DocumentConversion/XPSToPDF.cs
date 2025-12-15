using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates conversion of an XPS file to PDF using Aspose.Pdf.
/// </summary>
public class XPSToPDF
{
    /// <summary>
    /// Executes the conversion example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "XPSToPDF.xps");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "XPSToPDF_out.pdf");

            // Instantiate LoadOption object using XPS load option
            LoadOptions options = new XpsLoadOptions();

            // Create document object from XPS file
            Document document = new Document(inputPath, options);

            // Save the resultant PDF document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}