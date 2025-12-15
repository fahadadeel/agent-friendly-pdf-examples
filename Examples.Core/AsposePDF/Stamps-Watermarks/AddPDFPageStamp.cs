using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Stamps_Watermarks;

/// <summary>
/// Demonstrates adding a page stamp to a PDF document using Aspose.Pdf.
/// </summary>
public class AddPDFPageStamp
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "PDFPageStamp.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "PDFPageStamp_out.pdf");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open document
            Document pdfDocument = new Document(inputPath);

            // Create page stamp for the first page (index 1)
            PdfPageStamp pageStamp = new PdfPageStamp(pdfDocument.Pages[1]);
            pageStamp.Background = true;
            pageStamp.XIndent = 100;
            pageStamp.YIndent = 100;
            pageStamp.Rotate = Rotation.on180;

            // Add stamp to particular page
            pdfDocument.Pages[1].AddStamp(pageStamp);

            // Save output document
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nPdf page stamp added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error adding PDF page stamp: {ex.Message}");
        }
    }
}