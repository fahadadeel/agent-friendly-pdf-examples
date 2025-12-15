using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Working_Document;

/// <summary>
/// Demonstrates how to set a zoom factor for a PDF document using Aspose.Pdf.
/// </summary>
public class SetZoomFactor
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
            Directory.CreateDirectory(outputDir);

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "SetZoomFactor.pdf");
            string outputPath = Path.Combine(outputDir, "Zoomed_pdf_out.pdf");

            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Set the zoom factor using an OpenAction.
            GoToAction action = new GoToAction(new XYZExplicitDestination(1, 0, 0, .5));
            doc.OpenAction = action;

            // Save the modified document.
            doc.Save(outputPath);

            Console.WriteLine("\nZoom factor setup successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error during SetZoomFactor example: " + ex.Message);
        }
    }
}