using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeBooklet;

public class MakeBookletUsingPaths
{
    /// <summary>
    /// Demonstrates making a booklet from a PDF using file paths.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "MakeBookletUsingPaths_out.pdf");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create PdfFileEditor object.
            var pdfEditor = new PdfFileEditor();

            // Make booklet.
            pdfEditor.MakeBooklet(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during MakeBookletUsingPaths: {ex.Message}");
        }
    }
}