using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Attachments;

public class GetAllTheAttachments
{
    /// <summary>
    /// Retrieves all attachments from a PDF document and writes them to the output directory.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // The PDF file name used in the original example.
        const string pdfFileName = "GetAlltheAttachments.pdf";

        // Build full paths.
        string inputPath = Path.Combine(inputDir, pdfFileName);

        try
        {
            // Open document
            Document pdfDocument = new Document(inputPath);

            // Get embedded files collection
            EmbeddedFileCollection embeddedFiles = pdfDocument.EmbeddedFiles;

            // Get count of the embedded files
            Console.WriteLine("Total files : {0}", embeddedFiles.Count);

            int count = 1;

            // Loop through the collection to get all the attachments
            foreach (FileSpecification fileSpecification in embeddedFiles)
            {
                Console.WriteLine("Name: {0}", fileSpecification.Name);
                Console.WriteLine("Description: {0}", fileSpecification.Description);
                Console.WriteLine("Mime Type: {0}", fileSpecification.MIMEType);

                // Check if parameter object contains the parameters
                if (fileSpecification.Params != null)
                {
                    Console.WriteLine("CheckSum: {0}", fileSpecification.Params.CheckSum);
                    Console.WriteLine("Creation Date: {0}", fileSpecification.Params.CreationDate);
                    Console.WriteLine("Modification Date: {0}", fileSpecification.Params.ModDate);
                    Console.WriteLine("Size: {0}", fileSpecification.Params.Size);
                }

                // Get the attachment content and write to a file in the output directory
                using Stream contentStream = fileSpecification.Contents;
                byte[] fileContent = new byte[contentStream.Length];
                int bytesRead = contentStream.Read(fileContent, 0, fileContent.Length);
                if (bytesRead != fileContent.Length)
                {
                    Console.WriteLine("Warning: Expected to read {0} bytes but read {1} bytes.", fileContent.Length, bytesRead);
                }

                string outputFilePath = Path.Combine(outputDir, $"{count}_out.txt");
                using FileStream fileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);
                fileStream.Write(fileContent, 0, fileContent.Length);

                count++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing PDF attachments: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.