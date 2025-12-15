using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates how to replace text in a PDF document using a regular expression.
/// </summary>
public class ReplaceTextOnRegularExpression
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "SearchRegularExpressionPage.pdf");
            string outputPath = Path.Combine(outputDir, "ReplaceTextonRegularExpression_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Create a TextFragmentAbsorber to find all phrases matching the regular expression.
            TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber("\\d{4}-\\d{4}"); // e.g., 1999-2000

            // Enable regular expression usage in the search options.
            TextSearchOptions textSearchOptions = new TextSearchOptions(true);
            textFragmentAbsorber.TextSearchOptions = textSearchOptions;

            // Accept the absorber for the first page (pages are 1‑based).
            pdfDocument.Pages[1].Accept(textFragmentAbsorber);

            // Retrieve the extracted text fragments.
            TextFragmentCollection textFragmentCollection = textFragmentAbsorber.TextFragments;

            // Replace each matched fragment.
            foreach (TextFragment textFragment in textFragmentCollection)
            {
                textFragment.Text = "New Phrase";
                textFragment.TextState.Font = FontRepository.FindFont("Verdana");
                textFragment.TextState.FontSize = 22;

                // Use RGB values directly to avoid System.Drawing dependencies.
                textFragment.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(0, 0, 255); // Blue
                textFragment.TextState.BackgroundColor = Aspose.Pdf.Color.FromRgb(0, 128, 0); // Green
            }

            // Save the modified document.
            pdfDocument.Save(outputPath);
            Console.WriteLine("\nText replaced successfully based on a regular expression.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error during ReplaceTextOnRegularExpression: " + ex.Message);
        }
    }
}