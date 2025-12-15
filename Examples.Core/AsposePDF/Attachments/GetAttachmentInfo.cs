using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Attachments;

/// <summary>
/// Demonstrates retrieving attachment information from a PDF document using Aspose.Pdf.
/// </summary>
public class GetAttachmentInfo
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

            // Ensure directories exist.
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDir}");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Path to the PDF document containing the attachment.
            string pdfPath = Path.Combine(inputDir, "GetAttachmentInfo.pdf");

            if (!File.Exists(pdfPath))
            {
                Console.Error.WriteLine($"Input PDF not found: {pdfPath}");
                return;
            }

            // Open the PDF document.
            Document pdfDocument = new Document(pdfPath);

            // Get a particular embedded file (index 1 as in the original example).
            // Note: Aspose.Pdf collections are 1‑based.
            FileSpecification fileSpecification = pdfDocument.EmbeddedFiles[1];

            // Output the file properties.
            Console.WriteLine("Name: {0}", fileSpecification.Name);
            Console.WriteLine("Description: {0}", fileSpecification.Description);
            Console.WriteLine("Mime Type: {0}", fileSpecification.MIMEType);

            // Check if the parameter object contains additional parameters.
            if (fileSpecification.Params != null)
            {
                Console.WriteLine("CheckSum: {0}", fileSpecification.Params.CheckSum);
                Console.WriteLine("Creation Date: {0}", fileSpecification.Params.CreationDate);
                Console.WriteLine("Modification Date: {0}", fileSpecification.Params.ModDate);
                Console.WriteLine("Size: {0}", fileSpecification.Params.Size);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}