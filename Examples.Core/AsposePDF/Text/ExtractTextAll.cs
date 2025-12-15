using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates extracting all text from a PDF document and writing it to a text file.
/// </summary>
public class ExtractTextAll
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // ExStart:ExtractTextAll
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "ExtractTextAll.pdf");
            string outputPath = Path.Combine(outputDir, "extracted-text.txt");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Create a TextAbsorber to extract text from all pages.
            TextAbsorber textAbsorber = new TextAbsorber();
            pdfDocument.Pages.Accept(textAbsorber);

            // Get the extracted text.
            string extractedText = textAbsorber.Text;

            // Write the extracted text to the output file.
            using (TextWriter writer = new StreamWriter(outputPath))
            {
                writer.WriteLine(extractedText);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while extracting text: {ex.Message}");
        }
        // ExEnd:ExtractTextAll
    }
}