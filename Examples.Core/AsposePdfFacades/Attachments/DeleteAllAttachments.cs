using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Attachments;

/// <summary>
/// Demonstrates how to delete all attachments from a PDF using Aspose.Pdf.Facades.
/// </summary>
public class DeleteAllAttachments
{
    /// <summary>
    /// Executes the example.
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "DeleteAllAttachments.pdf");
            string outputPath = Path.Combine(outputDir, "DeleteAllAttachments_out.pdf");

            // Verify the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open the PDF document.
            PdfContentEditor contentEditor = new PdfContentEditor();
            contentEditor.BindPdf(inputPath);

            // Delete all attachments.
            contentEditor.DeleteAttachments();

            // Save the updated PDF.
            contentEditor.Save(outputPath);

            Console.WriteLine($"Attachments deleted. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}