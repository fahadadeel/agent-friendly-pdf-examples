using System;
using System.IO;
using System.Text;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Text;

/// <summary>
/// Demonstrates extracting text from a PDF using Aspose.Pdf.Facades.PdfExtractor.
/// </summary>
public class ExtractText
{
    /// <summary>
    /// Runs the example.
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

            // Input PDF path.
            string inputPath = Path.Combine(inputDir, "ExtractText.pdf");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Initialize PdfExtractor and bind the PDF.
            PdfExtractor pdfExtractor = new PdfExtractor();
            pdfExtractor.BindPdf(inputPath);

            // Extract text.
            pdfExtractor.ExtractText();

            // Retrieve extracted text into a memory stream.
            using MemoryStream tempMemoryStream = new MemoryStream();
            pdfExtractor.GetText(tempMemoryStream);

            // Read text using Unicode encoding.
            string text;
            tempMemoryStream.Seek(0, SeekOrigin.Begin);
            using (StreamReader streamReader = new StreamReader(tempMemoryStream, Encoding.Unicode))
            {
                text = streamReader.ReadToEnd();
            }

            // Write extracted text to output file.
            string outputPath = Path.Combine(outputDir, "output_out.txt");
            File.WriteAllText(outputPath, text, Encoding.Unicode);
            Console.WriteLine($"Text extracted to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}