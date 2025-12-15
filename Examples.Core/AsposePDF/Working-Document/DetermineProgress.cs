using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.WorkingDocument;

/// <summary>
/// Demonstrates how to monitor conversion progress when saving a PDF document using Aspose.Pdf.
/// </summary>
public class DetermineProgress
{
    /// <summary>
    /// Executes the progress‑monitoring example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "AddTOC.pdf");
            string outputPath = Path.Combine(outputDir, "DetermineProgress_out.pdf");

            // Open the source PDF document.
            Document pdfDocument = new Document(inputPath);

            // Configure save options with a custom progress handler.
            DocSaveOptions saveOptions = new DocSaveOptions();
            saveOptions.CustomProgressHandler = new UnifiedSaveOptions.ConversionProgressEventHandler(ShowProgressOnConsole);

            // Save the document while reporting progress.
            pdfDocument.Save(outputPath, saveOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during DetermineProgress execution: {ex.Message}");
        }
    }

    // ExStart:ShowProgressOnConsole
    /// <summary>
    /// Handles progress events raised by Aspose.Pdf during document conversion.
    /// </summary>
    /// <param name="eventInfo">Information about the progress event.</param>
    public static void ShowProgressOnConsole(DocSaveOptions.ProgressEventHandlerInfo eventInfo)
    {
        switch (eventInfo.EventType)
        {
            case ProgressEventType.TotalProgress:
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()}  - Conversion progress : {eventInfo.Value}% .");
                break;
            case ProgressEventType.SourcePageAnalysed:
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()}  - Source page {eventInfo.Value} of {eventInfo.MaxValue} analyzed.");
                break;
            case ProgressEventType.ResultPageCreated:
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()}  - Result page's {eventInfo.Value} of {eventInfo.MaxValue} layout created.");
                break;
            case ProgressEventType.ResultPageSaved:
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()}  - Result page {eventInfo.Value} of {eventInfo.MaxValue} exported.");
                break;
            default:
                // No action required for other event types.
                break;
        }
    }
    // ExEnd:ShowProgressOnConsole
}