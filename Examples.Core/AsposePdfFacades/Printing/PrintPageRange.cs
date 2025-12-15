using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Printing;

/// <summary>
/// Demonstrates printing a PDF with a specific page range using Aspose.Pdf.Facades.
/// </summary>
public class PrintPageRange
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

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input PDF files.
            string pdfToPrintPath = Path.Combine(inputDir, "Print-PageRange.pdf");
            string pdfToEditPath = Path.Combine(inputDir, "input.pdf");

            // -----------------------------------------------------------------
            // The original example uses System.Drawing.Printing types to send the
            // document to a printer. Those APIs are platform‑specific and have been
            // omitted from this cross‑platform sample.
            // TODO: Implement printing logic using Aspose.Pdf.Facades.PdfViewer with
            // appropriate System.Drawing.Printing types on Windows platforms.
            // -----------------------------------------------------------------

            // Example (commented) showing how the original code would look:
            /*
            Aspose.Pdf.Facades.PdfViewer pdfv = new Aspose.Pdf.Facades.PdfViewer();

            // pdfv.PdfQueryPageSettings += PdfvOnPdfQueryPageSettings;

            System.Drawing.Printing.PageSettings pgs = new System.Drawing.Printing.PageSettings();
            System.Drawing.Printing.PrinterSettings prin = new System.Drawing.Printing.PrinterSettings();

            pdfv.BindPdf(pdfToPrintPath);
            prin.PrinterName = "HP LaserJet M9050 MFP PCL6";
            prin.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1169);

            Aspose.Pdf.Facades.PdfPageEditor pageEditor = new Aspose.Pdf.Facades.PdfPageEditor();
            pageEditor.BindPdf(pdfToEditPath);

            pgs.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            pgs.PaperSize = prin.DefaultPageSettings.PaperSize;

            pdfv.PrintDocumentWithSettings(pgs, prin);
            pdfv.Close();
            */

            // Placeholder: create a PdfViewer instance to demonstrate binding (no printing).
            var pdfViewer = new PdfViewer();
            pdfViewer.BindPdf(pdfToPrintPath);
            // No further action – printing is platform‑specific.
            pdfViewer.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // ExStart:PdfvOnPdfQueryPageSettings
    private static void PdfvOnPdfQueryPageSettings(
        object sender,
        System.Drawing.Printing.QueryPageSettingsEventArgs queryPageSettingsEventArgs,
        PdfPrintPageInfo currentPageInfo)
    {
        // The original implementation adjusts the paper source based on odd/even pages.
        // This code relies on System.Drawing.Printing which is Windows‑specific.
        // TODO: Review and implement platform‑specific logic if needed.

        bool isOdd = currentPageInfo.PageNumber % 2 != 0;

        System.Drawing.Printing.PrinterSettings.PaperSourceCollection paperSources =
            queryPageSettingsEventArgs.PageSettings.PrinterSettings.PaperSources;

        if (isOdd)
            queryPageSettingsEventArgs.PageSettings.PaperSource = paperSources[0];
        else
            queryPageSettingsEventArgs.PageSettings.PaperSource = paperSources[1];
    }
    // ExEnd:PdfvOnPdfQueryPageSettings
}