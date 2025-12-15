using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePdfFacades.Annotations;

/// <summary>
/// Demonstrates importing annotations from an XFDF file into a PDF using Aspose.Pdf.Facades.
/// </summary>
public class ImportAnnotations
{
    /// <summary>
    /// Executes the import annotations example.
    /// </summary>
    public static void Run()
    {
        // TODO: import or include helper class RunExamples from original source if needed
        try
        {
            // Resolve base directories
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input file paths
            string pdfPath = Path.Combine(inputDir, "ImportAnnotations.pdf");
            string xfdfPath = Path.Combine(inputDir, "annotations.xfdf");

            // Output file path
            string outputPdfPath = Path.Combine(outputDir, "ImportAnnotations_out.pdf");

            // Create PdfAnnotationEditor object
            using var annotationEditor = new PdfAnnotationEditor();

            // Open PDF document
            annotationEditor.BindPdf(pdfPath);

            // Import annotations from XFDF
            using var fileStream = File.OpenRead(xfdfPath);
            AnnotationType[] annotTypes = { AnnotationType.FreeText, AnnotationType.Line };
            annotationEditor.ImportAnnotationFromXfdf(fileStream, annotTypes);

            // Save output PDF
            annotationEditor.Save(outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during ImportAnnotations example: {ex.Message}");
        }
    }
}