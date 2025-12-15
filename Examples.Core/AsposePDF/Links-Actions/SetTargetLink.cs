using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Links_Actions;

/// <summary>
/// Demonstrates how to set the target of a link annotation to a remote destination and file.
/// </summary>
public class SetTargetLink
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

            // Input PDF files.
            string inputPdfPath = Path.Combine(inputDir, "UpdateLinks.pdf");
            string inputFileSpecPath = Path.Combine(inputDir, "input.pdf");

            // Output PDF file.
            string outputPdfPath = Path.Combine(outputDir, "SetTargetLink_out.pdf");

            // Load the PDF document.
            Document document = new Document(inputPdfPath);

            // Retrieve the link annotation (page 1, annotation 1 – 1‑based indexing).
            LinkAnnotation linkAnnot = (LinkAnnotation)document.Pages[1].Annotations[1];

            // Cast the action to GoToRemoteAction.
            GoToRemoteAction goToR = (GoToRemoteAction)linkAnnot.Action;

            // Update the destination (page 2, coordinates 0,0, zoom 1.5).
            goToR.Destination = new XYZExplicitDestination(2, 0, 0, 1.5);

            // Update the file reference.
            goToR.File = new FileSpecification(inputFileSpecPath);

            // Save the modified document.
            document.Save(outputPdfPath);

            Console.WriteLine("\nTarget link setup successfully.\nFile saved at " + outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}