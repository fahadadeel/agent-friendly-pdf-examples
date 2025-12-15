using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates conversion of PDF documents to PowerPoint (PPTX) using Aspose.Pdf.
/// </summary>
public class PDFToPPT
{
    /// <summary>
    /// Converts a PDF file to PPTX format.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "PDFToPPT_out.pptx");

            // Load PDF document.
            Document doc = new Document(inputPath);

            // Instantiate PptxSaveOptions.
            PptxSaveOptions pptxSave = new PptxSaveOptions();

            // Save the output in PPTX format.
            doc.Save(outputPath, pptxSave);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PDFToPPT.Run: {ex.Message}");
        }
    }

    /// <summary>
    /// Converts a PDF file to PPTX format with each slide rendered as an image.
    /// </summary>
    public static void PDFtoPPTXWithSlidesAsImages()
    {
        try
        {
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "PDFToPPT_out_.pptx");

            Document doc = new Document(inputPath);
            PptxSaveOptions pptxSave = new PptxSaveOptions
            {
                SlidesAsImages = true
            };

            doc.Save(outputPath, pptxSave);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PDFToPPT.PDFtoPPTXWithSlidesAsImages: {ex.Message}");
        }
    }

    /// <summary>
    /// Converts a PDF file to PPTX format while tracking conversion progress.
    /// </summary>
    public static void PDFtoPTTXWithProgressTracking()
    {
        try
        {
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "PDFToPPTWithProgressTracking_out_.pptx");

            Document doc = new Document(inputPath);
            PptxSaveOptions pptxSave = new PptxSaveOptions
            {
                CustomProgressHandler = ShowProgressOnConsole
            };

            doc.Save(outputPath, pptxSave);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PDFToPPT.PDFtoPTTXWithProgressTracking: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles progress events raised during PDF to PPTX conversion.
    /// </summary>
    /// <param name="eventInfo">Information about the progress event.</param>
    public static void ShowProgressOnConsole(PptxSaveOptions.ProgressEventHandlerInfo eventInfo)
    {
        // ExStart: ShowProgressOnConsole
        switch (eventInfo.EventType)
        {
            case ProgressEventType.TotalProgress:
                Console.WriteLine($"{DateTime.Now.TimeOfDay}  - Conversion progress : {eventInfo.Value}% .");
                break;
            case ProgressEventType.ResultPageCreated:
                Console.WriteLine($"{DateTime.Now.TimeOfDay}  - Result page's {eventInfo.Value} of {eventInfo.MaxValue} layout created.");
                break;
            case ProgressEventType.ResultPageSaved:
                Console.WriteLine($"{DateTime.Now.TimeOfDay}  - Result page {eventInfo.Value} of {eventInfo.MaxValue} exported.");
                break;
            case ProgressEventType.SourcePageAnalysed:
                Console.WriteLine($"{DateTime.Now.TimeOfDay}  - Source page {eventInfo.Value} of {eventInfo.MaxValue} analyzed.");
                break;
            default:
                // No action needed for other event types.
                break;
        }
        // ExEnd: ShowProgressOnConsole
    }
}