using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Links_Actions;

/// <summary>
/// Demonstrates creating an application link annotation in a PDF document using Aspose.Pdf.
/// </summary>
public class CreateApplicationLink
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
            string inputPath = Path.Combine(inputDir, "CreateApplicationLink.pdf");
            string outputPath = Path.Combine(outputDir, "CreateApplicationLink_out.pdf");

            // Open document.
            var document = new Document(inputPath);

            // Create link annotation on the first page.
            Page page = document.Pages[1];
            var linkRect = new Aspose.Pdf.Rectangle(100, 100, 300, 300);
            var link = new LinkAnnotation(page, linkRect)
            {
                Color = Aspose.Pdf.Color.FromRgb(0, 255, 0), // Green
                Action = new LaunchAction(document, inputPath)
            };
            page.Annotations.Add(link);

            // Save updated document.
            document.Save(outputPath);

            Console.WriteLine($"\nApplication link created successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error creating application link: {ex.Message}");
        }
    }
}