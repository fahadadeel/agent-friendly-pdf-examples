using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Attachments;

/// <summary>
/// Demonstrates how to retrieve an individual attachment from a PDF document using Aspose.Pdf.
/// </summary>
public class GetIndividualAttachment
{
    /// <summary>
    /// Entry point for the example.
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
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Path to the source PDF file.
            string inputPath = Path.Combine(inputDir, "GetIndividualAttachment.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Get the particular embedded file (index 1 as in the original example).
            // Note: Aspose.Pdf collections are 1‑based.
            FileSpecification fileSpecification = pdfDocument.EmbeddedFiles[1];

            // Output file properties.
            Console.WriteLine("Name: {0}", fileSpecification.Name);
            Console.WriteLine("Description: {0}", fileSpecification.Description);
            Console.WriteLine("Mime Type: {0}", fileSpecification.MIMEType);

            // Check if parameter object contains the parameters.
            if (fileSpecification.Params != null)
            {
                Console.WriteLine("CheckSum: {0}", fileSpecification.Params.CheckSum);
                Console.WriteLine("Creation Date: {0}", fileSpecification.Params.CreationDate);
                Console.WriteLine("Modification Date: {0}", fileSpecification.Params.ModDate);
                Console.WriteLine("Size: {0}", fileSpecification.Params.Size);
            }

            // Read the attachment content.
            using Stream contentStream = fileSpecification.Contents;
            byte[] fileContent = new byte[contentStream.Length];
            int bytesRead = contentStream.Read(fileContent, 0, fileContent.Length);
            if (bytesRead != fileContent.Length)
            {
                Console.WriteLine("Warning: Expected to read {0} bytes but read {1} bytes.", fileContent.Length, bytesRead);
            }

            // Write the attachment to the output directory.
            string outputPath = Path.Combine(outputDir, "test_out.txt");
            File.WriteAllBytes(outputPath, fileContent);

            Console.WriteLine("Attachment saved to: {0}", outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: {0}", ex.Message);
        }
    }
}