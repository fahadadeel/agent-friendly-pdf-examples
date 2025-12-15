using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

public class TeXToPDF
{
    /// <summary>
    /// Converts a TeX file to PDF using Aspose.Pdf.
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

            // Input TeX file path.
            string inputPath = Path.Combine(inputDir, "samplefile.tex");
            // Output PDF file path.
            string outputPath = Path.Combine(outputDir, "TeXToPDF_out.pdf");

            // Instantiate TeX load options.
            TeXLoadOptions texOptions = new TeXLoadOptions();

            // Load the TeX document.
            Document doc = new Document(inputPath, texOptions);

            // Save as PDF.
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}