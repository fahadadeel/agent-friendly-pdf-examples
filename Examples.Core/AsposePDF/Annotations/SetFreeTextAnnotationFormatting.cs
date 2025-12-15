using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using System.Drawing; // TODO: verify System.Drawing usage is supported on target platform

namespace Examples.Core.AsposePDF.Annotations;

public class SetFreeTextAnnotationFormatting
{
    /// <summary>
    /// Demonstrates adding a FreeText annotation with specific formatting to a PDF document.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "SetFreeTextAnnotationFormatting.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "SetFreeTextAnnotationFormatting_out.pdf");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Open document
            Document pdfDocument = new Document(inputPath);

            // Instantiate DefaultAppearance object
            // Use fully qualified System.Drawing.Color to avoid ambiguity with Aspose.Pdf.Color
            DefaultAppearance defaultAppearance = new DefaultAppearance("Arial", 28, System.Drawing.Color.Red);
            // Create annotation
            FreeTextAnnotation freeText = new FreeTextAnnotation(
                pdfDocument.Pages[1],
                new Aspose.Pdf.Rectangle(200, 400, 400, 600),
                defaultAppearance);

            // Specify the contents of annotation
            freeText.Contents = "Free Text";

            // Add annotation to annotations collection of page
            pdfDocument.Pages[1].Annotations.Add(freeText);

            // Save the updated document
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nFree TextAnnotation with specific text formatting added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during SetFreeTextAnnotationFormatting.Run: {ex.Message}");
        }
    }
}