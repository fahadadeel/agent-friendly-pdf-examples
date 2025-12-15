using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Working_Document;

public class FlattenAnnotation
{
    /// <summary>
    /// Flattens all annotations in a PDF document.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Base directory of the application
            string baseDir = AppContext.BaseDirectory;

            // Resolve input and output directories
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Input and output file paths
            string inputPath = Path.Combine(inputDir, "OptimizeDocument.pdf");
            string outputPath = Path.Combine(outputDir, "OptimizeDocument_out.pdf");

            // Open the PDF document
            Document pdfDocument = new Document(inputPath);

            // Flatten all annotations on each page
            foreach (var page in pdfDocument.Pages)
            {
                foreach (var annotation in page.Annotations)
                {
                    annotation.Flatten();
                }
            }

            // Save the updated document
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nFlattened annotation successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error flattening annotations: {ex.Message}");
        }
    }
}