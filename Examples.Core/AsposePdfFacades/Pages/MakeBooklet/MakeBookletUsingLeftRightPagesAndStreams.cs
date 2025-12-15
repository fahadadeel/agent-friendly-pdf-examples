using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeBooklet;

/// <summary>
/// Demonstrates how to create a booklet PDF using left and right page specifications with streams.
/// </summary>
public class MakeBookletUsingLeftRightPagesAndStreams
{
    /// <summary>
    /// Executes the booklet creation example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories relative to the application base path.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "MultiplePages.pdf");
            string outputPath = Path.Combine(outputDir, "MakeBookletUsingLeftRightPagesAndStreams_out.pdf");

            // Validate input file existence.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Create streams for input and output.
            using FileStream inputStream = File.OpenRead(inputPath);
            using FileStream outputStream = File.OpenWrite(outputPath);

            // Set left and right pages.
            int[] leftPages = new int[] { 1, 5 };
            int[] rightPages = new int[] { 2, 3 };

            // Make booklet.
            pdfEditor.MakeBooklet(inputStream, outputStream, leftPages, rightPages);

            Console.WriteLine($"Booklet created successfully at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while creating the booklet: {ex.Message}");
        }
    }
}