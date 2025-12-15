using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Pages;

/// <summary>
/// Demonstrates how to insert an empty page at the end of a PDF document using Aspose.Pdf.
/// </summary>
public class InsertEmptyPageAtEnd
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

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "InsertEmptyPageAtEnd.pdf");
            string outputPath = Path.Combine(outputDir, "InsertEmptyPageAtEnd_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Insert an empty page at the end of the PDF file.
            pdfDocument.Pages.Add();

            // Save the modified document.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nEmpty page inserted successfully at the end of document.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during InsertEmptyPageAtEnd execution: {ex.Message}");
        }
    }
}

// TODO: import or include any additional helper classes (e.g., RunExamples) from the original source if needed.