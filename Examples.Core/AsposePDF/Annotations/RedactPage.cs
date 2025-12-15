using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.Annotations;

/// <summary>
/// Demonstrates redaction of a page region using Aspose.Pdf annotations and facades.
/// </summary>
public class RedactPage
{
    /// <summary>
    /// Redacts a specific region on the first page of the input PDF and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "RedactPage_out.pdf");

            // Open document
            Document doc = new Document(inputPath);

            // Create RedactionAnnotation instance for specific page region
            RedactionAnnotation annot = new RedactionAnnotation(
                doc.Pages[1],
                new Rectangle(200, 500, 300, 600));

            annot.FillColor = Color.Green;
            annot.BorderColor = Color.Yellow;
            annot.Color = Color.Blue;
            annot.OverlayText = "REDACTED";
            annot.TextAlignment = HorizontalAlignment.Center;
            annot.Repeat = true;

            // Add annotation to the first page and apply redaction
            doc.Pages[1].Annotations.Add(annot);
            annot.Redact();

            // Save the modified document
            doc.Save(outputPath);

            Console.WriteLine($"\nCertain page region with RedactionAnnotation redact successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in Run: {ex.Message}");
        }
    }

    /// <summary>
    /// Uses the PdfAnnotationEditor facade to redact a region and saves the result.
    /// </summary>
    public static void FacadesApproach()
    {
        try
        {
            // Resolve input and output directories relative to the application base.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "FacadesApproach_out.pdf");

            PdfAnnotationEditor editor = new PdfAnnotationEditor();

            // Redact certain page region
            // TODO: platform-specific API — review and implement with guard
            editor.RedactArea(
                1,
                new Rectangle(100, 100, 20, 70),
                System.Drawing.Color.White);

            editor.BindPdf(inputPath);
            editor.Save(outputPath);

            Console.WriteLine($"\nFacadesApproach completed. File saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in FacadesApproach: {ex.Message}");
        }
    }
}