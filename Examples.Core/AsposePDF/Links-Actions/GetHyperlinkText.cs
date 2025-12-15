using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using System.Collections;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Links_Actions;

public class GetHyperlinkText
{
    /// <summary>
    /// Extracts hyperlink URLs and associated text from a PDF document.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Path to the PDF file.
            string inputPath = Path.Combine(inputDir, "input.pdf");

            // Load the PDF file.
            Document document = new Document(inputPath);

            // Iterate through each page of PDF.
            foreach (Page page in document.Pages)
            {
                ShowLinkAnnotations(page);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Shows link annotations on the specified page, printing their URI and the text covered by the link.
    /// </summary>
    /// <param name="page">The PDF page to inspect.</param>
    public static void ShowLinkAnnotations(Page page)
    {
        foreach (Aspose.Pdf.Annotations.Annotation annot in page.Annotations)
        {
            if (annot is LinkAnnotation linkAnnot)
            {
                // Attempt to retrieve the URI from the annotation's action.
                object uriAction = linkAnnot.Action; // TODO: Adjust type if needed
                string uri = null;
                if (uriAction != null)
                {
                    var prop = uriAction.GetType().GetProperty("URI");
                    if (prop != null)
                    {
                        uri = prop.GetValue(uriAction) as string;
                    }
                }
                Console.WriteLine("URI: " + (uri ?? "null"));

                // Extract the text within the rectangle of the annotation.
                TextAbsorber absorber = new TextAbsorber();
                absorber.TextSearchOptions.LimitToPageBounds = true;
                absorber.TextSearchOptions.Rectangle = annot.Rect;
                page.Accept(absorber);
                string extractedText = absorber.Text;

                // Print the text associated with hyperlink.
                Console.WriteLine(extractedText);
            }
        }
    }
}