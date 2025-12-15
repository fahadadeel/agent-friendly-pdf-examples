using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.StampsWatermarks;

public class DefineAlignment
{
    /// <summary>
    /// Demonstrates how to define horizontal and vertical alignment for a text stamp.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directory (directory where the application is running)
            string baseDir = AppContext.BaseDirectory;

            // Input PDF path (data/inputs/DefineAlignment.pdf)
            string inputPath = Path.Combine(baseDir, "data", "inputs", "DefineAlignment.pdf");

            // Ensure the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Output PDF path (data/outputs/StampedPDF_out.pdf)
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "StampedPDF_out.pdf");

            // Instantiate Document object with input file
            Document doc = new Document(inputPath);

            // Instantiate FormattedText object with sample string
            FormattedText text = new FormattedText("This");
            // Add new text lines to FormattedText
            text.AddNewLineText("is sample");
            text.AddNewLineText("Center Aligned");
            text.AddNewLineText("TextStamp");
            text.AddNewLineText("Object");

            // Create TextStamp object using FormattedText
            TextStamp stamp = new TextStamp(text);

            // Specify the Horizontal Alignment of text stamp as Center aligned
            stamp.HorizontalAlignment = HorizontalAlignment.Center;
            // Specify the Vertical Alignment of text stamp as Center aligned
            stamp.VerticalAlignment = VerticalAlignment.Center;
            // Specify the Text Horizontal Alignment of TextStamp as Center aligned
            stamp.TextAlignment = HorizontalAlignment.Center;

            // Set top margin for stamp object
            stamp.TopMargin = 20;

            // Add the stamp object over first page of document
            doc.Pages[1].AddStamp(stamp);

            // Save the updated document
            doc.Save(outputPath);

            Console.WriteLine($"\nAlignment defined successfully for text stamp.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}