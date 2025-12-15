using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.DocumentConversion;

public class TextToPDF
{
    /// <summary>
    /// Converts a plain text file to a PDF document using Aspose.Pdf.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Path to the source text file.
            string inputPath = Path.Combine(inputDir, "log.txt");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Read the entire text file.
            string textContent;
            using (var reader = new StreamReader(inputPath))
            {
                textContent = reader.ReadToEnd();
            }

            // Create a new PDF document.
            var doc = new Document();

            // Add a page.
            var page = doc.Pages.Add();

            // Create a TextFragment with the read text.
            var textFragment = new TextFragment(textContent);
            // TextFragment.TextState.Font = FontRepository.FindFont("Arial Unicode MS"); // Optional font setting.

            // Add the text fragment to the page.
            page.Paragraphs.Add(textFragment);

            // Save the PDF to the output directory.
            string outputPath = Path.Combine(outputDir, "TexttoPDF_out.pdf");
            doc.Save(outputPath);

            Console.WriteLine($"PDF successfully created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}