using Aspose.Pdf;
using Aspose.Pdf.Facades;
using System;
using System.IO;

namespace Examples.Core.AsposePDF.Working_Document;

public class SetPresetPropertiesForPrintDialog
{
    /// <summary>
    /// Demonstrates setting preset properties for the print dialog.
    /// </summary>
    public static void Run()
    {
        // Determine directories
        string baseDir = AppContext.BaseDirectory;
        string outputDir = Path.Combine(baseDir, "data", "outputs");
        Directory.CreateDirectory(outputDir);

        string outputPath = Path.Combine(outputDir, "35297_out.pdf");

        try
        {
            using var doc = new Document();
            doc.Pages.Add();
            doc.Duplex = PrintDuplex.DuplexFlipLongEdge;
            doc.Save(outputPath, SaveFormat.Pdf);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in Run: {ex.Message}");
        }
    }

    /// <summary>
    /// Sets print dialog properties using PdfContentEditor.
    /// </summary>
    public static void SetPrintDlgPropertiesUsingPdfContentEditor()
    {
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");
        Directory.CreateDirectory(inputDir);
        Directory.CreateDirectory(outputDir);

        string inputFile = Path.Combine(inputDir, "input.pdf");
        string outputFile = Path.Combine(outputDir, "SetPrintDlgPropertiesUsingPdfContentEditor_out.pdf");

        try
        {
            using var editor = new PdfContentEditor();
            editor.BindPdf(inputFile);
            if ((editor.GetViewerPreference() & ViewerPreference.DuplexFlipShortEdge) > 0)
            {
                Console.WriteLine("The file has duplex flip short edge");
            }

            editor.ChangeViewerPreference(ViewerPreference.DuplexFlipShortEdge);
            editor.Save(outputFile);
            Console.WriteLine($"Edited PDF saved to {outputFile}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SetPrintDlgPropertiesUsingPdfContentEditor: {ex.Message}");
        }
    }
}