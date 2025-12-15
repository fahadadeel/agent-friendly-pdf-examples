using Aspose.Pdf;
using Aspose.Pdf.Text;
using System;
using System.IO;

/// <summary>
/// Example demonstrating removal of all text from a PDF using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Text;

public class RemoveAllTextFromPDF
{
    /// <summary>
    /// Removes all text from the input PDF and saves the result.
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
            string inputPath = Path.Combine(inputDir, "RemoveAllText.pdf");
            string outputPath = Path.Combine(outputDir, "RemoveAllText_out.pdf");

            // Open document.
            Document pdfDocument = new Document(inputPath);

            // Initiate TextFragmentAbsorber.
            TextFragmentAbsorber absorber = new TextFragmentAbsorber();

            // Remove all absorbed text.
            absorber.RemoveAllText(pdfDocument);

            // Save the document.
            pdfDocument.Save(outputPath, SaveFormat.Pdf);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in RemoveAllTextFromPDF.Run: {ex.Message}");
        }
    }
}