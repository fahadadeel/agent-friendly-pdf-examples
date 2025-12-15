using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using System;
using System.IO;

/// <summary>
/// Example demonstrating how to retrieve the resource (media) of a screen annotation.
/// </summary>
namespace Examples.Core.AsposePDF.Annotations;

public class GetResourceOfAnnotation
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
        string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        try
        {
            // Open the source PDF document.
            string sourcePdfPath = Path.Combine(inputDir, "AddAnnotation.pdf");
            Document doc = new Document(sourcePdfPath);

            // Create a screen annotation that references a SWF file.
            string swfPath = Path.Combine(inputDir, "AddSwfFileAsAnnotation.swf");
            ScreenAnnotation screenAnnotation = new ScreenAnnotation(
                doc.Pages[1],
                new Rectangle(100, 400, 300, 600),
                swfPath);

            // Add the annotation to the first page.
            doc.Pages[1].Annotations.Add(screenAnnotation);

            // Save the modified document.
            string outputPdfPath = Path.Combine(outputDir, "GetResourceOfAnnotation_Out.pdf");
            doc.Save(outputPdfPath);

            // Re-open the saved document to read the annotation's resource.
            Document doc1 = new Document(outputPdfPath);

            // Retrieve the screen annotation (index 1 because the first annotation is at index 0).
            ScreenAnnotation retrievedAnnotation = doc1.Pages[1].Annotations[1] as ScreenAnnotation;
            if (retrievedAnnotation == null)
            {
                Console.WriteLine("Screen annotation not found.");
                return;
            }

            // Get the RenditionAction associated with the annotation.
            RenditionAction action = retrievedAnnotation.Action as RenditionAction;
            if (action == null)
            {
                Console.WriteLine("RenditionAction not found.");
                return;
            }

            // Get the Rendition object.
            Rendition rendition = action.Rendition;
            if (rendition == null)
            {
                Console.WriteLine("Rendition not found.");
                return;
            }

            // Extract the MediaClip from the rendition.
            MediaClip mediaClip = (rendition as MediaRendition)?.MediaClip;
            if (mediaClip == null)
            {
                Console.WriteLine("MediaClip not found.");
                return;
            }

            // Obtain the FileSpecification that holds the actual media data.
            FileSpecification fileSpec = (mediaClip as MediaClipData)?.Data;
            if (fileSpec == null || fileSpec.Contents == null)
            {
                Console.WriteLine("Media data not found.");
                return;
            }

            // Read the media contents into a memory stream.
            using MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[1024];
            int read;
            using Stream source = fileSpec.Contents;
            while ((read = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }

            // Output some information about the rendition.
            Console.WriteLine(rendition.Name);
            Console.WriteLine(action.RenditionOperation);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}