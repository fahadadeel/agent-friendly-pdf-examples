using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using System;
using System.IO;

namespace Examples.Core.AsposePDF.Annotations;

/// <summary>
/// Demonstrates how to add a text annotation to a PDF document using Aspose.Pdf.
/// </summary>
public class AddAnnotation
{
    /// <summary>
    /// Executes the annotation addition example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "AddAnnotation.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "AddAnnotation_out.pdf");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Create a text annotation on the first page.
            TextAnnotation textAnnotation = new TextAnnotation(
                pdfDocument.Pages[1],
                new Rectangle(200, 400, 400, 600));

            textAnnotation.Title = "Sample Annotation Title";
            textAnnotation.Subject = "Sample Subject";
            textAnnotation.Contents = "Sample contents for the annotation";
            textAnnotation.Open = true;
            textAnnotation.Icon = TextIcon.Key;

            // Configure the annotation border.
            Border border = new Border(textAnnotation)
            {
                Width = 5,
                Dash = new Dash(1, 1)
            };
            textAnnotation.Border = border;
            textAnnotation.Rect = new Rectangle(200, 400, 400, 600);

            // Add the annotation to the page's annotations collection.
            pdfDocument.Pages[1].Annotations.Add(textAnnotation);

            // Save the modified document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nAnnotation added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("An error occurred while adding the annotation: " + ex.Message);
        }
    }
}