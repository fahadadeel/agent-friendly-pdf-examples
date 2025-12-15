using Aspose.Pdf;
using Aspose.Pdf.Text;
using System;
using System.IO;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates searching a PDF document using a regular expression.
/// </summary>
public class SearchRegularExpression
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

            // Ensure output directory exists.
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "SearchRegularExpressionAll.pdf");

            // Open document
            Document pdfDocument = new Document(inputPath);

            // Create TextFragmentAbsorber to find all phrases matching the regular expression.
            TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber("\\d{4}-\\d{4}");

            // Set text search option to specify regular expression usage.
            TextSearchOptions textSearchOptions = new TextSearchOptions(true);
            textFragmentAbsorber.TextSearchOptions = textSearchOptions;

            // Accept the absorber for all the pages.
            pdfDocument.Pages.Accept(textFragmentAbsorber);

            // Get the extracted text fragments.
            TextFragmentCollection textFragmentCollection = textFragmentAbsorber.TextFragments;

            // Loop through the fragments.
            foreach (TextFragment textFragment in textFragmentCollection)
            {
                Console.WriteLine("Text : {0} ", textFragment.Text);
                Console.WriteLine("Position : {0} ", textFragment.Position);
                Console.WriteLine("XIndent : {0} ", textFragment.Position.XIndent);
                Console.WriteLine("YIndent : {0} ", textFragment.Position.YIndent);
                Console.WriteLine("Font - Name : {0}", textFragment.TextState.Font.FontName);
                Console.WriteLine("Font - IsAccessible : {0} ", textFragment.TextState.Font.IsAccessible);
                Console.WriteLine("Font - IsEmbedded : {0} ", textFragment.TextState.Font.IsEmbedded);
                Console.WriteLine("Font - IsSubset : {0} ", textFragment.TextState.Font.IsSubset);
                Console.WriteLine("Font Size : {0} ", textFragment.TextState.FontSize);
                Console.WriteLine("Foreground Color : {0} ", textFragment.TextState.ForegroundColor);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing SearchRegularExpression: {ex.Message}");
        }
    }
}