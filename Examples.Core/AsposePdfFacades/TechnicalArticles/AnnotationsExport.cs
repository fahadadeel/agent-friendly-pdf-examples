using System;
using System.IO;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

/// <summary>
/// Demonstrates exporting PDF annotations to an XFDF file using Aspose.Pdf.Facades.
/// </summary>
public class AnnotationsExport
{
    /// <summary>
    /// Executes the annotation export example.
    /// </summary>
    public static void Run()
    {
        // ExStart:AnnotationsExport
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Paths to the input PDF and the output XFDF file.
            string inputPdfPath = Path.Combine(inputDir, "inFile.pdf");
            string outputXfdfPath = Path.Combine(outputDir, "exportannotations.xfdf");

            // Create an object of PdfAnnotationEditor class.
            PdfAnnotationEditor editor = new PdfAnnotationEditor();

            // Bind input PDF file.
            editor.BindPdf(inputPdfPath);

            // Create a file stream for the output XFDF file.
            using FileStream fileStream = new FileStream(outputXfdfPath, FileMode.Create, FileAccess.Write);

            // Create an enumeration of all the annotation types which you want to export.
            string[] annoType = { AnnotationType.Text.ToString() };

            // Export annotations of specified type(s) to XFDF file.
            // Parameters: output stream, start page (1), end page (5), annotation types.
            editor.ExportAnnotationsXfdf(fileStream, 1, 5, annoType);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during annotation export: {ex.Message}");
        }
        // ExEnd:AnnotationsExport
    }
}