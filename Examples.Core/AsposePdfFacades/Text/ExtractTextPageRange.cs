using System;
using System.IO;
using System.Text;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Text;

public class ExtractTextPageRange
{
    /// <summary>
    /// Extracts text from the first page of a PDF and writes it to a text file.
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

            string inputPath = Path.Combine(inputDir, "ExtractText-PageRange.pdf");
            string outputPath = Path.Combine(outputDir, "output_out.txt");

            // Open input PDF
            var pdfExtractor = new PdfExtractor();
            pdfExtractor.BindPdf(inputPath);

            // Specify start and end pages (first page)
            pdfExtractor.StartPage = 1;
            pdfExtractor.EndPage = 1;

            // Extract text
            pdfExtractor.ExtractText();

            using var tempMemoryStream = new MemoryStream();
            pdfExtractor.GetText(tempMemoryStream);

            string text;
            // Read extracted text using Unicode encoding
            using (var sr = new StreamReader(tempMemoryStream, Encoding.Unicode))
            {
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                text = sr.ReadToEnd();
            }

            File.WriteAllText(outputPath, text);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ExtractTextPageRange.Run: {ex.Message}");
        }
    }
}