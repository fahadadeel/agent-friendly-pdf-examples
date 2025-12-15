using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Attachments;

/// <summary>
/// Demonstrates adding an attachment to a PDF using Aspose.Pdf.Facades.
/// </summary>
public class AddAttachment
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Input and output file paths
            string inputPdfPath = Path.Combine(inputDir, "AddAttachment.pdf");
            string attachmentPath = Path.Combine(inputDir, "test.txt");
            string outputPdfPath = Path.Combine(outputDir, "AddAttachment_out.pdf");

            // Open document
            var contentEditor = new PdfContentEditor();
            contentEditor.BindPdf(inputPdfPath);

            // Add attachment
            contentEditor.AddDocumentAttachment(attachmentPath, "Attachment Description");

            // Save updated PDF
            contentEditor.Save(outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddAttachment example: {ex.Message}");
        }
    }
}