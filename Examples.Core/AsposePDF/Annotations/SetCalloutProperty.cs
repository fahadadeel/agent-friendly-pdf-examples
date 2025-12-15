using System;
using System.IO;
using System.Text;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Annotations;

/// <summary>
/// Demonstrates setting callout properties on a FreeText annotation using Aspose.Pdf.
/// </summary>
class SetCalloutProperty
{
    /// <summary>
    /// This feature is supported by version 19.6 or greater.
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

            // Create a new PDF document.
            Document doc = new Document();
            Page page = doc.Pages.Add();

            // Set default appearance for the annotation.
            DefaultAppearance da = new DefaultAppearance
            {
                // TODO: Verify System.Drawing.Color usage on non‑Windows platforms.
                TextColor = System.Drawing.Color.Red,
                FontSize = 10
            };

            // Create a FreeText annotation with callout.
            FreeTextAnnotation fta = new FreeTextAnnotation(
                page,
                new Rectangle(422.25, 645.75, 583.5, 702.75),
                da)
            {
                Intent = FreeTextIntent.FreeTextCallout,
                EndingStyle = LineEnding.OpenArrow,
                Callout = new Point[]
                {
                    new Point(428.25, 651.75),
                    new Point(462.75, 681.375),
                    new Point(474, 681.375)
                },
                RichText = "<body xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:xfa=\"http://www.xfa.org/schema/xfa-data/1.0/\" xfa:APIVersion=\"Acrobat:11.0.23\" xfa:spec=\"2.0.2\"  style=\"color:#FF0000;font-weight:normal;font-style:normal;font-stretch:normal\"><p dir=\"ltr\"><span style=\"font-size:9.0pt;font-family:Helvetica\">This is a sample</span></p></body>"
            };

            page.Annotations.Add(fta);

            // Save the document to the output directory.
            string outputPath = Path.Combine(outputDir, "SetCalloutProperty.pdf");
            doc.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in Run: {ex.Message}");
        }
    }

    /// <summary>
    /// This feature is supported by version 19.6 or greater.
    /// If you use import from XFDF file please use callout-line name instead just "callout".
    /// </summary>
    public static void SetCalloutPropertyXFDF()
    {
        try
        {
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Load existing PDF from inputs.
            string inputPdfPath = Path.Combine(inputDir, "AddAnnotation.pdf");
            Document pdfDocument = new Document(inputPdfPath);

            // Build XFDF content.
            StringBuilder xfdf = new StringBuilder();
            xfdf.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?><xfdf xmlns=\"http://ns.adobe.com/xfdf/\" xml:space=\"preserve\"><annots>");
            CreateXfdf(ref xfdf);
            xfdf.AppendLine("</annots></xfdf>");

            // Import annotations from XFDF.
            using var xfdfStream = new MemoryStream(Encoding.UTF8.GetBytes(xfdf.ToString()));
            pdfDocument.ImportAnnotationsFromXfdf(xfdfStream);

            // Save the modified PDF.
            string outputPath = Path.Combine(outputDir, "SetCalloutPropertyXFDF.pdf");
            pdfDocument.Save(outputPath);
            Console.WriteLine($"XFDF-imported PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SetCalloutPropertyXFDF: {ex.Message}");
        }
    }

    /// <summary>
    /// Creates XFDF content for a FreeText annotation.
    /// </summary>
    /// <param name="pXfdf">StringBuilder to append XFDF XML.</param>
    static void CreateXfdf(ref StringBuilder pXfdf)
    {
        pXfdf.Append("<freetext");
        pXfdf.Append(" page=\"0\"");
        pXfdf.Append(" rect=\"422.25,645.75,583.5,702.75\"");
        pXfdf.Append(" intent=\"FreeTextCallout\"");
        pXfdf.Append(" callout-line=\"428.25,651.75,462.75,681.375,474,681.375\"");
        pXfdf.Append(" tail=\"OpenArrow\"");
        pXfdf.AppendLine(">");
        pXfdf.Append("<contents-richtext><body ");
        pXfdf.Append(" style=\"font-size:10.0pt;text-align:left;color:#FF0000;font-weight:normal;font-style:normal;font-family:Helvetica;font-stretch:normal\">");
        pXfdf.Append("<p dir=\"ltr\">This is a sample</p>");
        pXfdf.Append("</body></contents-richtext>");
        pXfdf.AppendLine("<defaultappearance>/Helv 12 Tf 1 0 0 rg</defaultappearance>");
        pXfdf.AppendLine("</freetext>");
    }
}