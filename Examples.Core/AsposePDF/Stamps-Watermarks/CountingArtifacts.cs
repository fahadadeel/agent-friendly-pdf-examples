using System;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Demonstrates counting watermark artifacts in a PDF document.
/// </summary>
namespace Examples.Core.AsposePDF.StampsWatermarks;

public class CountingArtifacts
{
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "watermark.pdf");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open document using path overload.
            Document pdfDocument = new Document(inputPath);

            int count = 0;
            // Assuming the document has at least one page.
            if (pdfDocument.Pages.Count > 0)
            {
                foreach (Artifact artifact in pdfDocument.Pages[1].Artifacts)
                {
                    if (artifact.Subtype == Artifact.ArtifactSubtype.Watermark)
                        count++;
                }
            }

            Console.WriteLine($"Page contains {count} watermarks");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}