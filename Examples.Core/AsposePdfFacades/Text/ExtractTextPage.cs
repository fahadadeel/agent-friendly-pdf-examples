using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using System.Text;

namespace Examples.Core.AsposePdfFacades.Text;

/// <summary>
/// Demonstrates extracting text from each page of a PDF using Aspose.Pdf.Facades.
/// </summary>
public class ExtractTextPage
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

            // Path to the source PDF.
            string inputPdfPath = Path.Combine(inputDir, "ExtractText-Page.pdf");

            // Open input PDF.
            PdfExtractor pdfExtractor = new PdfExtractor();
            pdfExtractor.BindPdf(inputPdfPath);

            // Extract text from the PDF.
            pdfExtractor.ExtractText();

            int pageNumber = 1;

            // Iterate through each page's extracted text.
            while (pdfExtractor.HasNextPageText())
            {
                using var tempMemoryStream = new MemoryStream();
                pdfExtractor.GetNextPageText(tempMemoryStream);

                // Reset stream position before reading.
                tempMemoryStream.Seek(0, SeekOrigin.Begin);

                string text;
                using (var streamReader = new StreamReader(tempMemoryStream, Encoding.Unicode))
                {
                    text = streamReader.ReadToEnd();
                }

                // Write the extracted text to an output file.
                string outputPath = Path.Combine(outputDir, $"output{pageNumber}_out.txt");
                File.WriteAllText(outputPath, text);

                pageNumber++;
            }
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine($"Error during PDF text extraction: {ex.Message}");
        }
    }
}