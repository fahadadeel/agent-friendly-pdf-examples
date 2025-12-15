using System;
using System.IO;
using System.Drawing;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.DocumentConversion.PDFToHTMLFormat;

/// <summary>
/// Demonstrates how to set output file dimensions when converting a PDF to HTML using Aspose.Pdf.
/// </summary>
public class SetOutputFileDimensions
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
                Directory.CreateDirectory(outputDir);

            // Path to the source PDF file.
            string inputPdfPath = Path.Combine(inputDir, "input.pdf");

            // Desired page size.
            float newPageWidth = 400f;
            float newPageHeight = 400f;

            // Initialize PdfPageEditor and bind the source PDF.
            PdfPageEditor pdfEditor = new PdfPageEditor();
            pdfEditor.BindPdf(inputPdfPath);

            // Set the new page dimensions.
            pdfEditor.PageSize = new PageSize(newPageWidth, newPageHeight);
            pdfEditor.VerticalAlignmentType = VerticalAlignment.Center;
            pdfEditor.HorizontalAlignment = HorizontalAlignment.Center;

            // Calculate zoom to fit content within the new dimensions.
            // Math.Min returns double, so cast the result to float.
            float zoom = (float)Math.Min(
                newPageWidth / (float)pdfEditor.Document.Pages[1].Rect.Width,
                newPageHeight / (float)pdfEditor.Document.Pages[1].Rect.Height);
            pdfEditor.Zoom = zoom;

            // Save the edited PDF to a memory stream.
            using var outputStream = new MemoryStream();
            pdfEditor.Save(outputStream);

            // Reset stream position before loading it into a Document.
            outputStream.Position = 0;

            // Load the edited PDF from the stream.
            Document exportDoc = new Document(outputStream);

            // Configure HTML save options.
            HtmlSaveOptions htmlOptions = new HtmlSaveOptions();

            // Set page border style (optional).
            SaveOptions.BorderPartStyle borderStyle = new SaveOptions.BorderPartStyle
            {
                LineType = SaveOptions.HtmlBorderLineType.Dotted,
                Color = System.Drawing.Color.Gray // Resolve ambiguity between System.Drawing.Color and Aspose.Pdf.Color
            };
            htmlOptions.PageBorderIfAny = new SaveOptions.BorderInfo(borderStyle);

            // Save the document as HTML.
            string outputHtmlPath = Path.Combine(outputDir, "SetOutputFileDimensions_out.html");
            exportDoc.Save(outputHtmlPath, htmlOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}