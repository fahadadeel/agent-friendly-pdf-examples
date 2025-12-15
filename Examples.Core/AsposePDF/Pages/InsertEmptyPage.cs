using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Pages;

/// <summary>
/// Demonstrates inserting an empty page into a PDF using Aspose.Pdf.
/// </summary>
public class InsertEmptyPage
{
    /// <summary>
    /// Inserts an empty page at position 2 and saves the result.
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

            // Define file paths.
            string inputPath = Path.Combine(inputDir, "InsertEmptyPage.pdf");
            string outputPath = Path.Combine(outputDir, "InsertEmptyPage_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Insert an empty page at position 2.
            pdfDocument.Pages.Insert(2);

            // Save the modified document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nEmpty page inserted successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error inserting empty page: " + ex.Message);
        }
    }
}