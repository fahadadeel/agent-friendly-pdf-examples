using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.MakeNUp;

public class UsingPageSizeHorizontalAndVerticalValues
{
    /// <summary>
    /// Demonstrates making N-up pages using specific horizontal and vertical values.
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

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "UsingPageSizeHorizontalAndVerticalValues_out.pdf");

            // Create PdfFileEditor object.
            var pdfEditor = new PdfFileEditor();

            // Make N-up: 2 columns, 3 rows.
            pdfEditor.MakeNUp(inputPath, outputPath, 2, 3);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in UsingPageSizeHorizontalAndVerticalValues.Run: {ex.Message}");
        }
    }
}