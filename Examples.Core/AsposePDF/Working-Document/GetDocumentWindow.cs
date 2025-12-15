using System;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Demonstrates retrieving various window-related properties from a PDF document.
/// </summary>
namespace Examples.Core.AsposePDF.Working_Document;

public class GetDocumentWindow
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input file path.
            string inputPath = Path.Combine(AppContext.BaseDirectory, "data", "inputs", "GetDocumentWindow.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (not used in this example but created per requirements).
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Open document
            Document pdfDocument = new Document(inputPath);

            // Output various document window properties
            Console.WriteLine("CenterWindow : {0}", pdfDocument.CenterWindow);
            Console.WriteLine("Direction : {0}", pdfDocument.Direction);
            Console.WriteLine("DisplayDocTitle : {0}", pdfDocument.DisplayDocTitle);
            Console.WriteLine("FitWindow : {0}", pdfDocument.FitWindow);
            Console.WriteLine("HideMenuBar : {0}", pdfDocument.HideMenubar);
            Console.WriteLine("HideToolBar : {0}", pdfDocument.HideToolBar);
            Console.WriteLine("HideWindowUI : {0}", pdfDocument.HideWindowUI);
            Console.WriteLine("NonFullScreenPageMode : {0}", pdfDocument.NonFullScreenPageMode);
            Console.WriteLine("PageLayout : {0}", pdfDocument.PageLayout);
            Console.WriteLine("PageMode : {0}", pdfDocument.PageMode);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}