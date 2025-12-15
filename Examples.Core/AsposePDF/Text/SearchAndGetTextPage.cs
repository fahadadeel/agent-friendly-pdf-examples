using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates searching for a text phrase in a PDF and retrieving details of each occurrence.
/// </summary>
public class SearchAndGetTextPage
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base, input, and output directories.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure directories exist.
            Directory.CreateDirectory(outputDir);
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDir}");
                return;
            }

            // Path to the source PDF.
            string inputPath = Path.Combine(inputDir, "SearchAndGetTextPage.pdf");

            // Open document.
            Document pdfDocument = new Document(inputPath);

            // Create TextAbsorber to find all instances of the phrase "Figure".
            TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber("Figure");
            // Accept the absorber for all pages.
            pdfDocument.Pages.Accept(textFragmentAbsorber);
            // Get extracted text fragments.
            TextFragmentCollection textFragmentCollection = textFragmentAbsorber.TextFragments;

            // Loop through fragments and output details.
            foreach (TextFragment textFragment in textFragmentCollection)
            {
                foreach (TextSegment textSegment in textFragment.Segments)
                {
                    Console.WriteLine($"Text : {textSegment.Text} ");
                    Console.WriteLine($"Position : {textSegment.Position} ");
                    Console.WriteLine($"XIndent : {textSegment.Position.XIndent} ");
                    Console.WriteLine($"YIndent : {textSegment.Position.YIndent} ");
                    Console.WriteLine($"Font - Name : {textSegment.TextState.Font.FontName}");
                    Console.WriteLine($"Font - IsAccessible : {textSegment.TextState.Font.IsAccessible} ");
                    Console.WriteLine($"Font - IsEmbedded : {textSegment.TextState.Font.IsEmbedded} ");
                    Console.WriteLine($"Font - IsSubset : {textSegment.TextState.Font.IsSubset} ");
                    Console.WriteLine($"Font Size : {textSegment.TextState.FontSize} ");
                    Console.WriteLine($"Foreground Color : {textSegment.TextState.ForegroundColor} ");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SearchAndGetTextPage.Run: {ex.Message}");
        }
    }
}