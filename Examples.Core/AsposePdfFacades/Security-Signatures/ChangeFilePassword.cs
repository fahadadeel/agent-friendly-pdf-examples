using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Security_Signatures;

/// <summary>
/// Demonstrates how to change the password of an existing PDF file using Aspose.Pdf.Facades.
/// </summary>
public class ChangeFilePassword
{
    /// <summary>
    /// Executes the password change operation.
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

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "ChangePassword.pdf");
            string outputPath = Path.Combine(outputDir, "ChangeFilePassword_out.pdf");

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create PdfFileSecurity object and bind the existing PDF.
            PdfFileSecurity fileSecurity = new PdfFileSecurity();
            fileSecurity.BindPdf(inputPath);

            // Change password: owner password, new user password, new owner password.
            fileSecurity.ChangePassword("owner", "newuserpassword", "newownerpassword");

            // Save the secured PDF to the output location.
            fileSecurity.Save(outputPath);

            Console.WriteLine($"Password changed successfully. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while changing the PDF password: {ex.Message}");
        }
    }
}