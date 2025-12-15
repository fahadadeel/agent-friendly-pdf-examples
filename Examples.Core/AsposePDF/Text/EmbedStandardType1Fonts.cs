using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates how to embed standard Type 1 fonts into an existing PDF document using Aspose.Pdf.
/// </summary>
public class EmbedStandardType1Fonts
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

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "EmbeddedFonts-updated_out.pdf");

            // Load the existing PDF document.
            Document pdfDocument = new Document(inputPath);

            // Enable embedding of standard fonts for the whole document.
            pdfDocument.EmbedStandardFonts = true;

            // Iterate through each page and embed fonts that are not already embedded.
            foreach (Page page in pdfDocument.Pages)
            {
                if (page.Resources?.Fonts != null)
                {
                    foreach (Font pageFont in page.Resources.Fonts)
                    {
                        if (!pageFont.IsEmbedded)
                        {
                            pageFont.IsEmbedded = true;
                        }
                    }
                }
            }

            // Save the updated PDF document.
            pdfDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while embedding fonts: {ex.Message}");
        }
    }
}