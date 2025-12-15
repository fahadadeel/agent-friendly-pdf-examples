using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Stamps_Watermarks;

/// <summary>
/// Demonstrates adding different headers (text stamps) to a PDF document using Aspose.Pdf.
/// </summary>
public class AddingDifferentHeaders
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories relative to the application base path.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "AddingDifferentHeaders.pdf");
            string outputPath = Path.Combine(outputDir, "multiheader_out.pdf");

            // Open source document.
            Document doc = new Document(inputPath);

            // Create three text stamps.
            TextStamp stamp1 = new TextStamp("Header 1");
            TextStamp stamp2 = new TextStamp("Header 2");
            TextStamp stamp3 = new TextStamp("Header 3");

            // Configure first stamp.
            stamp1.VerticalAlignment = VerticalAlignment.Top;
            stamp1.HorizontalAlignment = HorizontalAlignment.Center;
            stamp1.TextState.FontStyle = FontStyles.Bold;
            stamp1.TextState.ForegroundColor = Color.Red;
            stamp1.TextState.FontSize = 14;

            // Configure second stamp.
            stamp2.VerticalAlignment = VerticalAlignment.Top;
            stamp2.HorizontalAlignment = HorizontalAlignment.Center;
            stamp2.Zoom = 10;

            // Configure third stamp.
            stamp3.VerticalAlignment = VerticalAlignment.Top;
            stamp3.HorizontalAlignment = HorizontalAlignment.Center;
            stamp3.RotateAngle = 35;
            stamp3.TextState.BackgroundColor = Color.Pink;
            stamp3.TextState.Font = FontRepository.FindFont("Verdana");

            // Add stamps to respective pages.
            doc.Pages[1].AddStamp(stamp1);
            doc.Pages[2].AddStamp(stamp2);
            doc.Pages[3].AddStamp(stamp3);

            // Save the updated document.
            doc.Save(outputPath);

            Console.WriteLine("\nDifferent headers added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while adding headers: " + ex.Message);
        }
    }
}