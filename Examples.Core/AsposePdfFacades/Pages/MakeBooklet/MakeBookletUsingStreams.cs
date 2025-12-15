using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeBooklet;

/// <summary>
/// Demonstrates how to create a booklet PDF using streams with Aspose.Pdf.Facades.
/// </summary>
public class MakeBookletUsingStreams
{
    /// <summary>
    /// Executes the booklet creation example.
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

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "MakeBookletUsingStreams_out.pdf");

            // Validate input file existence.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Open streams and make booklet.
            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                pdfEditor.MakeBooklet(inputStream, outputStream);
            }

            Console.WriteLine($"Booklet created successfully at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while creating the booklet: {ex.Message}");
        }
    }
}