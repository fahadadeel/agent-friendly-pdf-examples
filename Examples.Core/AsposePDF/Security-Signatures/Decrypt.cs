using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Security_Signatures;

/// <summary>
/// Demonstrates decrypting a password‑protected PDF using Aspose.Pdf.
/// </summary>
public class Decrypt
{
    /// <summary>
    /// Decrypts the PDF file located in <c>data/inputs/Decrypt.pdf</c> and saves the result to <c>data/outputs/Decrypt_out.pdf</c>.
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

            string inputPath = Path.Combine(inputDir, "Decrypt.pdf");
            string outputPath = Path.Combine(outputDir, "Decrypt_out.pdf");

            // Open the encrypted document using the known password.
            Document document = new Document(inputPath, "password");

            // Decrypt the PDF.
            document.Decrypt();

            // Save the decrypted PDF.
            document.Save(outputPath);

            Console.WriteLine($"\nPDF file decrypted successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF decryption: {ex.Message}");
        }
    }
}