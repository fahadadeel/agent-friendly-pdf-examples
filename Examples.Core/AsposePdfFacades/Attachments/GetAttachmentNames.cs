using System;
using System.IO;
using System.Collections;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Attachments;

public class GetAttachmentNames
{
    /// <summary>
    /// Demonstrates how to retrieve attachment names from a PDF document using Aspose.Pdf.Facades.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input PDF path.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "GetAttachmentNames.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (required by requirements, though not used directly here).
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Open document using PdfExtractor.
            PdfExtractor pdfExtractor = new PdfExtractor();
            pdfExtractor.BindPdf(inputPath);

            // Extract attachments.
            pdfExtractor.ExtractAttachment();

            // Get attachment names.
            IList attachmentNames = (IList)pdfExtractor.GetAttachNames();

            foreach (string attachmentName in attachmentNames)
            {
                Console.WriteLine("Name : {0}", attachmentName);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during GetAttachmentNames execution: {ex.Message}");
        }
    }
}