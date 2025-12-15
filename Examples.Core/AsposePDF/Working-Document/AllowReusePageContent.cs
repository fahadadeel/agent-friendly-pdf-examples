using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Pdf;
using Aspose.Pdf.Optimization;

namespace Examples.Core.AsposePDF.Working_Document;

/// <summary>
/// Demonstrates how to enable the AllowReusePageContent option while optimizing a PDF document.
/// </summary>
public class AllowReusePageContent
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

            // Ensure directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Define full paths for the source and destination PDF files.
            string inputPath = Path.Combine(inputDir, "OptimizeDocument.pdf");
            string outputPath = Path.Combine(outputDir, "OptimizeDocument_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Configure optimization options to allow reuse of page content.
            var optimizeOptions = new OptimizationOptions
            {
                AllowReusePageContent = true
            };

            Console.WriteLine("Start");

            // Optimize the PDF document using the specified options.
            pdfDocument.OptimizeResources(optimizeOptions);

            // Save the optimized document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("Finished");

            // Report file size reduction.
            var fiOriginal = new FileInfo(inputPath);
            var fiOptimized = new FileInfo(outputPath);
            Console.WriteLine($"Original file size: {fiOriginal.Length}. Reduced file size: {fiOptimized.Length}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF optimization: {ex.Message}");
        }

        Console.WriteLine("\nAllowed reuse page content successfully.\nFile saved at data/outputs");
    }
}