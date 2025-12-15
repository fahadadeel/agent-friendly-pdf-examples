using System;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Demonstrates setting PDF document information using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.WorkingDocument;

public class SetFileInfo
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "SetFileInfo.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "SetFileInfo_out.pdf");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Open document
            Document pdfDocument = new Document(inputPath);

            // Specify document information
            DocumentInfo docInfo = new DocumentInfo(pdfDocument)
            {
                Author = "Aspose",
                CreationDate = DateTime.Now,
                Keywords = "Aspose.Pdf, DOM, API",
                ModDate = DateTime.Now,
                Subject = "PDF Information",
                Title = "Setting PDF Document Information"
            };

            // Save output document
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nFile informations setup successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SetFileInfo example: {ex.Message}");
        }
    }
}