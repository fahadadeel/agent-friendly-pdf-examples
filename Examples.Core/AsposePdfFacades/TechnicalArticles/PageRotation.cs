using System;
using System.IO;
using System.Collections;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

/// <summary>
/// Demonstrates rotating PDF pages using Aspose.Pdf.Facades.PdfPageEditor.
/// </summary>
public class PageRotation
{
    /// <summary>
    /// Executes the page rotation example.
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

            // Create PdfPageEditor object.
            using var pEdit = new PdfPageEditor();

            // Rotate odd pages (page 1) at 180 degrees.
            string inFile1 = Path.Combine(inputDir, "inFile1.pdf");
            string outFile180 = Path.Combine(outputDir, "Aspose.Pdf.Facades_rotate_180_out.pdf");
            pEdit.BindPdf(inFile1);
            pEdit.ProcessPages = new int[] { 1 };
            pEdit.Rotation = 180;
            pEdit.Save(outFile180);

            // Rotate even pages (page 1) at 270 degrees.
            string inFile2 = Path.Combine(inputDir, "inFile2.pdf");
            string outFile270 = Path.Combine(outputDir, "Aspose.Pdf.Facades_rotate_270_out.pdf");
            pEdit.BindPdf(inFile2);
            pEdit.ProcessPages = new int[] { 1 };
            pEdit.Rotation = 270;
            pEdit.Save(outFile270);

            // Find at what degrees a page was rotated.
            string inFile = Path.Combine(inputDir, "inFile.pdf");
            pEdit.BindPdf(inFile);
            int degrees = pEdit.GetPageRotation(1);
            Console.WriteLine($"Page 1 rotation: {degrees} degrees");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PageRotation example: {ex.Message}");
        }
    }
}