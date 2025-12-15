using System;
using System.IO;
using Aspose.Pdf;
// AUTOFIX - removed invalid using directive for SaveOptions
// using Aspose.Pdf.SaveOptions;

namespace Examples.Core.AsposePDF.WorkingDocument;

public class SetDefaultFont
{
    /// <summary>
    /// Demonstrates setting a default font for a PDF document with missing fonts.
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

            // Input PDF file path.
            string documentPath = Path.Combine(inputDir, "input.pdf");
            // Desired default font name.
            string newFontName = "Arial";

            // Load the PDF document.
            using var documentStream = new FileStream(documentPath, FileMode.Open, FileAccess.Read);
            using var document = new Document(documentStream);

            // Configure save options with the default font.
            var pdfSaveOptions = new PdfSaveOptions
            {
                DefaultFontName = newFontName
            };

            // Output PDF file path.
            string outputPath = Path.Combine(outputDir, "output_out.pdf");

            // Save the document with the specified options.
            document.Save(outputPath, pdfSaveOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SetDefaultFont.Run: {ex.Message}");
        }
    }
}