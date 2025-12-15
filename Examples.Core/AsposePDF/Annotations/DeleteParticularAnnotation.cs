using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Annotations;

/// <summary>
/// Demonstrates how to delete a particular annotation from a PDF document using Aspose.Pdf.
/// </summary>
public class DeleteParticularAnnotation
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
            Directory.CreateDirectory(outputDir);

            // Define full paths for the input and output PDF files.
            string inputPath = Path.Combine(inputDir, "DeleteParticularAnnotation.pdf");
            string outputPath = Path.Combine(outputDir, "DeleteParticularAnnotation_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Delete the particular annotation (index 1) on the first page.
            pdfDocument.Pages[1].Annotations.Delete(1);

            // Save the updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nParticular annotation deleted successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error deleting annotation: {ex.Message}");
        }
    }
}