using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.ManipulatePageProperties;

public class ResizePageContents
{
    /// <summary>
    /// Demonstrates resizing page contents using Aspose.Pdf.Facades.PdfFileEditor.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "ResizePageContents_out.pdf");

            // Create PdfFileEditor object.
            var fileEditor = new PdfFileEditor();

            // Open PDF document.
            var doc = new Document(inputPath);

            // Specify parameters for resizing.
            var parameters = new PdfFileEditor.ContentsResizeParameters(
                // Left margin = 10% of page width
                PdfFileEditor.ContentsResizeValue.Percents(10),
                // New contents width calculated automatically (null)
                null,
                // Right margin = 10% of page width
                PdfFileEditor.ContentsResizeValue.Percents(10),
                // Top margin = 10% of page height
                PdfFileEditor.ContentsResizeValue.Percents(10),
                // New contents height calculated automatically (null)
                null,
                // Bottom margin = 10% of page height
                PdfFileEditor.ContentsResizeValue.Percents(10)
            );

            // Resize contents of pages 1 and 2.
            fileEditor.ResizeContents(doc, new int[] { 1, 2 }, parameters);

            // Save the modified document.
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ResizePageContents: {ex.Message}");
        }
    }
}