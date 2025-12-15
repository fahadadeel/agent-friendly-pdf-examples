using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates extracting columnar text from a PDF document using Aspose.Pdf.
/// </summary>
public class ExtractColumnsText
{
    /// <summary>
    /// Extracts text from the PDF, reduces font size, and saves the result to an output file.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");
        Directory.CreateDirectory(outputDir);

        string inputPath = Path.Combine(inputDir, "ExtractTextPage.pdf");
        string outputPath = Path.Combine(outputDir, "ExtractColumnsText_out.txt");

        try
        {
            // Open document
            Document pdfDocument = new Document(inputPath);

            // Reduce font size of all text fragments to 70% of original.
            TextFragmentAbsorber tfa = new TextFragmentAbsorber();
            pdfDocument.Pages.Accept(tfa);
            TextFragmentCollection tfc = tfa.TextFragments;
            foreach (TextFragment tf in tfc)
            {
                tf.TextState.FontSize = tf.TextState.FontSize * 0.7f;
            }

            // Save to a memory stream and reload to apply changes.
            using var memoryStream = new MemoryStream();
            pdfDocument.Save(memoryStream);
            memoryStream.Position = 0;
            pdfDocument = new Document(memoryStream);

            // Extract text from the document.
            TextAbsorber textAbsorber = new TextAbsorber();
            pdfDocument.Pages.Accept(textAbsorber);
            string extractedText = textAbsorber.Text;
            textAbsorber.Visit(pdfDocument); // Retain original call for side‑effects.

            // Write extracted text to output file.
            File.WriteAllText(outputPath, extractedText);

            Console.WriteLine($"\nColumns text extracted successfully from pages of PDF document.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during Run: {ex.Message}");
        }
    }

    /// <summary>
    /// Extracts text using a scale factor to improve column separation.
    /// </summary>
    public static void UsingScaleFactor()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");
        Directory.CreateDirectory(outputDir);

        string inputPath = Path.Combine(inputDir, "ExtractTextPage.pdf");
        string outputPath = Path.Combine(outputDir, "ExtractTextUsingScaleFactor_out.text");

        try
        {
            // Open document
            Document pdfDocument = new Document(inputPath);

            // Configure text absorber with scale factor.
            TextAbsorber textAbsorber = new TextAbsorber
            {
                ExtractionOptions = new TextExtractionOptions(TextExtractionOptions.TextFormattingMode.Pure)
                {
                    ScaleFactor = 0.5 // 0.5 works for most documents; 0 lets the algorithm choose automatically.
                }
            };

            pdfDocument.Pages.Accept(textAbsorber);
            string extractedText = textAbsorber.Text;

            // Write extracted text to output file.
            File.WriteAllText(outputPath, extractedText);

            Console.WriteLine($"\nText extracted using scale factor.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during UsingScaleFactor: {ex.Message}");
        }
    }
}