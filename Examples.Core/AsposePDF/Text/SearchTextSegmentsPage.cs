using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates searching text segments on a specific page of a PDF document using Aspose.Pdf.
/// </summary>
public class SearchTextSegmentsPage
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

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "SearchTextSegmentsPage.pdf");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Create a TextFragmentAbsorber to find all instances of the search phrase "text".
            TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber("text");

            // Accept the absorber for page 2 (pages are 1‑based).
            pdfDocument.Pages[2].Accept(textFragmentAbsorber);

            // Retrieve the extracted text fragments.
            TextFragmentCollection textFragmentCollection = textFragmentAbsorber.TextFragments;

            // Iterate through the fragments and their segments, outputting details to the console.
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
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}