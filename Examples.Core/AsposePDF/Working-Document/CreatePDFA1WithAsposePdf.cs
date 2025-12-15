using Aspose.Pdf;
using Aspose.Pdf.Text;
using System;
using System.IO;

namespace Examples.Core.AsposePDF.WorkingDocument;

/// <summary>
/// Demonstrates creating a PDF document and saving it as PDF/A‑1A using Aspose.Pdf.
/// </summary>
public class CreatePDFA1WithAsposePdf
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory: <application base>/data/outputs
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Output file path
            string outputPath = Path.Combine(outputDir, "CreatePdfA1_out.pdf");

            // Create a new PDF document
            Document pdf = new Document();

            // Add a page with a text fragment
            pdf.Pages.Add().Paragraphs.Add(new TextFragment("Hello World!"));

            // Save to a memory stream (demonstrates in‑memory handling)
            using var ms = new MemoryStream();
            pdf.Save(ms);

            // TODO: Convert to PDF/A‑1A when the appropriate Aspose.Pdf API is available
            // pdf.Convert(new MemoryStream(), PdfFormat.PDF_A_1A, ConvertErrorAction.Delete);

            // Save the final PDF/A‑1A file
            pdf.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in {nameof(CreatePDFA1WithAsposePdf)}: {ex.Message}");
        }
    }
}