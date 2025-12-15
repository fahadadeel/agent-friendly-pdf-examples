using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates extracting text from the first page of a PDF document using Aspose.Pdf.
/// </summary>
public class ExtractTextPage
{
    /// <summary>
    /// Executes the text extraction example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "ExtractTextPage.pdf");
            string outputPath = Path.Combine(outputDir, "extracted-text_out.txt");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Create a TextAbsorber to extract text.
            TextAbsorber textAbsorber = new TextAbsorber();

            // Accept the absorber for the first page (pages are 1‑based).
            pdfDocument.Pages[1].Accept(textAbsorber);

            // Retrieve the extracted text.
            string extractedText = textAbsorber.Text;

            // Write the extracted text to the output file.
            using TextWriter tw = new StreamWriter(outputPath);
            tw.WriteLine(extractedText);

            Console.WriteLine("\nText extracted successfully from Pages of PDF Document.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during text extraction: {ex.Message}");
        }
    }
}