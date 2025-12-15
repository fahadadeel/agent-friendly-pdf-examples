using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Links_Actions;

/// <summary>
/// Demonstrates extracting links from a PDF document using Aspose.Pdf.
/// </summary>
public class ExtractLinks
{
    /// <summary>
    /// Runs the example.
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "ExtractLinks.pdf");
            string outputPath = Path.Combine(outputDir, "ExtractLinks_out.pdf");

            // Open the PDF document.
            Document document = new Document(inputPath);

            // Extract actions (links) from the first page.
            Page page = document.Pages[1];
            AnnotationSelector selector = new AnnotationSelector(new LinkAnnotation(page, Aspose.Pdf.Rectangle.Trivial));
            page.Accept(selector);
            IList<Annotation> list = selector.Selected;

            // Access the first annotation (if any) to mimic original behavior.
            if (list != null && list.Count > 0)
            {
                Annotation annotation = (Annotation)list[0];
                // The original example does not modify the annotation; this line is kept for parity.
                _ = annotation;
            }

            // Save the updated document.
            document.Save(outputPath);

            Console.WriteLine("\nLinks extracted successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while extracting links: " + ex.Message);
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.