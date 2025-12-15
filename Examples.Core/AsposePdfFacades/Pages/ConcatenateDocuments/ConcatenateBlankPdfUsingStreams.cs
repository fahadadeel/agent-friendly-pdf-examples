using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.ConcatenateDocuments;

public class ConcatenateBlankPdfUsingStreams
{
    /// <summary>
    /// Demonstrates concatenating two PDF files and a blank PDF using streams.
    /// </summary>
    public static void Run()
    {
        // ExStart:ConcatenateBlankPdfUsingStreams
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

            // Build full paths for the source PDFs and the result PDF.
            string inputPath1 = Path.Combine(inputDir, "input.pdf");
            string inputPath2 = Path.Combine(inputDir, "input2.pdf");
            string blankPath = Path.Combine(inputDir, "blank.pdf");
            string outputPath = Path.Combine(outputDir, "ConcatenateBlankPdfUsingStreams_out.pdf");

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Open streams for the source PDFs and the output PDF.
            using FileStream inputStream1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read);
            using FileStream inputStream2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read);
            using FileStream blankStream = new FileStream(blankPath, FileMode.Open, FileAccess.Read);
            using FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            // Concatenate the PDFs.
            pdfEditor.Concatenate(inputStream1, inputStream2, blankStream, outputStream);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF concatenation: {ex.Message}");
        }
        // ExEnd:ConcatenateBlankPdfUsingStreams
    }
}