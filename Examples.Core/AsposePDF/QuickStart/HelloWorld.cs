using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.QuickStart;

/// <summary>
/// Demonstrates creating a simple PDF document with "Hello World!" text using Aspose.Pdf.
/// </summary>
public class HelloWorld
{
    /// <summary>
    /// Executes the HelloWorld PDF creation example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory: <app base>/data/outputs
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Output file path
            string outputPath = Path.Combine(outputDir, "HelloWorld_out.pdf");

            // Initialize document object
            var document = new Document();

            // Add page
            Page page = document.Pages.Add();

            // Add text to new page
            page.Paragraphs.Add(new TextFragment("Hello World!"));

            // Save updated PDF
            document.Save(outputPath);

            Console.WriteLine($"\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in HelloWorld.Run: {ex.Message}");
        }
    }
}