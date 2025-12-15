using System;
using System.IO;
using System.Linq;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates flattening form fields in a PDF document using Aspose.Pdf.
/// </summary>
public class FlattenForms
{
    /// <summary>
    /// Flattens all form fields in the input PDF and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine base directory (directory of the executing assembly)
            string baseDir = AppContext.BaseDirectory;

            // Input and output directories
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Input PDF path
            string inputPath = Path.Combine(inputDir, "input.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load source PDF form
            Document doc = new Document(inputPath);

            // Flatten Forms
            if ((doc.Form?.Fields?.Count() ?? 0) > 0)
            {
                // doc.Form and doc.Form.Fields are guaranteed non‑null here
                foreach (var field in doc.Form!.Fields)
                {
                    field.Flatten();
                }
            }

            // Output PDF path
            string outputPath = Path.Combine(outputDir, "FlattenForms_out.pdf");

            // Save the updated document
            doc.Save(outputPath);

            Console.WriteLine($"\nForms flattened successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while flattening forms: {ex.Message}");
        }
    }
}