using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates conversion of a PDF document to XPS format using Aspose.Pdf.
/// </summary>
public class PDFToXPS
{
    /// <summary>
    /// Executes the PDF to XPS conversion.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "PDFToXPS_out.xps");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load PDF document.
            Document pdfDocument = new Document(inputPath);

            // Instantiate XPS save options.
            XpsSaveOptions saveOptions = new XpsSaveOptions();

            // Save the XPS document.
            pdfDocument.Save(outputPath, saveOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during PDF to XPS conversion: {ex.Message}");
        }
    }
}