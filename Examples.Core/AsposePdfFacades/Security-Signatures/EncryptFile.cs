using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Security_Signatures;

/// <summary>
/// Demonstrates encrypting a PDF file using Aspose.Pdf.Facades.
/// </summary>
public class EncryptFile
{
    /// <summary>
    /// Executes the encryption example.
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

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "Encrypt.pdf");
            string outputPath = Path.Combine(outputDir, "Encrypt_out.pdf");

            // Validate input file existence.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create PdfFileSecurity object and bind the PDF.
            PdfFileSecurity fileSecurity = new PdfFileSecurity();
            fileSecurity.BindPdf(inputPath);

            // Encrypt file using 256-bit AES encryption.
            fileSecurity.EncryptFile(
                "user",                // user password
                "owner",               // owner password
                DocumentPrivilege.Print,
                KeySize.x256,
                Algorithm.AES);

            // Save the encrypted PDF.
            fileSecurity.Save(outputPath);

            Console.WriteLine($"Encrypted PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during PDF encryption: {ex.Message}");
        }
    }
}