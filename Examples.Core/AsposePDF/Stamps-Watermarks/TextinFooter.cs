using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Stamps_Watermarks;

/// <summary>
/// Demonstrates how to add a text stamp as a footer on each page of a PDF document.
/// </summary>
public class TextInFooter
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
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "TextinFooter.pdf");
            string outputPath = Path.Combine(outputDir, "TextinFooter_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Create a text stamp to be used as a footer.
            TextStamp textStamp = new TextStamp("Footer Text")
            {
                BottomMargin = 10,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom
            };

            // Add the footer stamp to all pages.
            foreach (Page page in pdfDocument.Pages)
            {
                page.AddStamp(textStamp);
            }

            // Save the updated PDF file.
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nText in footer added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while adding a footer to the PDF: " + ex.Message);
        }
    }
}

// TODO: Ensure Aspose.Pdf library is referenced in the project.