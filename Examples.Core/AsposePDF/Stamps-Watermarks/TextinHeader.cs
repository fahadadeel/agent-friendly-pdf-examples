using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.StampsWatermarks;

public class TextInHeader
{
    /// <summary>
    /// Adds a text stamp as a header to each page of the input PDF and saves the result.
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

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "TextinHeader.pdf");
            string outputPath = Path.Combine(outputDir, "TextinHeader_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Create a text stamp to be used as a header.
            TextStamp textStamp = new TextStamp("Header Text")
            {
                TopMargin = 10,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };

            // Add the stamp to every page.
            foreach (Page page in pdfDocument.Pages)
            {
                page.AddStamp(textStamp);
            }

            // Save the updated document.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nText in header added successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in TextInHeader.Run: {ex.Message}");
        }
    }
}