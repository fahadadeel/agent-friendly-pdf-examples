using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Links_Actions;

/// <summary>
/// Demonstrates how to update the text color of link annotations in a PDF document.
/// </summary>
public class UpdateLinkTextColor
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

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "UpdateLinks.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Iterate over annotations on the first page.
            foreach (Annotation annotation in doc.Pages[1].Annotations)
            {
                if (annotation is LinkAnnotation)
                {
                    // Expand the search rectangle slightly around the annotation.
                    Rectangle rect = annotation.Rect;
                    rect.LLX -= 10;
                    rect.LLY -= 10;
                    rect.URX += 10;
                    rect.URY += 10;

                    // Search for text within the expanded rectangle.
                    TextFragmentAbsorber absorber = new TextFragmentAbsorber
                    {
                        TextSearchOptions = new TextSearchOptions(rect)
                    };
                    absorber.Visit(doc.Pages[1]);

                    // Change the color of each found text fragment to red.
                    foreach (TextFragment tf in absorber.TextFragments)
                    {
                        tf.TextState.ForegroundColor = Color.Red;
                    }
                }
            }

            // Output PDF file.
            string outputPath = Path.Combine(outputDir, "UpdateLinkTextColor_out.pdf");
            doc.Save(outputPath);

            Console.WriteLine($"\nLinkAnnotation text color updated successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}