using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates conversion of an EPUB file to PDF using Aspose.Pdf.
/// </summary>
public class EPUBToPDF
{
    /// <summary>
    /// Executes the EPUB to PDF conversion.
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

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "EPUBToPDF.epub");
            string outputPath = Path.Combine(outputDir, "EPUBToPDF_out.pdf");

            // Instantiate load options for EPUB.
            var epubLoad = new EpubLoadOptions();

            // Load the EPUB document and convert it to PDF.
            var pdf = new Document(inputPath, epubLoad);

            // Save the resulting PDF document.
            pdf.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}