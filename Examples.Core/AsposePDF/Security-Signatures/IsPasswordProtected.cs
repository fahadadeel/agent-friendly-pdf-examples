using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.Security_Signatures;

public class IsPasswordProtected
{
    /// <summary>
    /// Checks whether a PDF file is password protected and writes the result to the console.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input PDF path relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string inputPath = Path.Combine(inputDir, "IsPasswordProtected.pdf");

            // Ensure the input directory exists.
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Input directory does not exist: {inputDir}");
                return;
            }

            // Load the source PDF document information.
            PdfFileInfo fileInfo = new PdfFileInfo(inputPath);

            // Determine whether the source PDF file is encrypted with a password.
            bool encrypted = fileInfo.IsEncrypted;

            // Output the encryption status.
            Console.WriteLine(encrypted.ToString());

            // Ensure output directory exists (even though this example does not write output).
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while checking PDF encryption: {ex.Message}");
        }
    }
}