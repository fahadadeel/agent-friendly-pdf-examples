using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Pages;

/// <summary>
/// Demonstrates how to split each page of a PDF document into separate PDF files.
/// </summary>
public class SplitToPages
{
    /// <summary>
    /// Executes the split operation.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "SplitToPages.pdf");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open the source document.
            Document pdfDocument = new Document(inputPath);

            int pageCount = 1;

            // Iterate through each page and save it as a separate PDF.
            foreach (Page pdfPage in pdfDocument.Pages)
            {
                Document newDocument = new Document();
                newDocument.Pages.Add(pdfPage);

                string outputPath = Path.Combine(outputDir, $"page_{pageCount}_out.pdf");
                newDocument.Save(outputPath);
                pageCount++;
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SplitToPages: {ex.Message}");
        }
    }
}