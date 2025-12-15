using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Operators;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates how to remove all text from a PDF document using Aspose.Pdf.
/// </summary>
public class RemoveAllText
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
            Directory.CreateDirectory(outputDir);

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "RemoveAllText.pdf");
            string outputPath = Path.Combine(outputDir, "RemoveAllText_out.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Loop through all pages of the PDF document.
            for (int i = 1; i <= pdfDocument.Pages.Count; i++)
            {
                Page page = pdfDocument.Pages[i];
                OperatorSelector operatorSelector = new OperatorSelector(new TextShowOperator());

                // Select all text on the page.
                page.Contents.Accept(operatorSelector);

                // Delete all selected text.
                page.Contents.Delete(operatorSelector.Selected);
            }

            // Save the modified document.
            pdfDocument.Save(outputPath, SaveFormat.Pdf);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in RemoveAllText example: {ex.Message}");
        }
    }
}