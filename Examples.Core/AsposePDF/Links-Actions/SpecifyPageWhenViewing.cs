using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.LinksActions;

public class SpecifyPageWhenViewing
{
    /// <summary>
    /// Demonstrates how to set a document open action that navigates to a specific page with a defined zoom factor.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Define full paths for the input PDF and the output PDF.
            string inputPath = Path.Combine(inputDir, "SpecifyPageWhenViewing.pdf");
            string outputPath = Path.Combine(outputDir, "goto2page_out.pdf");

            // Load the PDF file.
            Document doc = new Document(inputPath);

            // Get the instance of the second page of the document.
            Page page2 = doc.Pages[2];

            // Set the zoom factor for the target page.
            double zoom = 1;

            // Create a GoToAction that points to the second page.
            GoToAction action = new GoToAction(doc.Pages[2]);

            // Define the destination with explicit XYZ coordinates.
            action.Destination = new XYZExplicitDestination(page2, 0, page2.Rect.Height, zoom);

            // Assign the action as the document's open action.
            doc.OpenAction = action;

            // Save the updated document.
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SpecifyPageWhenViewing.Run: {ex.Message}");
        }
    }
}