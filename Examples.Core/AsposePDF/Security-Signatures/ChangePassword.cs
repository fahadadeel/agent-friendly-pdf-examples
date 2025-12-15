using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Security_Signatures;

/// <summary>
/// Demonstrates changing the password of a PDF document using Aspose.Pdf.
/// </summary>
public class ChangePassword
{
    /// <summary>
    /// Runs the password change example.
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

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "ChangePassword.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open document with the original owner password.
            Document document = new Document(inputPath, "owner");

            // Change passwords: old owner password, new user password, new owner password.
            document.ChangePasswords("owner", "newuser", "newowner");

            // Output PDF file.
            string outputPath = Path.Combine(outputDir, "ChangePassword_out.pdf");

            // Save updated PDF.
            document.Save(outputPath);

            Console.WriteLine($"\nPDF file password changed successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while changing PDF password: {ex.Message}");
        }
    }
}