using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;
using System;
using System.IO;

/// <summary>
/// Demonstrates extracting text from a stamp annotation in a PDF document.
/// </summary>
namespace Examples.Core.AsposePDF.Stamps_Watermarks;

public class ExtractTextFromStampAnnotation
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "test.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Access the specific stamp annotation (page 1, annotation index 3).
            // Note: Aspose.Pdf uses 1‑based page indexing.
            StampAnnotation annot = doc.Pages[1].Annotations[3] as StampAnnotation;
            if (annot == null)
            {
                Console.WriteLine("Stamp annotation not found at the specified location.");
                return;
            }

            // Extract text from the annotation's normal appearance.
            TextAbsorber ta = new TextAbsorber();
            XForm ap = annot.Appearance["N"];
            ta.Visit(ap);
            Console.WriteLine(ta.Text);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing ExtractTextFromStampAnnotation: {ex.Message}");
        }
    }
}