using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.WorkingDocument;

/// <summary>
/// Demonstrates adding page breaks to PDF documents using Aspose.Pdf.Facades.
/// </summary>
public class PageBreak
{
    /// <summary>
    /// Adds a page break to a PDF document and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "PageBreak_out.pdf");

            // Instantiate Document instances.
            Document doc = new Document(inputPath);
            Document dest = new Document();

            // Create PdfFileEditor object.
            PdfFileEditor fileEditor = new PdfFileEditor();

            // Add a page break at page 1, position 450.
            fileEditor.AddPageBreak(doc, dest, new PdfFileEditor.PageBreak[]
            {
                new PdfFileEditor.PageBreak(1, 450)
            });

            // Save resultant file.
            dest.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "\nThis example will only work if you apply a valid Aspose License. You can purchase a full license or get a 30‑day temporary license from http://www.aspose.com/purchase/default.aspx.");
        }
    }

    /// <summary>
    /// Adds a page break to a PDF document using source and destination file paths.
    /// </summary>
    public static void PageBreakWithDestPath()
    {
        try
        {
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "PageBreakWithDestPath_out.pdf");

            // Create PdfFileEditor object.
            PdfFileEditor fileEditor = new PdfFileEditor();

            // Add a page break using path overloads.
            fileEditor.AddPageBreak(inputPath, outputPath, new PdfFileEditor.PageBreak[]
            {
                new PdfFileEditor.PageBreak(1, 450)
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "\nThis example will only work if you apply a valid Aspose License. You can purchase a full license or get a 30‑day temporary license from http://www.aspose.com/purchase/default.aspx.");
        }
    }

    /// <summary>
    /// Adds a page break to a PDF document using streams for source and destination.
    /// </summary>
    public static void PageBreakWithStream()
    {
        try
        {
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "PageBreakWithStream_out.pdf");

            using Stream src = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using Stream dest = new FileStream(outputPath, FileMode.Create, FileAccess.ReadWrite);

            PdfFileEditor fileEditor = new PdfFileEditor();

            fileEditor.AddPageBreak(src, dest, new PdfFileEditor.PageBreak[]
            {
                new PdfFileEditor.PageBreak(1, 450)
            });
            // Streams are disposed by the using statements.
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "\nThis example will only work if you apply a valid Aspose License. You can purchase a full license or get a 30‑day temporary license from http://www.aspose.com/purchase/default.aspx.");
        }
    }
}