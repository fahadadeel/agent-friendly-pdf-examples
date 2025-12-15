using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

/// <summary>
/// Demonstrates concatenating all PDF files from an input directory into a single PDF file.
/// </summary>
public class ConcatenatingAllPdfFiles
{
    /// <summary>
    /// Concatenates all PDF files found in <c>data/inputs</c> and writes the result to <c>data/outputs</c>.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input directory (data/inputs relative to the application base directory)
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Input directory does not exist: {inputDir}");
                return;
            }

            // Retrieve names of all the PDF files in the input directory
            string[] fileEntries = Directory.GetFiles(inputDir, "*.pdf");

            // Resolve output directory (data/outputs) and ensure it exists
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Build the output file name using current date and time
            string date = DateTime.Now.ToString("MM-dd-yyyy");
            string hoursSeconds = DateTime.Now.ToString("hh-mm");
            string masterFileName = $"{date}_{hoursSeconds}_out.pdf";
            string outputPath = Path.Combine(outputDir, masterFileName);

            // Instantiate PdfFileEditor object
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Concatenate all PDF files into a single output file
            pdfEditor.Concatenate(fileEntries, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF concatenation: {ex.Message}");
        }
    }
}