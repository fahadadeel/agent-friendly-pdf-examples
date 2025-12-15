using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates replacing the first occurrence of a text fragment in a PDF document.
/// </summary>
public class ReplaceFirstOccurrence
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "ReplaceTextPage.pdf");
            string outputPath = Path.Combine(outputDir, "ReplaceFirstOccurrence_out.pdf");

            // Open document.
            Document pdfDocument = new Document(inputPath);

            // Create TextAbsorber object to find all instances of the input search phrase.
            TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber("text");
            // Accept the absorber for all the pages.
            pdfDocument.Pages.Accept(textFragmentAbsorber);
            // Get the extracted text fragments.
            TextFragmentCollection textFragmentCollection = textFragmentAbsorber.TextFragments;

            if (textFragmentCollection.Count > 0)
            {
                // Get first occurrence of text and replace.
                TextFragment textFragment = textFragmentCollection[1];
                // Update text and other properties.
                textFragment.Text = "New Phrase";
                textFragment.TextState.Font = FontRepository.FindFont("Verdana");
                textFragment.TextState.FontSize = 22;
                textFragment.TextState.ForegroundColor = Color.FromRgb(0, 0, 255); // Blue

                // Save the updated document.
                pdfDocument.Save(outputPath);

                Console.WriteLine("\nText replaced successfully.\nFile saved at " + outputPath);
            }
            else
            {
                Console.WriteLine("No matching text fragments were found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}