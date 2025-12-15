using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.TechnicalArticles;

public class ExtractFilesFromPortfolio
{
    /// <summary>
    /// Extracts embedded files from a PDF portfolio and saves them to the output directory.
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

            // Path to the source PDF portfolio.
            string pdfPath = Path.Combine(inputDir, "PDFPortfolio.pdf");

            // Load source PDF Portfolio.
            var pdfDocument = new Document(pdfPath);

            // Get collection of embedded files.
            EmbeddedFileCollection embeddedFiles = pdfDocument.EmbeddedFiles;

            // Iterate through each embedded file.
            foreach (FileSpecification fileSpecification in embeddedFiles)
            {
                // Read the embedded file content.
                using var contentStream = fileSpecification.Contents;
                byte[] fileContent = new byte[contentStream.Length];
                contentStream.Read(fileContent, 0, fileContent.Length);

                // Determine output file name.
                string filename = Path.GetFileName(fileSpecification.Name);
                string outputPath = Path.Combine(outputDir, "_out" + filename);

                // Write the extracted file.
                using var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
                fileStream.Write(fileContent, 0, fileContent.Length);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error extracting files from portfolio: {ex.Message}");
        }
    }
}