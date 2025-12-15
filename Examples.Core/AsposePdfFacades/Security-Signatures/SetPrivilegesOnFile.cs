using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Security_Signatures;

/// <summary>
/// Demonstrates how to set document privileges on a PDF file using Aspose.Pdf.Facades.
/// </summary>
public class SetPrivilegesOnFile
{
    /// <summary>
    /// Executes the example.
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

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "SetPrivilegesOnFile_out.pdf");

            // Create DocumentPrivilege object with desired settings.
            DocumentPrivilege privilege = DocumentPrivilege.ForbidAll;
            privilege.ChangeAllowLevel = 1;
            privilege.AllowPrint = true;
            privilege.AllowCopy = true;

            // Create PdfFileSecurity object and bind the input PDF.
            PdfFileSecurity fileSecurity = new PdfFileSecurity();
            fileSecurity.BindPdf(inputPath);

            // Apply the privilege settings.
            fileSecurity.SetPrivilege(privilege);

            // Save the secured PDF to the output path.
            fileSecurity.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SetPrivilegesOnFile.Run: {ex.Message}");
        }
    }
}