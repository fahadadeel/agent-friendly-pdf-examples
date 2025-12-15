using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeNUp;

public class UsingArrayOfFilesAndPaths
{
    /// <summary>
    /// Demonstrates making N-up PDF from an array of input files.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Prepare array of input file paths.
            string[] filesArray = new string[2];
            filesArray[0] = Path.Combine(inputDir, "input.pdf");
            filesArray[1] = Path.Combine(inputDir, "input2.pdf");

            // Define output file path.
            string outputPath = Path.Combine(outputDir, "UsingArrayOfFilesAndPaths_out.pdf");

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Perform N-up operation.
            pdfEditor.MakeNUp(filesArray, outputPath, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in UsingArrayOfFilesAndPaths.Run: {ex.Message}");
        }
    }
}