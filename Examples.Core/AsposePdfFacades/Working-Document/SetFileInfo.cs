using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.WorkingDocument;

/// <summary>
/// Demonstrates setting PDF file information using Aspose.Pdf.Facades.
/// </summary>
public class SetFileInfo
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

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "SetFileInfo.pdf");
            string outputPath = Path.Combine(outputDir, "SetFileInfo_out.pdf");

            // Open document info.
            PdfFileInfo fileInfo = new PdfFileInfo(inputPath);

            // Set PDF information.
            fileInfo.Author = "Aspose";
            fileInfo.Title = "Hello World!";
            fileInfo.Keywords = "Peace and Development";
            fileInfo.Creator = "Aspose";

            // Save updated file.
            fileInfo.SaveNewInfo(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SetFileInfo example: {ex.Message}");
        }
    }
}