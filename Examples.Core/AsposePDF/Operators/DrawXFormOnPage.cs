using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Operators;

namespace Examples.Core.AsposePDF.Operators;

public class DrawXFormOnPage
{
    /// <summary>
    /// Demonstrates drawing an XForm on a PDF page using Aspose.Pdf operators.
    /// </summary>
    public static void Run()
    {
        // Resolve directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure output directory exists.
        Directory.CreateDirectory(outputDir);

        string imageFile = Path.Combine(inputDir, "aspose-logo.jpg");
        string inFile = Path.Combine(inputDir, "DrawXFormOnPage.pdf");
        string outFile = Path.Combine(outputDir, "blank-sample2_out.pdf");

        try
        {
            using Document doc = new Document(inFile);
            OperatorCollection pageContents = doc.Pages[1].Contents;

            // Wrap existing contents with GSave/GRestore operators pair
            pageContents.Insert(1, new GSave());
            pageContents.Add(new GRestore());

            // Add save graphics state operator to properly clear graphics state after new commands
            pageContents.Add(new GSave());

            // Create XForm
            XForm form = XForm.CreateNewForm(doc.Pages[1], doc);
            doc.Pages[1].Resources.Forms.Add(form);
            form.Contents.Add(new GSave());
            // Define image width and height
            form.Contents.Add(new ConcatenateMatrix(200, 0, 0, 200, 0, 0));

            // Load image into stream
            using Stream imageStream = new FileStream(imageFile, FileMode.Open, FileAccess.Read);
            // Add image to Images collection of the XForm Resources
            form.Resources.Images.Add(imageStream);
            XImage ximage = form.Resources.Images[form.Resources.Images.Count];
            // Draw image using Do operator
            form.Contents.Add(new Do(ximage.Name));
            form.Contents.Add(new GRestore());

            // Place form at different positions on the page
            pageContents.Add(new GSave());
            pageContents.Add(new ConcatenateMatrix(1, 0, 0, 1, 100, 500));
            pageContents.Add(new Do(form.Name));
            pageContents.Add(new GRestore());

            pageContents.Add(new GSave());
            pageContents.Add(new ConcatenateMatrix(1, 0, 0, 1, 100, 300));
            pageContents.Add(new Do(form.Name));
            pageContents.Add(new GRestore());

            // Restore graphics state
            pageContents.Add(new GRestore());

            doc.Save(outFile);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error processing PDF: {ex.Message}");
        }
    }
}