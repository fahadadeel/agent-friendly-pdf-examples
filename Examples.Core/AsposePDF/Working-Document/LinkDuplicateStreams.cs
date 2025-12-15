using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Optimization;

namespace Examples.Core.AsposePDF.Working_Document;

/// <summary>
/// Demonstrates how to link duplicate streams while optimizing a PDF document using Aspose.Pdf.
/// </summary>
public class LinkDuplicateStreams
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

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "OptimizeDocument.pdf");
            string outputPath = Path.Combine(outputDir, "OptimizeDocument_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Set LinkDuplicateStreams option.
            var optimizeOptions = new OptimizationOptions
            {
                LinkDuplcateStreams = true
            };

            // Optimize PDF document using the specified options.
            pdfDocument.OptimizeResources(optimizeOptions);

            // Save the updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nLinked duplicate streams successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while processing the PDF: {ex.Message}");
        }
    }
}