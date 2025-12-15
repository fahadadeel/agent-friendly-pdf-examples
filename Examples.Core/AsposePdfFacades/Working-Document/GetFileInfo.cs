using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.WorkingDocument;

/// <summary>
/// Demonstrates retrieving PDF file information using Aspose.Pdf.Facades.
/// </summary>
public class GetFileInfo
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input file path.
            string inputPath = Path.Combine(AppContext.BaseDirectory, "data", "inputs", "GetFileInfo.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (required by specification).
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Open document info.
            PdfFileInfo fileInfo = new PdfFileInfo(inputPath);

            // Display PDF information.
            Console.WriteLine("Subject: {0}", fileInfo.Subject);
            Console.WriteLine("Title: {0}", fileInfo.Title);
            Console.WriteLine("Keywords: {0}", fileInfo.Keywords);
            Console.WriteLine("Creator: {0}", fileInfo.Creator);
            Console.WriteLine("Creation Date: {0}", fileInfo.CreationDate);
            Console.WriteLine("Modification Date: {0}", fileInfo.ModDate);
            Console.WriteLine("Is Valid PDF: {0}", fileInfo.IsPdfFile);
            Console.WriteLine("Is Encrypted: {0}", fileInfo.IsEncrypted);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing GetFileInfo example: {ex.Message}");
        }
    }
}