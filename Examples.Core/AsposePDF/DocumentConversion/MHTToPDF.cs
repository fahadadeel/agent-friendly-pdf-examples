using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates conversion of an MHT file to PDF using Aspose.Pdf.
/// </summary>
public class MHTToPDF
{
    /// <summary>
    /// Executes the MHT to PDF conversion.
    /// </summary>
    public static void Run()
    {
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
            string inputPath = Path.Combine(inputDir, "test.mht");
            string outputPath = Path.Combine(outputDir, "MHTToPDF_out.pdf");

            // Load MHT document with default options.
            MhtLoadOptions options = new MhtLoadOptions();

            // Load the document.
            Document document = new Document(inputPath, options);

            // Save as PDF.
            document.Save(outputPath);

            Console.WriteLine($"MHT file converted successfully. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during MHT to PDF conversion: {ex.Message}");
        }
    }
}