using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePdfFacades.Annotations;

/// <summary>
/// Demonstrates exporting annotations from a PDF to XFDF and saving the modified PDF using Aspose.Pdf.Facades.
/// </summary>
public class ExportAnnotations
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
        Directory.CreateDirectory(outputDir);

        // Define file names.
        string inputPdfPath = Path.Combine(inputDir, "ExportAnnotations.pdf");
        string xfdfOutputPath = Path.Combine(outputDir, "exportannotations.xfdf");
        string pdfOutputPath = Path.Combine(outputDir, "ExportAnnotations_out.pdf");

        try
        {
            // Create PdfAnnotationEditor object.
            var annotationEditor = new PdfAnnotationEditor();

            // Open PDF document.
            annotationEditor.BindPdf(inputPdfPath);

            // Export annotations to XFDF.
            using (var fileStream = new FileStream(xfdfOutputPath, FileMode.Create, FileAccess.Write))
            {
                string[] annotType = { AnnotationType.FreeText.ToString(), AnnotationType.Line.ToString() };
                // Parameters: stream, startPage, endPage, annotation types.
                annotationEditor.ExportAnnotationsXfdf(fileStream, 1, 5, annotType);
                // Stream will be flushed and closed by the using statement.
            }

            // Save the output PDF.
            annotationEditor.Save(pdfOutputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during ExportAnnotations example: {ex.Message}");
        }
    }
}