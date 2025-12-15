using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.DocumentConversion;

public class ReplaceMissingFonts
{
    /// <summary>
    /// Demonstrates how to replace missing fonts during PDF conversion.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        string inputPath = Path.Combine(inputDir, "input.pdf");
        string outputPath = Path.Combine(outputDir, "newfile_out.pdf");
        string logPath = Path.Combine(outputDir, "log.xml");

        try
        {
            // Attempt to locate the original font; if missing, add a substitution.
            Aspose.Pdf.Text.Font originalFont = null;
            try
            {
                originalFont = FontRepository.FindFont("AgencyFB");
            }
            catch (Exception)
            {
                // Font is missing on destination machine; substitute with Arial.
                FontRepository.Substitutions.Add(new SimpleFontSubstitution("AgencyFB", "Arial"));
            }

            // Load the PDF document.
            var pdf = new Document(inputPath);

            // Convert the document, generating a conversion log.
            pdf.Convert(logPath, PdfFormat.PDF_A_1B, ConvertErrorAction.Delete);

            // Save the converted PDF.
            pdf.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during PDF processing: {ex.Message}");
        }
    }
}