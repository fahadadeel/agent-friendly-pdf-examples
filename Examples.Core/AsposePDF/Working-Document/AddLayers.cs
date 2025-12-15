using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Operators;

namespace Examples.Core.AsposePDF.WorkingDocument;

/// <summary>
/// Demonstrates how to add optional content groups (layers) to a PDF document using Aspose.Pdf.
/// </summary>
public class AddLayers
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
            Directory.CreateDirectory(outputDir);

            // The example does not require any input files, but the input directory is prepared for consistency.
            // string dataDir = inputDir; // Not used further.

            // Create a new PDF document.
            Document doc = new Document();

            // Add a page to the document.
            Page page = doc.Pages.Add();

            // Create and configure the first layer (Red Line).
            Layer layer = new Layer("oc1", "Red Line");
            layer.Contents.Add(new SetRGBColorStroke(1, 0, 0));
            layer.Contents.Add(new MoveTo(500, 700));
            layer.Contents.Add(new LineTo(400, 700));
            layer.Contents.Add(new Stroke());

            // Assign the layer collection to the page and add the layer.
            page.Layers = new List<Layer>();
            page.Layers.Add(layer);

            // Create and configure the second layer (Green Line).
            layer = new Layer("oc2", "Green Line");
            layer.Contents.Add(new SetRGBColorStroke(0, 1, 0));
            layer.Contents.Add(new MoveTo(500, 750));
            layer.Contents.Add(new LineTo(400, 750));
            layer.Contents.Add(new Stroke());
            page.Layers.Add(layer);

            // Create and configure the third layer (Blue Line).
            layer = new Layer("oc3", "Blue Line");
            layer.Contents.Add(new SetRGBColorStroke(0, 0, 1));
            layer.Contents.Add(new MoveTo(500, 800));
            layer.Contents.Add(new LineTo(400, 800));
            layer.Contents.Add(new Stroke());
            page.Layers.Add(layer);

            // Define the output file path.
            string outputPath = Path.Combine(outputDir, "AddLayers_out.pdf");

            // Save the document to the specified path.
            doc.Save(outputPath);

            Console.WriteLine($"\nLayers added successfully to PDF file.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while adding layers: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.