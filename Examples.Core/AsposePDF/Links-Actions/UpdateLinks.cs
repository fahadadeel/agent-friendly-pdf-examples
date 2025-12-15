using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Links_Actions;

/// <summary>
/// Demonstrates how to update link annotations in a PDF document using Aspose.Pdf.
/// </summary>
public class UpdateLinks
{
    /// <summary>
    /// Executes the example.
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
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "UpdateLinks.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Get the first link annotation from the first page of the document.
            // Note: Pages collection is 1‑based; Annotations collection is also 1‑based.
            LinkAnnotation linkAnnot = (LinkAnnotation)doc.Pages[1].Annotations[1];

            // Modify the link's destination.
            GoToAction goToAction = (GoToAction)linkAnnot.Action;
            // Destination: page 1, coordinates (1,1), zoom factor 2 (200%).
            goToAction.Destination = new XYZExplicitDestination(1, 1, 2, 2);

            // Output PDF file.
            string outputPath = Path.Combine(outputDir, "PDFLINK_Modified_UpdateLinks_out.pdf");
            doc.Save(outputPath);

            Console.WriteLine("\nLinks updated successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}