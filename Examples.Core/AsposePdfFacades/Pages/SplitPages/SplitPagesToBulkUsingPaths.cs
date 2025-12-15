using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.SplitPages;

/// <summary>
/// Demonstrates splitting a PDF into multiple files using Aspose.Pdf.Facades.PdfFileEditor.
/// </summary>
public class SplitPagesToBulkUsingPaths
{
    /// <summary>
    /// Executes the split operation.
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

            // Path to the source PDF.
            string inputPath = Path.Combine(inputDir, "MultiplePages.pdf");

            // Verify the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Define the page ranges to split.
            int[][] numberOfPages = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };

            // Split the PDF into bulks.
            MemoryStream[] outBuffer = pdfEditor.SplitToBulks(inputPath, numberOfPages);

            // Save each resulting PDF to the output directory.
            int fileNumber = 1;
            foreach (MemoryStream aStream in outBuffer)
            {
                string outputPath = Path.Combine(outputDir, $"File_{fileNumber}_out.pdf");
                using (FileStream outStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    aStream.WriteTo(outStream);
                }

                fileNumber++;
            }

            Console.WriteLine("PDF split operation completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during PDF split: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.