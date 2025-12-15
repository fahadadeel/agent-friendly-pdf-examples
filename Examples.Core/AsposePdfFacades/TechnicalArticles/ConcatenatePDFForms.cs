using System;
using System.IO;
using Aspose.Pdf.Facades;

/// <summary>
/// Demonstrates concatenating PDF forms while keeping field IDs unique using Aspose.Pdf.Facades.
/// </summary>
namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

public class ConcatenatePDFForms
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine base directory (directory of the executing assembly)
            string baseDir = AppContext.BaseDirectory;

            // Input directory
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            // Output directory
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Input file paths
            string inputFile1 = Path.Combine(inputDir, "inFile1.pdf");
            string inputFile2 = Path.Combine(inputDir, "inFile2.pdf");
            // Output file path
            string outFile = Path.Combine(outputDir, "ConcatenatePDFForms_out.pdf");

            // Instantiate PdfFileEditor
            PdfFileEditor fileEditor = new PdfFileEditor
            {
                KeepFieldsUnique = true,
                UniqueSuffix = "_%NUM%"
            };

            // Concatenate the PDF files
            fileEditor.Concatenate(inputFile1, inputFile2, outFile);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ConcatenatePDFForms: {ex.Message}");
        }
    }
}