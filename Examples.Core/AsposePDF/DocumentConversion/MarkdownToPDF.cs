using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates converting a Markdown file to PDF using Aspose.Pdf.
/// </summary>
public class MarkdownToPDF
{
    /// <summary>
    /// This feature is supported by version 19.6 or greater.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "sample.md");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "MarkdownToPDF.pdf");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Open Markdown document.
            Document doc = new Document(inputPath, new MdLoadOptions());

            // Save document in PDF format.
            doc.Save(outputPath);

            Console.WriteLine($"Markdown file converted successfully. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during Markdown to PDF conversion: {ex.Message}");
        }
    }
}