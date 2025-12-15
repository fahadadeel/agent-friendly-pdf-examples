using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using System.Drawing.Printing; // AUTOFIX

namespace Examples.Core.AsposePdfFacades.Printing;

/// <summary>
/// Demonstrates converting a PDF document to PostScript using Aspose.Pdf.Facades.
/// </summary>
public class PdfToPostScript
{
    /// <summary>
    /// Executes the PDF‑to‑PostScript conversion.
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
            string outputPath = Path.Combine(outputDir, "PdfToPostScript_out.ps");

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Initialize the PDF viewer and bind the document.
            PdfViewer viewer = new PdfViewer();
            viewer.BindPdf(inputPath);

            // Configure printer settings for PostScript output.
            PrinterSettings printerSettings = new PrinterSettings
            {
                Copies = 1,
                // The printer name corresponds to a PS driver; adjust as needed for the target environment.
                PrinterName = "HP LaserJet 2300 Series PS",
                PrintFileName = outputPath,
                PrintToFile = true
            };

            // Disable the print page dialog.
            viewer.PrintPageDialog = false;

            // Print the document using the specified settings.
            viewer.PrintDocumentWithSettings(printerSettings);

            // Clean up.
            viewer.Close();

            Console.WriteLine($"PostScript file created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}