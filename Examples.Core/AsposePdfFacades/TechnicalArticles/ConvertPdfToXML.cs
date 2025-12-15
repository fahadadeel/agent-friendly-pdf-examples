using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

/// <summary>
/// Demonstrates converting a PDF file to XML using Aspose.Pdf.Facades.FormDataConverter.
/// </summary>
public class ConvertPdfToXML
{
    /// <summary>
    /// Executes the PDF‑to‑XML conversion.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
        string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Define full paths for the input PDF and the output XML.
        string inputPath = Path.Combine(inputDir, "inFile.pdf");
        string outputPath = Path.Combine(outputDir, "ConvertPdfToXML_out.xml");

        try
        {
            // Open streams for the input PDF and the output XML.
            using var fdfInputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using var xmlOutputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            // Perform the conversion.
            FormDataConverter.ConvertFdfToXml(fdfInputStream, xmlOutputStream);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF to XML conversion: {ex.Message}");
        }
    }
}