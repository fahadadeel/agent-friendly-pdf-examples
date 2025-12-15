using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates how to remove unused fonts from a PDF document using Aspose.Pdf.
/// </summary>
public class RemoveUnusedFonts
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Path to the source PDF file.
            string inputPath = Path.Combine(inputDir, "ReplaceTextPage.pdf");

            // Load source PDF file.
            Document doc = new Document(inputPath);

            // Create an absorber that removes unused fonts.
            TextFragmentAbsorber absorber = new TextFragmentAbsorber(
                new TextEditOptions(TextEditOptions.FontReplace.RemoveUnusedFonts));

            // Accept the absorber for all pages.
            doc.Pages.Accept(absorber);

            // Iterate through all the TextFragments and set a specific font.
            foreach (TextFragment textFragment in absorber.TextFragments)
            {
                textFragment.TextState.Font = FontRepository.FindFont("Arial, Bold");
            }

            // Path for the output PDF file.
            string outputPath = Path.Combine(outputDir, "RemoveUnusedFonts_out.pdf");

            // Save the updated document.
            doc.Save(outputPath);

            Console.WriteLine($"\nUnused fonts removed successfully from PDF document.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "\nThis example will only work if you apply a valid Aspose License. You can purchase a full license or get a 30‑day temporary license from http://www.aspose.com/purchase/default.aspx.");
        }
    }
}