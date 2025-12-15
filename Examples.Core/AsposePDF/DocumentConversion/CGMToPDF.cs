using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates conversion of a CGM file to PDF using Aspose.Pdf.
/// </summary>
public class CGMToPDF
{
    /// <summary>
    /// Executes the CGM to PDF conversion.
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

            // Define full paths for the input CGM file and the output PDF file.
            string inputPath = Path.Combine(inputDir, "CGMToPDF.CGM");
            string outputPath = Path.Combine(outputDir, "TECHDRAW_out.pdf");

            // Instantiate load options for CGM files.
            CgmLoadOptions cgmLoadOptions = new CgmLoadOptions();

            // Load the CGM document using the specified options.
            Document doc = new Document(inputPath, cgmLoadOptions);

            // Save the document as a PDF.
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in CGMToPDF.Run: {ex.Message}");
        }
    }
}