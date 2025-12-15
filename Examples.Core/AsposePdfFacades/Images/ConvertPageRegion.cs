using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using System.Drawing.Imaging; // TODO: platform-specific API — review and implement with guard

namespace Examples.Core.AsposePdfFacades.Images;

public class ConvertPageRegion
{
    /// <summary>
    /// Demonstrates converting a specific region of a PDF page to an image using Aspose.Pdf.Facades.
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

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "Convert-PageRegion.pdf");

            // Instantiate PdfPageEditor to extract a specific region.
            var editor = new PdfPageEditor();
            editor.BindPdf(inputPath);
            editor.MovePosition(0, 700);

            // Save the edited PDF to a memory stream.
            using var ms = new MemoryStream();
            editor.Save(ms);
            ms.Position = 0; // Reset stream position for reading.

            // Convert the first page of the edited PDF to an image.
            var converter = new PdfConverter();
            converter.BindPdf(ms);
            converter.StartPage = 1;
            converter.EndPage = 1;
            converter.DoConvert();

            int page = 1;
            while (converter.HasNextImage())
            {
                string outputPath = Path.Combine(outputDir, $"Specific_Region-Image{page}_out.jpeg");
                converter.GetNextImage(outputPath, ImageFormat.Jpeg);
                page++;
            }

            converter.Close();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ConvertPageRegion.Run: {ex.Message}");
        }
    }
}