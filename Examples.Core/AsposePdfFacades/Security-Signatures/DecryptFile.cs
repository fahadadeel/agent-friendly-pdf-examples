using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.SecuritySignatures;

/// <summary>
/// Demonstrates how to decrypt a password‑protected PDF file using Aspose.Pdf.Facades.
/// </summary>
public class DecryptFile
{
    /// <summary>
    /// Executes the decryption example.
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

            // Define full paths for the source PDF and the decrypted output PDF.
            string inputPath = Path.Combine(inputDir, "Decrypt.pdf");
            string outputPath = Path.Combine(outputDir, "DecryptFile_out.pdf");

            // Create PdfFileSecurity object and bind the encrypted PDF.
            PdfFileSecurity fileSecurity = new PdfFileSecurity();
            fileSecurity.BindPdf(inputPath);

            // Decrypt the PDF using the owner password.
            fileSecurity.DecryptFile("owner");

            // Save the decrypted PDF.
            fileSecurity.Save(outputPath);

            Console.WriteLine($"Decrypted PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while decrypting the PDF: {ex.Message}");
        }
    }
}