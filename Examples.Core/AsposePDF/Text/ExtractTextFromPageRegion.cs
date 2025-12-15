using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates extracting text from a specific region of a PDF page using Aspose.Pdf.
/// </summary>
public class ExtractTextFromPageRegion
{
    /// <summary>
    /// Runs the example.
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

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "ExtractTextAll.pdf");
            string outputPath = Path.Combine(outputDir, "extracted-text.txt");

            // Open document.
            Document pdfDocument = new Document(inputPath);

            // Create TextAbsorber object to extract text.
            TextAbsorber absorber = new TextAbsorber();
            absorber.TextSearchOptions.LimitToPageBounds = true;
            absorber.TextSearchOptions.Rectangle = new Rectangle(100, 200, 250, 350);

            // Accept the absorber for the first page.
            pdfDocument.Pages[1].Accept(absorber);

            // Get the extracted text.
            string extractedText = absorber.Text;

            // Write the extracted text to the output file.
            using TextWriter writer = new StreamWriter(outputPath);
            writer.WriteLine(extractedText);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during ExtractTextFromPageRegion execution: {ex.Message}");
        }
    }
}