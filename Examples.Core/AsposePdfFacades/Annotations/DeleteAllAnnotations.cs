using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Annotations;

public class DeleteAllAnnotations
{
    /// <summary>
    /// Deletes all annotations from the input PDF and saves the result.
    /// </summary>
    public static void Run()
    {
        // ExStart:DeleteAllAnnotations
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "DeleteAllAnnotations.pdf");
            string outputPath = Path.Combine(outputDir, "DeleteAllAnnotations_out.pdf");

            // Open document
            var annotationEditor = new PdfAnnotationEditor();
            annotationEditor.BindPdf(inputPath);

            // Delete all annotations
            annotationEditor.DeleteAnnotations();

            // Save updated PDF
            annotationEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in DeleteAllAnnotations.Run: {ex.Message}");
        }
        // ExEnd:DeleteAllAnnotations
    }
}