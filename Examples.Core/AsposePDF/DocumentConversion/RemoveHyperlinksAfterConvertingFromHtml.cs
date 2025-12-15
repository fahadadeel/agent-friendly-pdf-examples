using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.DocumentConversion;

public class RemoveHyperlinksAfterConvertingFromHtml
{
    /// <summary>
    /// Removes hyperlink annotations from a PDF generated from an HTML file and saves the result.
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

            string inputPath = Path.Combine(inputDir, "SampleHtmlFile.html");
            string outputPath = Path.Combine(outputDir, "RemoveHyperlinksFromText_out.pdf");

            // Load the HTML file into a PDF document.
            Document doc = new Document(inputPath, new HtmlLoadOptions());

            // Preserve original behavior of saving to a memory stream.
            using (var ms = new MemoryStream())
            {
                doc.Save(ms);
            }

            // Iterate over annotations on the first page and remove hyperlink actions.
            foreach (Annotation a in doc.Pages[1].Annotations)
            {
                if (a.AnnotationType == AnnotationType.Link)
                {
                    // If needed, handle specific hyperlink actions here.
                    // The original code referenced Aspose.Pdf.Interactive.Actions.GoToURIAction,
                    // which is not available in the current Aspose.Pdf version.
                    // TODO: Implement action-specific handling if required.

                    // Delete the annotation from its page.
                    doc.Pages[a.PageIndex].Annotations.Delete(a);
                }
            }

            // Save the modified document.
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in RemoveHyperlinksAfterConvertingFromHtml.Run: {ex.Message}");
        }
    }
}