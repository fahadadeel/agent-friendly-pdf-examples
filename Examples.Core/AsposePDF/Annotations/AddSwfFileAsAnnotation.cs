using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Annotations;

/// <summary>
/// Demonstrates adding a SWF file as a screen annotation to a PDF document.
/// </summary>
public class AddSwfFileAsAnnotation
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

            // Ensure directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Input file paths.
            string inputPdfPath = Path.Combine(inputDir, "AddSwfFileAsAnnotation.pdf");
            string inputSwfPath = Path.Combine(inputDir, "input.swf");

            // Output file path.
            string outputPdfPath = Path.Combine(outputDir, "AddSwfFileAsAnnotation_out.pdf");

            // Open the PDF document.
            Document doc = new Document(inputPdfPath);

            // Get reference of the page to which you need to add the annotation.
            Page page = doc.Pages[1];

            // Create ScreenAnnotation object with .swf multimedia file as an argument.
            ScreenAnnotation annotation = new ScreenAnnotation(
                page,
                new Aspose.Pdf.Rectangle(0, 400, 600, 700),
                inputSwfPath);

            // Add the annotation to annotations collection of page.
            page.Annotations.Add(annotation);

            // Save the updated PDF document with annotation.
            doc.Save(outputPdfPath);

            Console.WriteLine("\nSWF file annotation added to pdf document.\nFile saved at " + outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddSwfFileAsAnnotation.Run: {ex.Message}");
        }
    }
}