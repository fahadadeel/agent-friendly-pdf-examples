using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.SplitPages;

/// <summary>
/// Demonstrates splitting a PDF into multiple files using streams with Aspose.Pdf.Facades.
/// </summary>
public class SplitPagesToBulkUsingStreams
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
            Directory.CreateDirectory(outputDir);

            // Path to the source PDF.
            string inputPath = Path.Combine(inputDir, "MultiplePages.pdf");

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Create input stream.
            using FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);

            // Define the groups of pages to split.
            int[][] numberOfPages = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };

            // Split to bulk; each element in the returned array contains the pages defined in the corresponding group.
            MemoryStream[] outBuffers = pdfEditor.SplitToBulks(inputStream, numberOfPages);

            // Save individual files.
            int fileNumber = 1;
            foreach (MemoryStream aStream in outBuffers)
            {
                string outPath = Path.Combine(outputDir, $"File_{fileNumber}_out.pdf");
                using FileStream outStream = new FileStream(outPath, FileMode.Create, FileAccess.Write);
                aStream.WriteTo(outStream);
                fileNumber++;
            }

            Console.WriteLine("PDF split completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while splitting the PDF: {ex.Message}");
        }
    }
}