using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.SplitPages;

/// <summary>
/// Demonstrates splitting a PDF into individual pages using streams with Aspose.Pdf.Facades.
/// </summary>
public class SplitToIndividualPagesUsingStreams
{
    /// <summary>
    /// Splits the input PDF into separate page files.
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Split to pages using a stream.
            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                MemoryStream[] outBuffers = pdfEditor.SplitToPages(inputStream);
                int fileNumber = 1;

                foreach (MemoryStream pageStream in outBuffers)
                {
                    string outputPath = Path.Combine(outputDir, $"File_{fileNumber}_out.pdf");
                    using (FileStream outStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        pageStream.WriteTo(outStream);
                    }

                    fileNumber++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while splitting the PDF: {ex.Message}");
        }
    }
}