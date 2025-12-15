using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Stamps_Watermarks;

/// <summary>
/// Demonstrates adding a page number stamp to a PDF document using Aspose.Pdf.
/// </summary>
public class PageNumberStamps
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

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "PageNumberStamp.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open document using path overload.
            Document pdfDocument = new Document(inputPath);

            // Create page number stamp.
            PageNumberStamp pageNumberStamp = new PageNumberStamp
            {
                Background = false,
                Format = "Page # of " + pdfDocument.Pages.Count,
                BottomMargin = 10,
                HorizontalAlignment = HorizontalAlignment.Center,
                StartingNumber = 1
            };

            // Set text properties.
            pageNumberStamp.TextState.Font = FontRepository.FindFont("Arial");
            pageNumberStamp.TextState.FontSize = 14.0F;
            pageNumberStamp.TextState.FontStyle = FontStyles.Bold;
            pageNumberStamp.TextState.FontStyle = FontStyles.Italic; // Overwrites previous style; retained from legacy.
            pageNumberStamp.TextState.ForegroundColor = Color.Aqua;

            // Add stamp to the first page (pages are 1‑based).
            pdfDocument.Pages[1].AddStamp(pageNumberStamp);

            // Output PDF file.
            string outputPath = Path.Combine(outputDir, "PageNumberStamp_out.pdf");
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nPage number stamp added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during PageNumberStamps example: {ex.Message}");
        }
    }
}