using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.BookmarkSamples; // AUTOFIX

/// <summary>
/// Demonstrates exporting PDF bookmarks to XML and saving the updated PDF using Aspose.Pdf.Facades.
/// </summary>
public class ExportToXML
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories relative to the application base path.
            string baseDir = Path.Combine(AppContext.BaseDirectory, "data");
            string inputDir = Path.Combine(baseDir, "inputs");
            string outputDir = Path.Combine(baseDir, "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Define file paths.
            string inputPdfPath = Path.Combine(inputDir, "ExportToXML.pdf");
            string outputXmlPath = Path.Combine(outputDir, "bookmarks.xml");
            string outputPdfPath = Path.Combine(outputDir, "ExportToXML_out.pdf");

            // Create PdfBookmarkEditor object.
            PdfBookmarkEditor bookmarkEditor = new PdfBookmarkEditor();

            // Open PDF file.
            bookmarkEditor.BindPdf(inputPdfPath);

            // Export bookmarks to XML.
            bookmarkEditor.ExportBookmarksToXML(outputXmlPath);

            // Save updated PDF.
            bookmarkEditor.Save(outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during ExportToXML example: {ex.Message}");
        }
    }
}