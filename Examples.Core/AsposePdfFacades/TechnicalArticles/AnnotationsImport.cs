using System;
using System.IO;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

/// <summary>
/// Demonstrates importing annotations from an XFDF file into a PDF using Aspose.Pdf.Facades.
/// </summary>
public class AnnotationsImport
{
    /// <summary>
    /// Executes the annotation import example.
    /// </summary>
    public static void Run()
    {
        // ExStart:AnnotationsImport
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Paths to the files.
            string inputPdfPath = Path.Combine(inputDir, "inFile.pdf");
            string xfdfPath = Path.Combine(inputDir, "exportannotations.xfdf");
            string outputPdfPath = Path.Combine(outputDir, "ImportAnnotations_out.pdf");

            // Create an object of PdfAnnotationEditor class.
            PdfAnnotationEditor editor = new PdfAnnotationEditor();

            // Bind input PDF file.
            editor.BindPdf(inputPdfPath);

            // Open the XFDF file as a stream.
            using FileStream fileStream = new FileStream(xfdfPath, FileMode.Open, FileAccess.Read);

            // Create an enumeration of all the annotation types which you want to import.
            AnnotationType[] annType = { AnnotationType.Text };

            // Import annotations of specified type(s) from XFDF file.
            editor.ImportAnnotationFromXfdf(fileStream, annType);

            // Save output PDF file.
            editor.Save(outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during AnnotationsImport example: {ex.Message}");
        }
        // ExEnd:AnnotationsImport
    }
}