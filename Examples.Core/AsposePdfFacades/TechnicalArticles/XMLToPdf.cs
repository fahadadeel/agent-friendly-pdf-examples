using System;
using System.IO;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

/// <summary>
/// Demonstrates converting an XML file to PDF using Aspose.Pdf.Facades.
/// </summary>
public class XMLToPdf
{
    /// <summary>
    /// Executes the XML to PDF conversion.
    /// </summary>
    public static void Run()
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

        string inputPath = Path.Combine(inputDir, "log.xml");
        string outputPath = Path.Combine(outputDir, "XMLToPdf_out.pdf");

        try
        {
            using var src = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using var dest = new FileStream(outputPath, FileMode.Create, FileAccess.ReadWrite);
            FormDataConverter.ConvertXmlToFdf(src, dest);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during XML to PDF conversion: {ex.Message}");
        }
    }
}