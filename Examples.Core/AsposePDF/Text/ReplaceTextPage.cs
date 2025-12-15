using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates replacing text on a specific page of a PDF document using Aspose.Pdf.
/// </summary>
public class ReplaceTextPage
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

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "ReplaceTextPage.pdf");
            string outputPath = Path.Combine(outputDir, "ReplaceTextPage_out.pdf");

            // Open document
            Document pdfDocument = new Document(inputPath);

            // Create TextAbsorber object to find all instances of the input search phrase
            TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber("text");

            // Accept the absorber for a particular page (page numbers are 1‑based)
            pdfDocument.Pages[2].Accept(textFragmentAbsorber);

            // Get the extracted text fragments
            TextFragmentCollection textFragmentCollection = textFragmentAbsorber.TextFragments;

            // Loop through the fragments and replace text and styling
            foreach (TextFragment textFragment in textFragmentCollection)
            {
                textFragment.Text = "New Phrase";
                textFragment.TextState.Font = FontRepository.FindFont("Verdana");
                textFragment.TextState.FontSize = 22;
                textFragment.TextState.ForegroundColor = Color.FromRgb(0, 0, 255); // Blue
                textFragment.TextState.BackgroundColor = Color.FromRgb(0, 255, 0); // Green
            }

            // Save the modified document
            pdfDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ReplaceTextPage.Run: {ex.Message}");
        }
    }
}