using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Annotations;

/// <summary>
/// Demonstrates how to retrieve all annotations from a specific page of a PDF document.
/// </summary>
public class GetAllAnnotationsFromPage
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");

            // Ensure directories exist.
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Input directory does not exist: {inputDir}");
                return;
            }
            Directory.CreateDirectory(outputDir); // Create if missing.

            // Resolve the full path to the input PDF.
            string inputPath = Path.Combine(inputDir, "GetAllAnnotationsFromPage.pdf");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open the PDF document using the path overload.
            Document pdfDocument = new Document(inputPath);

            // Verify that the document contains at least one page.
            if (pdfDocument.Pages.Count < 1)
            {
                Console.Error.WriteLine("The PDF document does not contain any pages.");
                return;
            }

            // Loop through all the annotations on the first page (page index is 1).
            foreach (MarkupAnnotation annotation in pdfDocument.Pages[1].Annotations)
            {
                Console.WriteLine("Title : {0} ", annotation.Title);
                Console.WriteLine("Subject : {0} ", annotation.Subject);
                Console.WriteLine("Contents : {0} ", annotation.Contents);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}