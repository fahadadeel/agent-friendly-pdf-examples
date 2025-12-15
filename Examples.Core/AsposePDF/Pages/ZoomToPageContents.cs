using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.Pages;

/// <summary>
/// Demonstrates how to zoom to page contents using Aspose.Pdf.
/// </summary>
public class ZoomToPageContents
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // ExStart:ZoomToPageContents
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "ZoomToPageContents_out.pdf");

            // Load source PDF file.
            Document doc = new Document(inputPath);

            // Get rectangular region of first page of PDF.
            Aspose.Pdf.Rectangle rect = doc.Pages[1].Rect;

            // Instantiate PdfPageEditor instance.
            PdfPageEditor ppe = new PdfPageEditor();

            // Bind source PDF.
            ppe.BindPdf(inputPath);

            // Set zoom coefficient.
            ppe.Zoom = (float)(rect.Width / rect.Height);

            // Update page size.
            ppe.PageSize = new Aspose.Pdf.PageSize((float)rect.Height, (float)rect.Width);

            // Save output file.
            doc.Save(outputPath);
            // ExEnd:ZoomToPageContents

            Console.WriteLine("\nZoom to page contents applied successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("An error occurred while executing ZoomToPageContents: " + ex.Message);
        }
    }
}