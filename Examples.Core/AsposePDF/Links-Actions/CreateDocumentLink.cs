using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Links_Actions;

public class CreateDocumentLink
{
    /// <summary>
    /// Creates a document link annotation and saves the modified PDF.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve directories
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Input and output file paths
            string inputPath = Path.Combine(inputDir, "CreateDocumentLink.pdf");
            string remotePath = Path.Combine(inputDir, "RemoveOpenAction.pdf");
            string outputPath = Path.Combine(outputDir, "CreateDocumentLink_out.pdf");

            // Open document
            Document document = new Document(inputPath);

            // Create link annotation on first page
            Page page = document.Pages[1];
            var rect = new Aspose.Pdf.Rectangle(100, 100, 300, 300);
            LinkAnnotation link = new LinkAnnotation(page, rect);
            link.Color = Aspose.Pdf.Color.FromRgb(0, 255, 0); // Green
            link.Action = new GoToRemoteAction(remotePath, 1);
            page.Annotations.Add(link);

            // Save updated document
            document.Save(outputPath);

            Console.WriteLine("\nDocument link created successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error creating document link: {ex.Message}");
        }
    }
}