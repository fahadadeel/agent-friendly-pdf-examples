using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

// TODO: import RunExamples helper class from original source

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

/// <summary>
/// Demonstrates adding a rotating stamp (watermark) to a PDF document using Aspose.Pdf.Facades.
/// </summary>
public class RotatingStamp
{
    /// <summary>
    /// Executes the rotating stamp example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Input files
            string imageFile = Path.Combine(inputDir, "aspose-logo.jpg");
            string inFile = Path.Combine(inputDir, "inFile.pdf");

            // Output file
            string outFile = Path.Combine(outputDir, "RotatingStamp_out.pdf");

            // Create PdfFileInfo object to get height and width of the pages
            PdfFileInfo fileInfo = new PdfFileInfo(inFile);

            // Create Stamp object and bind the image
            Aspose.Pdf.Facades.Stamp aStamp = new Aspose.Pdf.Facades.Stamp();
            aStamp.BindImage(imageFile);
            aStamp.IsBackground = false;
            aStamp.Pages = new int[] { 1 };
            aStamp.Rotation = 90;

            // Position the stamp at the center of the first page
            aStamp.SetOrigin(fileInfo.GetPageWidth(1) / 2, fileInfo.GetPageHeight(1) / 2);

            // Set the size of the watermark
            aStamp.SetImageSize(100, 100);

            // Create PdfFileStamp to apply the stamp and write to the output file
            PdfFileStamp stamper = new PdfFileStamp(inFile, outFile);
            stamper.AddStamp(aStamp);
            stamper.Close();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing RotatingStamp example: {ex.Message}");
        }
    }
}