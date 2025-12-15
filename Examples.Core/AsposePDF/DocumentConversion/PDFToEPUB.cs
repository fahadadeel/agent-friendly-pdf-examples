using System;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Demonstrates conversion of a PDF document to EPUB format using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.DocumentConversion;

public class PDFToEPUB
{
    /// <summary>
    /// Executes the PDF to EPUB conversion example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve directories relative to the application base path.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "PDFToEPUB.pdf");
            string outputPath = Path.Combine(outputDir, "PDFToEPUB_out.epub");

            // Load PDF document.
            Document pdfDocument = new Document(inputPath);

            // Instantiate EPUB save options.
            EpubSaveOptions options = new EpubSaveOptions
            {
                // Specify the layout for contents.
                ContentRecognitionMode = EpubSaveOptions.RecognitionMode.Flow
            };

            // Save the EPUB document.
            pdfDocument.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF to EPUB conversion: {ex.Message}");
        }
    }
}