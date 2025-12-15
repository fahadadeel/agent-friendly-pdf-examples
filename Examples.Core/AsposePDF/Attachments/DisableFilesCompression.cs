using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Attachments;

/// <summary>
/// Demonstrates disabling file compression for attachments in a PDF document using Aspose.Pdf.
/// </summary>
public class DisableFilesCompression
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

        // Define input and output file paths.
        string inputPath = Path.Combine(inputDir, "GetAlltheAttachments.pdf");
        string outputPath = Path.Combine(outputDir, "DisableFilesCompression_out.pdf");

        try
        {
            // Load the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Setup new file to be added as attachment.
            FileSpecification fileSpecification = new FileSpecification("test_out.txt", "Sample text file");

            // Specify Encoding property setting it to FileEncoding.None.
            fileSpecification.Encoding = FileEncoding.None;

            // Add attachment to document's attachment collection.
            pdfDocument.EmbeddedFiles.Add(fileSpecification);

            // Save the modified document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nFile compression disabled successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while disabling file compression: {ex.Message}");
        }
    }
}