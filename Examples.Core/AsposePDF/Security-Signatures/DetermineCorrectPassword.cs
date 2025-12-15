using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.SecuritySignatures;

public class DetermineCorrectPassword
{
    /// <summary>
    /// Demonstrates how to determine the correct password for a protected PDF document.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Path to the source PDF file.
            string inputPath = Path.Combine(inputDir, "IsPasswordProtected.pdf");

            // Load source PDF file information.
            var info = new PdfFileInfo();
            info.BindPdf(inputPath);
            Console.WriteLine("File is password protected " + info.IsEncrypted);

            // Candidate passwords.
            string[] passwords = new string[5] { "test", "test1", "test2", "test3", "sample" };

            foreach (var password in passwords)
            {
                try
                {
                    // Attempt to open the document with the current password.
                    var doc = new Document(inputPath, password);
                    if (doc.Pages.Count > 0)
                    {
                        Console.WriteLine("Number of Page in document are = " + doc.Pages.Count);
                    }
                }
                catch (InvalidPasswordException)
                {
                    Console.WriteLine("Password = " + password + "  is not correct");
                }
                catch (Exception ex)
                {
                    // Catch any other unexpected exceptions for this password attempt.
                    Console.WriteLine($"An error occurred while trying password '{password}': {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            // General error handling for the whole operation.
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}