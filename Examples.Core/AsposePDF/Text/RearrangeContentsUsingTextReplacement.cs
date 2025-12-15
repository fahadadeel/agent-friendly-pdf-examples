using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates rearranging PDF contents using text replacement.
/// </summary>
public class RearrangeContentsUsingTextReplacement
{
    public static void Run()
    {
        try
        {
            // Determine input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Path to the source PDF file.
            string inputPath = Path.Combine(inputDir, "ExtractTextPage.pdf");

            // Load source PDF file.
            Document doc = new Document(inputPath);

            // Create TextFragmentAbsorber object with regular expression.
            TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber("[TextFragmentAbsorber,companyname,Textbox,50]");
            doc.Pages.Accept(textFragmentAbsorber);

            // Replace each TextFragment.
            foreach (TextFragment textFragment in textFragmentAbsorber.TextFragments)
            {
                // Set font of text fragment being replaced.
                textFragment.TextState.Font = FontRepository.FindFont("Arial");
                // Set font size.
                textFragment.TextState.FontSize = 12;
                // Set text color.
                textFragment.TextState.ForegroundColor = Aspose.Pdf.Color.Navy;
                // Replace the text with larger string than placeholder.
                textFragment.Text = "This is a Larger String for the Testing of this issue";
            }

            // Path for the output PDF file.
            string outputPath = Path.Combine(outputDir, "RearrangeContentsUsingTextReplacement_out.pdf");

            // Save resultant PDF.
            doc.Save(outputPath);

            Console.WriteLine($"\nContents rearranged successfully using text replacement.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "\nThis example will only work if you apply a valid Aspose License. You can purchase full license or get 30 day temporary license from http://www.aspose.com/purchase/default.aspx.");
        }
    }
}