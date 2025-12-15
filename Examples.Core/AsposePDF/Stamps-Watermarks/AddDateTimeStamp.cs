using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Stamps_Watermarks;

/// <summary>
/// Demonstrates how to add a date‑time stamp to a PDF document using Aspose.Pdf.
/// </summary>
public class AddDateTimeStamp
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base path.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "AddTextStamp.pdf");
            string outputPath = Path.Combine(outputDir, "AddDateTimeStamp_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Prepare the date‑time text.
            string annotationText = DateTime.Now.ToString("MM/dd/yy hh:mm:ss tt ");

            // Create a text stamp with the date‑time.
            TextStamp textStamp = new TextStamp(annotationText)
            {
                BottomMargin = 10,
                RightMargin = 20,
                HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom
            };

            // Add the stamp to the first page.
            pdfDocument.Pages[1].AddStamp(textStamp);

            // Create a free‑text annotation that mirrors the stamp.
            // Note: System.Drawing.Color is used here as in the original example.
            // TODO: Verify that System.Drawing is appropriate for the target platform.
            DefaultAppearance defaultAppearance = new DefaultAppearance("Arial", 6, System.Drawing.Color.Black);

            FreeTextAnnotation textAnnotation = new FreeTextAnnotation(
                pdfDocument.Pages[1],
                new Aspose.Pdf.Rectangle(0, 0, 0, 0),
                defaultAppearance)
            {
                Name = "Stamp",
                Contents = textStamp.Value,
                Rect = new Aspose.Pdf.Rectangle(0, 0, 0, 0)
            };

            // The original code uses AnnotationSelector; ensure the type is available.
            // TODO: import or include helper class AnnotationSelector from original source if missing.
            textAnnotation.Accept(new AnnotationSelector(textAnnotation));

            // Configure the annotation border.
            Border border = new Border(textAnnotation)
            {
                Width = 0,
                Dash = new Dash(1, 1)
            };
            textAnnotation.Border = border;

            // Add the annotation to the page.
            pdfDocument.Pages[1].Annotations.Add(textAnnotation);

            // Save the modified document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nDate time stamp added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error adding date time stamp: " + ex.Message);
        }
    }
}