using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

/// <summary>
/// Demonstrates adding an attachment to a PDF using a stream with Aspose.Pdf.Facades.
/// </summary>
namespace Examples.Core.AsposePdfFacades.Attachments;

public class AddAttachmentStream
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
            Directory.CreateDirectory(outputDir);

            // Input PDF and attachment file names.
            string inputPdfPath = Path.Combine(inputDir, "AddAttachment-Stream.pdf");
            string attachmentPath = Path.Combine(inputDir, "test.txt");
            string outputPdfPath = Path.Combine(outputDir, "AddAttachment-Stream_out.pdf");

            // Open the PDF document for editing.
            PdfContentEditor contentEditor = new PdfContentEditor();
            contentEditor.BindPdf(inputPdfPath);

            // Open the attachment file as a stream.
            using FileStream fileStream = new FileStream(attachmentPath, FileMode.Open, FileAccess.Read);

            // Add the attachment to the PDF.
            contentEditor.AddDocumentAttachment(fileStream, "Attachment Name", "Attachment Description");

            // Save the updated PDF.
            contentEditor.Save(outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddAttachmentStream.Run: {ex.Message}");
        }
    }
}