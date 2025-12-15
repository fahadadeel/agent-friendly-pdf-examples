using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;

namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

/// <summary>
/// Demonstrates creation of illustration (figure) structure elements in a tagged PDF using Aspose.Pdf.
/// </summary>
public class IllustrationStructureElements
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

            // Define paths for the source image and the resulting PDF.
            string imagePath = Path.Combine(inputDir, "image.jpg");
            string outputPath = Path.Combine(outputDir, "IllustrationStructureElements.pdf");

            // Create a new PDF document.
            Document document = new Document();

            // Access the tagged content interface.
            ITaggedContent taggedContent = document.TaggedContent;

            // Set document metadata.
            taggedContent.SetTitle("Tagged Pdf Document");
            taggedContent.SetLanguage("en-US");

            // Create an illustration (figure) element.
            IllustrationElement figure1 = taggedContent.CreateFigureElement();

            // Append the figure to the root element of the tagged PDF.
            taggedContent.RootElement.AppendChild(figure1);

            // Set properties of the figure.
            figure1.AlternativeText = "Figure One";
            figure1.Title = "Image 1";
            figure1.SetTag("Fig1");

            // Associate an image with the figure.
            // TODO: verify that SetImage(string) overload exists in the used Aspose.Pdf version.
            figure1.SetImage(imagePath);

            // Save the tagged PDF document.
            document.Save(outputPath);

            Console.WriteLine($"Tagged PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing IllustrationStructureElements example: {ex.Message}");
        }
    }
}