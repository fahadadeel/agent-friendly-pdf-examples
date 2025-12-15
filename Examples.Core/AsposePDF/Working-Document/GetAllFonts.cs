using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

/// <summary>
/// Demonstrates retrieving all fonts used in a PDF document.
/// </summary>
namespace Examples.Core.AsposePDF.WorkingDocument;

public class GetAllFonts
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input PDF path relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the document.
            Document doc = new Document(inputPath);

            // Get all fonts used in the document.
            Font[] fonts = doc.FontUtilities.GetAllFonts();

            foreach (Font font in fonts)
            {
                Console.WriteLine(font.FontName);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing GetAllFonts: {ex.Message}");
        }
    }
}