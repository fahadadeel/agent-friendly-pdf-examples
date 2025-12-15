using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.WorkingDocument;

/// <summary>
/// Demonstrates setting various document window and display properties using Aspose.Pdf.
/// </summary>
public class SetDocumentWindow
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
            string inputPath = Path.Combine(inputDir, "SetDocumentWindow.pdf");
            string outputPath = Path.Combine(outputDir, "SetDocumentWindow_out.pdf");

            // Open document.
            Document pdfDocument = new Document(inputPath);

            // Set different document properties.
            pdfDocument.CenterWindow = true;
            pdfDocument.Direction = Direction.R2L;
            pdfDocument.DisplayDocTitle = true;
            pdfDocument.FitWindow = true;
            pdfDocument.HideMenubar = true;
            pdfDocument.HideToolBar = true;
            pdfDocument.HideWindowUI = true;
            pdfDocument.NonFullScreenPageMode = PageMode.UseOC;
            pdfDocument.PageLayout = PageLayout.TwoColumnLeft;
            pdfDocument.PageMode = PageMode.UseThumbs;

            // Save updated PDF file.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nDocument window and page display properties setup successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SetDocumentWindow.Run: {ex.Message}");
        }
    }
}