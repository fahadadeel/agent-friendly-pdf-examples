using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Links_Actions;

/// <summary>
/// Demonstrates how to retrieve hyperlink destinations from a PDF document.
/// </summary>
public class GetHyperlinkDestinations
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Path to the input PDF file.
            string inputPath = Path.Combine(inputDir, "input.pdf");

            // Load the PDF file.
            Document document = new Document(inputPath);

            // Traverse through all the pages of the PDF.
            foreach (Page page in document.Pages)
            {
                // Get the link annotations from the particular page.
                AnnotationSelector selector = new AnnotationSelector(
                    new LinkAnnotation(page, Aspose.Pdf.Rectangle.Trivial));

                page.Accept(selector);

                // Create list holding all the links.
                IList<Annotation> list = selector.Selected;

                // Iterate through individual items inside the list.
                foreach (LinkAnnotation a in list)
                {
                    // Print the destination URL.
                    if (a.Action is GoToURIAction uriAction)
                    {
                        Console.WriteLine("\nDestination: " + uriAction.URI + "\n");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.