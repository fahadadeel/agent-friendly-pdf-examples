using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.SplitPages;

/// <summary>
/// Demonstrates splitting a PDF document into individual pages using file paths.
/// </summary>
public class SplitToIndividualPagesUsingPaths
{
    /// <summary>
    /// Executes the split operation.
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

            // Path to the source PDF.
            string inputPath = Path.Combine(inputDir, "input.pdf");

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Split the document into individual pages (each page as a MemoryStream).
            MemoryStream[] pageStreams = pdfEditor.SplitToPages(inputPath);

            // Save each page to a separate PDF file.
            int fileNumber = 1;
            foreach (MemoryStream pageStream in pageStreams)
            {
                string outputPath = Path.Combine(outputDir, $"File_{fileNumber}_out.pdf");

                // Ensure the MemoryStream position is at the beginning before writing.
                pageStream.Position = 0;

                using (FileStream outFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    pageStream.CopyTo(outFile);
                }

                fileNumber++;
            }

            Console.WriteLine($"Successfully split PDF into {fileNumber - 1} individual pages.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while splitting the PDF: {ex.Message}");
        }
    }
}