using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates conversion of a PostScript (.ps) file to PDF using Aspose.Pdf.
/// </summary>
public static class PostscriptToPDF
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
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.ps");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "PSToPDF.pdf");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create load options for PostScript files.
            LoadOptions options = new PsLoadOptions();

            // Load the .ps document.
            Document pdfDocument = new Document(inputPath, options);

            // Save the resulting PDF.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"Conversion succeeded. PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PostScript to PDF conversion: {ex.Message}");
        }
    }
}