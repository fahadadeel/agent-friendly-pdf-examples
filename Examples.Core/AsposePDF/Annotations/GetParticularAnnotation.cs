using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Annotations;

/// <summary>
/// Demonstrates retrieving a particular annotation from a PDF document.
/// </summary>
public class GetParticularAnnotation
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Verify the input directory exists.
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDir}");
                return;
            }

            // Path to the source PDF file.
            string pdfPath = Path.Combine(inputDir, "GetParticularAnnotation.pdf");
            if (!File.Exists(pdfPath))
            {
                Console.Error.WriteLine($"Input PDF not found: {pdfPath}");
                return;
            }

            // Open the PDF document.
            Document pdfDocument = new Document(pdfPath);

            // Retrieve the specific annotation (page 1, annotation index 1).
            // Note: Aspose.Pdf uses 1‑based indexing for pages; the Annotations collection is also 1‑based in this example.
            TextAnnotation textAnnotation = (TextAnnotation)pdfDocument.Pages[1].Annotations[1];

            // Output annotation properties.
            Console.WriteLine("Title : {0} ", textAnnotation.Title);
            Console.WriteLine("Subject : {0} ", textAnnotation.Subject);
            Console.WriteLine("Contents : {0} ", textAnnotation.Contents);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in GetParticularAnnotation.Run: {ex.Message}");
        }
    }
}