using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;
using System;
using System.IO;

namespace Examples.Core.AsposePDF.Annotations;

public class ExtractHighlightedText
{
    /// <summary>
    /// Extracts and prints highlighted text from a PDF document.
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

            string inputPath = Path.Combine(inputDir, "ExtractHighlightedText.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Loop through all the annotations on the first page.
            foreach (Annotation annotation in doc.Pages[1].Annotations)
            {
                if (annotation is TextMarkupAnnotation textMarkup)
                {
                    // Retrieve highlighted text fragments.
                    TextFragmentCollection collection = textMarkup.GetMarkedTextFragments();
                    foreach (TextFragment tf in collection)
                    {
                        Console.WriteLine(tf.Text);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during ExtractHighlightedText.Run: {ex.Message}");
        }
    }
}