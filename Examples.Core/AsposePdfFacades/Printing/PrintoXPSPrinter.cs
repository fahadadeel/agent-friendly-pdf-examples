using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using System.Drawing.Printing;

namespace Examples.Core.AsposePdfFacades.Printing;

public class PrintoXPSPrinter
{
    private static readonly string BaseDir = AppContext.BaseDirectory;
    private static readonly string InputDir = Path.Combine(BaseDir, "data", "inputs");
    private static readonly string OutputDir = Path.Combine(BaseDir, "data", "outputs");

    static PrintoXPSPrinter()
    {
        // Ensure directories exist
        Directory.CreateDirectory(InputDir);
        Directory.CreateDirectory(OutputDir);
    }

    /// <summary>
    /// Demonstrates printing a PDF to an XPS printer with custom settings.
    /// </summary>
    public static void Run()
    {
        // ExStart:PrintoXPSPrinter
        try
        {
            // Resolve input PDF path
            string inputPath = Path.Combine(InputDir, "input.pdf");

            // Create PdfViewer object
            using var viewer = new PdfViewer();

            // Open input PDF file
            viewer.BindPdf(inputPath);

            // Set attributes for printing
            viewer.AutoResize = true;         // Print the file with adjusted size
            viewer.AutoRotate = true;         // Print the file with adjusted rotation
            viewer.PrintPageDialog = false;   // Do not produce the page number dialog when printing

            // Create objects for printer and page settings
            var printerSettings = new PrinterSettings
            {
                // Set XPS/PDF printer name
                PrinterName = "Microsoft XPS Document Writer"
                // Or set the PDF printer
                // PrinterName = "Adobe PDF"
            };

            var pageSettings = new PageSettings
            {
                // Set PageSize (if required)
                PaperSize = new PaperSize("A4", 827, 1169),

                // Set PageMargins (if required)
                Margins = new Margins(0, 0, 0, 0)
            };

            // Print document using printer and page settings
            viewer.PrintDocumentWithSettings(pageSettings, printerSettings);

            // Close the PDF file after printing
            viewer.Close();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PrintoXPSPrinter.Run: {ex.Message}");
        }
        // ExEnd:PrintoXPSPrinter
    }

    /// <summary>
    /// Demonstrates printing a PDF to a file (XPS) without showing the print dialog.
    /// </summary>
    public static void HideDialgo()
    {
        // ExStart:HideDialgo
        try
        {
            string inputPath = Path.Combine(InputDir, "input.pdf");
            string outputPath = Path.Combine(OutputDir, "print_out.xps");

            // Create PdfViewer object and bind PDF file
            using var pdfViewer = new PdfViewer();
            pdfViewer.BindPdf(inputPath);

            // Set PrinterSettings and PageSettings
            var printerSettings = new PrinterSettings
            {
                Copies = 1,
                PrinterName = "Microsoft XPS Document Writer",
                PrintFileName = outputPath,
                PrintToFile = true
            };

            // Disable print page dialog
            pdfViewer.PrintPageDialog = false;

            // Pass printer settings object to the method
            pdfViewer.PrintDocumentWithSettings(printerSettings);
            pdfViewer.Close();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PrintoXPSPrinter.HideDialgo: {ex.Message}");
        }
        // ExEnd:HideDialgo
    }

    /// <summary>
    /// Demonstrates printing a PDF while ensuring system fonts are embedded.
    /// </summary>
    public static void FontsNotEmbedded()
    {
        // ExStart:FontsNotEmbedded
        try
        {
            string inputPath = Path.Combine(InputDir, "input.pdf");

            // Create PdfViewer object
            using var viewer = new PdfViewer();

            // Open input PDF file
            viewer.BindPdf(inputPath);

            // Set attributes for printing
            viewer.AutoResize = true;         // Print the file with adjusted size
            viewer.AutoRotate = true;         // Print the file with adjusted rotation
            viewer.PrintPageDialog = false;   // Do not produce the page number dialog when printing

            // Create objects for printer and page settings
            var printerSettings = new PrinterSettings
            {
                // Set XPS/PDF printer name
                PrinterName = "Microsoft XPS Document Writer"
                // Or set the PDF printer
                // PrinterName = "Adobe PDF"
            };

            var pageSettings = new PageSettings
            {
                // Set PageSize (if required)
                PaperSize = new PaperSize("A4", 827, 1169),

                // Set PageMargins (if required)
                Margins = new Margins(0, 0, 0, 0)
            };

            // Render all system fonts with native system approach (embed the fonts to output documents)
            viewer.RenderingOptions.SystemFontsNativeRendering = true;

            // Print document using printer and page settings
            viewer.PrintDocumentWithSettings(pageSettings, printerSettings);

            // Close the PDF file after printing
            viewer.Close();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PrintoXPSPrinter.FontsNotEmbedded: {ex.Message}");
        }
        // ExEnd:FontsNotEmbedded
    }
}