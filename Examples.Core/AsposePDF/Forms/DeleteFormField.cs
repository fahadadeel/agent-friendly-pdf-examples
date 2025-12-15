using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates how to delete a specific form field from a PDF document using Aspose.Pdf.
/// </summary>
public class DeleteFormField
{
    /// <summary>
    /// Deletes the form field named "textbox1" from the input PDF and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "DeleteFormField.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "DeleteFormField_out.pdf");

            // Open document
            Document pdfDocument = new Document(inputPath);

            // Delete a particular field by name
            pdfDocument.Form.Delete("textbox1");

            // Save modified document
            pdfDocument.Save(outputPath);

            Console.WriteLine("\nParticular field deleted successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in DeleteFormField.Run: {ex.Message}");
        }
    }
}