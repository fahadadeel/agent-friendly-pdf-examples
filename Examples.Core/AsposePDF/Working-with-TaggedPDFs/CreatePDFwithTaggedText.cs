using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using Aspose.Pdf.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

/// <summary>
/// Demonstrates how to create a PDF document with tagged text using Aspose.Pdf.
/// </summary>
public class CreatePDFWithTaggedText
{
    /// <summary>
    /// Creates a PDF document containing tagged text elements and saves it to the output folder.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directory (the folder where the application is running).
            string baseDir = AppContext.BaseDirectory;

            // Define output directory and ensure it exists.
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Define the full path for the generated PDF.
            string outputPath = Path.Combine(outputDir, "PDFwithTaggedText.pdf");

            // Create a new PDF document.
            Document document = new Document();

            // Get the tagged content interface for the document.
            ITaggedContent taggedContent = document.TaggedContent;

            // Set title and language for the document.
            taggedContent.SetTitle("Tagged Pdf Document");
            taggedContent.SetLanguage("en-US");

            // Create a header element.
            HeaderElement headerElement = taggedContent.CreateHeaderElement();
            headerElement.ActualText = "Heading 1";

            // Create several paragraph elements.
            ParagraphElement paragraphElement1 = taggedContent.CreateParagraphElement();
            paragraphElement1.ActualText = "test1";

            ParagraphElement paragraphElement2 = taggedContent.CreateParagraphElement();
            paragraphElement2.ActualText = "test 2";

            ParagraphElement paragraphElement3 = taggedContent.CreateParagraphElement();
            paragraphElement3.ActualText = "test 3";

            ParagraphElement paragraphElement4 = taggedContent.CreateParagraphElement();
            paragraphElement4.ActualText = "test 4";

            ParagraphElement paragraphElement5 = taggedContent.CreateParagraphElement();
            paragraphElement5.ActualText = "test 5";

            ParagraphElement paragraphElement6 = taggedContent.CreateParagraphElement();
            paragraphElement6.ActualText = "test 6";

            ParagraphElement paragraphElement7 = taggedContent.CreateParagraphElement();
            paragraphElement7.ActualText = "test 7";

            // Save the PDF document to the specified output path.
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error creating tagged PDF: {ex.Message}");
        }
    }
}