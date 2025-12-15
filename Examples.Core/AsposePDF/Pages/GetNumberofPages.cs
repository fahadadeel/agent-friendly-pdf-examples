using System;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Demonstrates how to obtain the number of pages in a PDF document using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Pages;

public class GetNumberOfPages
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve the input directory relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDir}");
                return;
            }

            // Build the full path to the PDF file.
            string pdfPath = Path.Combine(inputDir, "GetNumberOfPages.pdf");
            if (!File.Exists(pdfPath))
            {
                Console.Error.WriteLine($"Input file not found: {pdfPath}");
                return;
            }

            // Open the PDF document.
            Document pdfDocument = new Document(pdfPath);

            // Output the page count.
            Console.WriteLine("Page Count : {0}", pdfDocument.Pages.Count);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while counting PDF pages: {ex.Message}");
        }
    }
}