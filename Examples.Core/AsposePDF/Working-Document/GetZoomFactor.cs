using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.WorkingDocument;

/// <summary>
/// Demonstrates how to retrieve the zoom factor from a PDF document's open action.
/// </summary>
public class GetZoomFactor
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve the input PDF path (expects data/inputs/Zoomed_pdf.pdf relative to the application base directory).
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "Zoomed_pdf.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (required by the overall requirements, even though this example does not write output).
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Retrieve the open action (expected to be a GoToAction).
            GoToAction action = doc.OpenAction as GoToAction;
            if (action?.Destination is XYZExplicitDestination xyzDest)
            {
                // Output the zoom factor.
                Console.WriteLine(xyzDest.Zoom);
            }
            else
            {
                Console.Error.WriteLine("The document does not contain a GoToAction with an XYZExplicitDestination.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.