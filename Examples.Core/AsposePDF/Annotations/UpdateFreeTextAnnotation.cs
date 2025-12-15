using System;
using System.IO;
using System.Drawing; // AUTOFIX
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Annotations;

/// <summary>
/// Demonstrates updating a FreeText annotation's font size and color.
/// </summary>
public class UpdateFreeTextAnnotation
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "output.pdf");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Open the PDF document.
            Document doc = new Document(inputPath);

            // Update the first FreeText annotation on the first page, if present.
            if (doc.Pages.Count > 0 && doc.Pages[1].Annotations.Count > 0)
            {
                if (doc.Pages[1].Annotations[0] is FreeTextAnnotation freeText)
                {
                    freeText.TextStyle.FontSize = 18;
                    freeText.TextStyle.Color = System.Drawing.Color.Green;
                }
            }

            // Save the modified document.
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}