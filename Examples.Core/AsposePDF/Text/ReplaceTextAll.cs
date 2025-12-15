using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates replacing all occurrences of a text string in a PDF document using Aspose.Pdf.
/// </summary>
public class ReplaceTextAll
{
    /// <summary>
    /// Executes the example.
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

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "ReplaceTextAll.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open document
            Document pdfDocument = new Document(inputPath);

            // Create TextAbsorber object to find all instances of the input search phrase
            TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber("text");

            // Accept the absorber for all the pages
            pdfDocument.Pages.Accept(textFragmentAbsorber);

            // Get the extracted text fragments
            TextFragmentCollection textFragmentCollection = textFragmentAbsorber.TextFragments;

            // Loop through the fragments and replace text and styling
            foreach (TextFragment textFragment in textFragmentCollection)
            {
                textFragment.Text = "TEXT";
                textFragment.TextState.Font = FontRepository.FindFont("Verdana");
                textFragment.TextState.FontSize = 22;
                textFragment.TextState.ForegroundColor = Color.FromRgb(0, 0, 255); // Blue
                textFragment.TextState.BackgroundColor = Color.FromRgb(0, 255, 0); // Green
            }

            // Output PDF file path.
            string outputPath = Path.Combine(outputDir, "ReplaceTextAll_out.pdf");

            // Save resulting PDF document.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nText replaced successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while executing ReplaceTextAll: {ex.Message}");
        }
    }
}