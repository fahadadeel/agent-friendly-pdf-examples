using System;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Demonstrates adding an attachment to a PDF/A-3a document using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.DocumentConversion;

public class AddAttachmentToPDFA
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Define file paths.
            string inputPdfPath = Path.Combine(inputDir, "input.pdf");
            string attachmentPath = Path.Combine(inputDir, "aspose-logo.jpg");
            string logFilePath = Path.Combine(outputDir, "log.txt");
            string outputPdfPath = Path.Combine(outputDir, "AddAttachmentToPDFA_out.pdf");

            // Load the existing PDF document.
            Document doc = new Document(inputPdfPath);

            // Create a file specification for the attachment.
            using (FileSpecification fileSpec = new FileSpecification(attachmentPath, "Large Image file"))
            {
                // Add the attachment to the document's embedded files collection.
                doc.EmbeddedFiles.Add(fileSpec);

                // Convert the document to PDF/A-3a, ensuring the attachment is retained.
                doc.Convert(logFilePath, PdfFormat.PDF_A_3A, ConvertErrorAction.Delete);

                // Save the resulting PDF/A document.
                doc.Save(outputPdfPath);
            }

            Console.WriteLine($"\nAttachment added successfully to PDF/A file.\nFile saved at {outputPdfPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF/A conversion: {ex.Message}");
        }
    }
}