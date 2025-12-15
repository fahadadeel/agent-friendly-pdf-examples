using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Attachments;

/// <summary>
/// Demonstrates how to add an attachment to a PDF document using Aspose.Pdf.
/// </summary>
public class AddAttachment
{
    /// <summary>
    /// Executes the attachment addition example.
    /// </summary>
    public static void Run()
    {
        // ExStart:AddAttachment
        try
        {
            // Resolve base, input, and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Define input file paths.
            string inputPdfPath = Path.Combine(inputDir, "AddAttachment.pdf");
            string attachmentPath = Path.Combine(inputDir, "test.txt");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPdfPath);

            // Set up the file to be added as an attachment.
            FileSpecification fileSpecification = new FileSpecification(attachmentPath, "Sample text file");

            // Add the attachment to the document's attachment collection.
            pdfDocument.EmbeddedFiles.Add(fileSpecification);

            // Define the output file path.
            string outputPdfPath = Path.Combine(outputDir, "AddAttachment_out.pdf");

            // Save the modified PDF document.
            pdfDocument.Save(outputPdfPath);
            // ExEnd:AddAttachment

            Console.WriteLine("\nSample text file attached successfully.\nFile saved at " + outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddAttachment.Run: {ex.Message}");
        }
    }
}