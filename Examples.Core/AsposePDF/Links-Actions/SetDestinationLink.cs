using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Links_Actions;

/// <summary>
/// Demonstrates setting a destination link in a PDF document using Aspose.Pdf.
/// </summary>
public class SetDestinationLink
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

            // Load the PDF file.
            Document doc = new Document(inputPath);

            // Get the first link annotation from the first page of the document.
            // Note: Aspose.Pdf pages are 1‑based.
            LinkAnnotation linkAnnot = (LinkAnnotation)doc.Pages[1].Annotations[1];

            // Modify the link: change its action to a web address.
            linkAnnot.Action = new GoToURIAction("www.aspose.com");

            // Output PDF file.
            string outputPath = Path.Combine(outputDir, "SetDestinationLink_out.pdf");

            // Save the document with the updated link.
            doc.Save(outputPath);

            Console.WriteLine("\nDestination link setup successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}