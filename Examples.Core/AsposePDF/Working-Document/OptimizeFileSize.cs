using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Optimization;

namespace Examples.Core.AsposePDF.WorkingDocument
{
    /// <summary>
    /// Demonstrates how to optimize a PDF file size using Aspose.Pdf.
    /// </summary>
    public class OptimizeFileSize
    {
        /// <summary>
        /// Executes the optimization example.
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
                string inputPath = Path.Combine(inputDir, "OptimizeDocument.pdf");
                string outputPath = Path.Combine(outputDir, "OptimizeFileSize_out.pdf");

                // Open the PDF document.
                Document pdfDocument = new Document(inputPath);

                // Configure optimization options.
                OptimizationOptions optimizationOptions = new OptimizationOptions
                {
                    LinkDuplcateStreams = true,
                    RemoveUnusedObjects = true,
                    RemoveUnusedStreams = true
                };

                // Set image compression options (property is read‑only, but its members are mutable).
                // TODO: Verify that ImageCompressionOptions is not null in the current Aspose.Pdf version.
                optimizationOptions.ImageCompressionOptions.CompressImages = true;
                optimizationOptions.ImageCompressionOptions.ImageQuality = 10;

                // Optimize the PDF resources.
                pdfDocument.OptimizeResources(optimizationOptions);

                // Save the optimized PDF.
                pdfDocument.Save(outputPath);

                Console.WriteLine("\nFile size optimized successfully.\nFile saved at " + outputPath);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error optimizing PDF: {ex.Message}");
            }
        }
    }
}