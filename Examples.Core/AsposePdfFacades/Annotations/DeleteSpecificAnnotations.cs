using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Annotations;

/// <summary>
/// Demonstrates deleting specific annotations from a PDF using Aspose.Pdf.Facades.
/// </summary>
public class DeleteSpecificAnnotations
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "DeleteAllAnnotations.pdf");
            string outputPath = Path.Combine(outputDir, "DeleteSpecificAnnotations_out.pdf");

            // Open document.
            var annotationEditor = new PdfAnnotationEditor();
            annotationEditor.BindPdf(inputPath);

            // Delete specific annotations of type "Text".
            annotationEditor.DeleteAnnotations("Text");

            // Save updated PDF.
            annotationEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in DeleteSpecificAnnotations: {ex.Message}");
        }
    }
}