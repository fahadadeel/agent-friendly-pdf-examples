using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.WorkingDocument;

/// <summary>
/// Demonstrates how to retrieve basic information from a PDF document using Aspose.Pdf.
/// </summary>
public class GetFileInfo
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

            // Ensure the output directory exists (even though this example does not write output files).
            Directory.CreateDirectory(outputDir);

            // Path to the PDF file.
            string pdfPath = Path.Combine(inputDir, "GetFileInfo.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(pdfPath);

            // Retrieve document information.
            DocumentInfo docInfo = pdfDocument.Info;

            // Display document information.
            Console.WriteLine("Author: {0}", docInfo.Author);
            Console.WriteLine("Creation Date: {0}", docInfo.CreationDate);
            Console.WriteLine("Keywords: {0}", docInfo.Keywords);
            Console.WriteLine("Modify Date: {0}", docInfo.ModDate);
            Console.WriteLine("Subject: {0}", docInfo.Subject);
            Console.WriteLine("Title: {0}", docInfo.Title);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while retrieving PDF information: {ex.Message}");
        }
    }
}