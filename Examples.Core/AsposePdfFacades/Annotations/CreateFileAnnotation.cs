using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Annotations;

/// <summary>
/// Demonstrates creating a file attachment annotation with transparency using Aspose.Pdf.Facades.
/// </summary>
public class CreateFileAnnotation
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // ExStart:CreateFileAnnotation
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input PDF files.
            string inputPdfPath = Path.Combine(inputDir, "CreateFileAnnotation.pdf");
            string attachmentPdfPath = Path.Combine(inputDir, "AddFreeTextAnnotation.pdf");

            // Output PDF file.
            string outputPdfPath = Path.Combine(outputDir, "PdfWith_Transparent_Annotation_out.pdf");

            // Instantiate PdfContentEditor object.
            PdfContentEditor editor = new PdfContentEditor();

            // Bind input PDF file.
            editor.BindPdf(inputPdfPath);

            // The last argument is for transparency of the icon.
            editor.CreateFileAttachment(
                new System.Drawing.Rectangle(50, 50, 10, 10),
                "here",
                attachmentPdfPath,
                1,
                "Paperclip",
                0.005);

            // Save the updated PDF file.
            editor.Save(outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during CreateFileAnnotation execution: {ex.Message}");
        }
        // ExEnd:CreateFileAnnotation
    }
}