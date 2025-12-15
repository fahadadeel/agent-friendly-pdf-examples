using System;
using System.IO;
using Aspose.Pdf;
// AUTOFIX: The Aspose.Pdf.Fonts namespace may not be available in the referenced version.
// using Aspose.Pdf.Fonts;

namespace Examples.Core.AsposePDF.Working_Document;

/// <summary>
/// Demonstrates embedding fonts using subset strategies with Aspose.Pdf.
/// </summary>
public class EmbedFontsUsingSubsetStrategy
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        try
        {
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to create output directory: {ex.Message}");
            return;
        }

        string inputPath = Path.Combine(inputDir, "input.pdf");
        string outputPath = Path.Combine(outputDir, "Output_out.pdf");

        try
        {
            // Load the PDF document.
            Document doc = new Document(inputPath);

            // TODO: If FontSubsetStrategy is available, uncomment the following lines.
            // All fonts will be embedded as subset into document in case of SubsetAllFonts.
            // doc.FontUtilities.SubsetFonts(Aspose.Pdf.Fonts.FontSubsetStrategy.SubsetAllFonts);

            // Font subset will be embedded for fully embedded fonts but fonts which are not embedded into document will not be affected.
            // doc.FontUtilities.SubsetFonts(Aspose.Pdf.Fonts.FontSubsetStrategy.SubsetEmbeddedFontsOnly);

            // Save the modified document.
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while processing the PDF: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.