using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.ManipulatePageProperties;

public class GetPageProperties
{
    /// <summary>
    /// Demonstrates how to retrieve various page properties using Aspose.Pdf.Facades.PdfPageEditor.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input PDF path relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (not used in this example but created per requirements).
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Open document using PdfPageEditor.
            PdfPageEditor pageEditor = new PdfPageEditor();
            pageEditor.BindPdf(inputPath);

            // Get page properties.
            Console.WriteLine(pageEditor.GetPageRotation(1));
            Console.WriteLine(pageEditor.GetPages());
            Console.WriteLine(pageEditor.GetPageBoxSize(1, "trim"));
            Console.WriteLine(pageEditor.GetPageBoxSize(1, "art"));
            Console.WriteLine(pageEditor.GetPageBoxSize(1, "bleed"));
            Console.WriteLine(pageEditor.GetPageBoxSize(1, "crop"));
            Console.WriteLine(pageEditor.GetPageBoxSize(1, "media"));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing GetPageProperties: {ex.Message}");
        }
    }
}