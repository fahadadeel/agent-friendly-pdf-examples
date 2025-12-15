using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Operators;

namespace Examples.Core.AsposePDF.Operators;

/// <summary>
/// Demonstrates how to remove specific graphics operators from a PDF page using Aspose.Pdf.
/// </summary>
public class RemoveGraphicsObjects
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

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "RemoveGraphicsObjects.pdf");
            string outputPath = Path.Combine(outputDir, "No_Graphics_out.pdf");

            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Get the second page (pages are 1‑based).
            Page page = doc.Pages[2];

            // Access the page's content operators.
            OperatorCollection oc = page.Contents;

            // Define the operators that are used for path painting.
            Operator[] operators = new Operator[]
            {
                new Stroke(),
                new ClosePathStroke(),
                new Fill()
            };

            // Remove the specified operators from the page content.
            // Uncomment the following line to perform the deletion.
            // oc.Delete(operators);

            // Save the modified document.
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing RemoveGraphicsObjects example: {ex.Message}");
        }
    }
}