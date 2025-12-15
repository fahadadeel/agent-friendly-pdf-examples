using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Stamps_Watermarks;

/// <summary>
/// Demonstrates adding a text stamp to a PDF document using Aspose.Pdf.
/// </summary>
public class AddTextStamp
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directory (application base)
            string baseDir = AppContext.BaseDirectory;

            // Input PDF path
            string inputPath = Path.Combine(baseDir, "data", "inputs", "AddTextStamp.pdf");

            // Ensure input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the PDF document
            Document pdfDocument = new Document(inputPath);

            // Create text stamp
            TextStamp textStamp = new TextStamp("Sample Stamp")
            {
                Background = true,
                XIndent = 100,
                YIndent = 100,
                Rotate = Rotation.on90
            };

            // Set text properties
            textStamp.TextState.Font = FontRepository.FindFont("Arial");
            textStamp.TextState.FontSize = 14.0F;
            textStamp.TextState.FontStyle = FontStyles.Bold;
            textStamp.TextState.FontStyle = FontStyles.Italic;
            textStamp.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Aqua);

            // Add stamp to the first page (pages are 1‑based)
            pdfDocument.Pages[1].AddStamp(textStamp);

            // Prepare output directory and path
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "AddTextStamp_out.pdf");

            // Save the modified document
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nText stamp added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding text stamp: {ex.Message}");
        }
    }
}