using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates how to replace fonts in a PDF document using Aspose.Pdf.
/// </summary>
public class ReplaceFonts
{
    /// <summary>
    /// Executes the font replacement example.
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

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "ReplaceTextPage.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load source PDF file.
            Document pdfDocument = new Document(inputPath);

            // Search text fragments and set edit option to remove unused fonts.
            TextFragmentAbsorber absorber = new TextFragmentAbsorber(
                new TextEditOptions(TextEditOptions.FontReplace.RemoveUnusedFonts));

            // Accept the absorber for all the pages.
            pdfDocument.Pages.Accept(absorber);

            // Traverse through all the TextFragments.
            foreach (TextFragment textFragment in absorber.TextFragments)
            {
                // If the font name is "Arial,Bold", replace it with "Arial".
                if (textFragment.TextState.Font.FontName == "Arial,Bold")
                {
                    textFragment.TextState.Font = FontRepository.FindFont("Arial");
                }
            }

            // Output PDF file.
            string outputPath = Path.Combine(outputDir, "ReplaceFonts_out.pdf");

            // Save the updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nFonts replaced successfully in PDF document.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}\nThis example will only work if you apply a valid Aspose License. You can purchase a full license or get a 30‑day temporary license from http://www.aspose.com/purchase/default.aspx.");
        }
    }
}