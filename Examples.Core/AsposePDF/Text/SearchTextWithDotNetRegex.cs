using Aspose.Pdf;
using Aspose.Pdf.Text;
using System;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// Demonstrates searching text in a PDF using .NET regular expressions.
/// </summary>
namespace Examples.Core.AsposePDF.Text;

public class SearchTextWithDotNetRegex
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

            // Ensure directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "SearchTextRegex.pdf");

            // Verify the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create Regex object to find all words.
            Regex regex = new Regex(@"[\S]+");

            // Open document using path overload.
            Document document = new Document(inputPath);

            // Get a particular page (pages are 1‑based).
            Page page = document.Pages[1];

            // Create TextFragmentAbsorber to find all instances of the input regex.
            TextFragmentAbsorber absorber = new TextFragmentAbsorber(regex);
            absorber.TextSearchOptions.IsRegularExpressionUsed = true;

            // Accept the absorber for the page.
            page.Accept(absorber);

            // Get the extracted text fragments.
            TextFragmentCollection fragments = absorber.TextFragments;

            // Loop through the fragments and write to console.
            foreach (TextFragment fragment in fragments)
            {
                Console.WriteLine(fragment.Text);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}