using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Security_Signatures;

/// <summary>
/// Demonstrates encrypting a PDF document using Aspose.Pdf.
/// </summary>
public class Encrypt
{
    /// <summary>
    /// Encrypts the input PDF and saves the encrypted version.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "Encrypt.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "Encrypt_out.pdf");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Open the document.
            Document document = new Document(inputPath);

            // Encrypt PDF.
            document.Encrypt("user", "owner", 0, CryptoAlgorithm.RC4x128);

            // Save the updated PDF.
            document.Save(outputPath);

            Console.WriteLine($"\nPDF file encrypted successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during PDF encryption: {ex.Message}");
        }
    }
}