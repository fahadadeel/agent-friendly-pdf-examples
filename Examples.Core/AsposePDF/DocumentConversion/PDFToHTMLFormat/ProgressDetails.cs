using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion.PDFToHTMLFormat;

public class ProgressDetails
{
    /// <summary>
    /// Converts a PDF document to HTML while demonstrating progress details.
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

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "ProgressDetails_out_.html");

            // Set license if available.
            string licenseFile = string.Empty; // e.g., "F:\\_Sources\\Aspose_5\\trunk\\testdata\\License\\Aspose.Total.lic"
            (new Aspose.Pdf.License()).SetLicense(licenseFile);

            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Configure HTML save options.
            HtmlSaveOptions saveOptions = new HtmlSaveOptions
            {
                SplitIntoPages = false
            };

            // Uncomment and adjust the following line if a custom progress handler is required.
            // saveOptions.CustomProgressHandler = new HtmlSaveOptions.ConversionProgessEventHandler(ShowProgressOnConsole);
            // TODO: verify the correct delegate type for CustomProgressHandler in the Aspose.Pdf version used.

            // Save the document as HTML.
            doc.Save(outputPath, saveOptions);

            // Optional: pause the console to view messages.
            // Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // ExStart:ProgressDetailsHelper
    /// <summary>
    /// Handles progress events raised during PDF to HTML conversion.
    /// </summary>
    /// <param name="eventInfo">Information about the progress event.</param>
    public static void ShowProgressOnConsole(HtmlSaveOptions.ProgressEventHandlerInfo eventInfo)
    {
        switch (eventInfo.EventType)
        {
            case ProgressEventType.TotalProgress:
                Console.WriteLine($"{DateTime.Now.TimeOfDay}  - Conversion progress : {eventInfo.Value}% .");
                break;
            case ProgressEventType.SourcePageAnalysed:
                Console.WriteLine($"{DateTime.Now.TimeOfDay}  - Source page {eventInfo.Value} of {eventInfo.MaxValue} analyzed.");
                break;
            case ProgressEventType.ResultPageCreated:
                Console.WriteLine($"{DateTime.Now.TimeOfDay}  - Result page's {eventInfo.Value} of {eventInfo.MaxValue} layout created.");
                break;
            case ProgressEventType.ResultPageSaved:
                Console.WriteLine($"{DateTime.Now.TimeOfDay}  - Result page {eventInfo.Value} of {eventInfo.MaxValue} exported.");
                break;
            default:
                break;
        }
    }
    // ExEnd:ProgressDetailsHelper
}