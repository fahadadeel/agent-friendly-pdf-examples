using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Attachments;

public class DeleteAllAttachments
{
    /// <summary>
    /// Deletes all attachments from a PDF document and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "DeleteAllAttachments.pdf");
            string outputPath = Path.Combine(outputDir, "DeleteAllAttachments_out.pdf");

            // Open document.
            Document pdfDocument = new Document(inputPath);

            // Delete all attachments.
            pdfDocument.EmbeddedFiles.Delete();

            // Save updated file.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nAll attachments deleted successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error deleting attachments: {ex.Message}");
        }
    }
}