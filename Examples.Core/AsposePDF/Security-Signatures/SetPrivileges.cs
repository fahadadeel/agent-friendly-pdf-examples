using System;
using System.IO;
using Aspose.Pdf.Facades;
using Aspose.Pdf;

/// <summary>
/// Demonstrates setting PDF privileges using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.SecuritySignatures;

public class SetPrivileges
{
    /// <summary>
    /// Executes the privilege setting example.
    /// </summary>
    public static void Run()
    {
        // ExStart:SetPrivileges
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "SetPrivileges_out.pdf");

            // Load a source PDF file.
            using Document document = new Document(inputPath);
            // Instantiate Document Privileges object and apply restrictions on all privileges.
            DocumentPrivilege documentPrivilege = DocumentPrivilege.ForbidAll;
            // Only allow screen reading.
            documentPrivilege.AllowScreenReaders = true;
            // Encrypt the file with User and Owner password.
            document.Encrypt("user", "owner", documentPrivilege, CryptoAlgorithm.AESx128, false);
            // Save updated document.
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SetPrivileges.Run: {ex.Message}");
        }
        // ExEnd:SetPrivileges
    }
}