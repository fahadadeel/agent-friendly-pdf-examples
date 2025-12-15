using System;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Demonstrates converting an image stream to a PDF document using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Images;

public class ConvertImageStreamToPDF
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure directories exist.
        Directory.CreateDirectory(inputDir);
        Directory.CreateDirectory(outputDir);

        // Define input and output file paths.
        string inputPath = Path.Combine(inputDir, "aspose.jpg");
        string outputPath = Path.Combine(outputDir, "ConvertMemoryStreamImageToPdf_out.pdf");

        try
        {
            // Instantiate a new PDF document.
            Document pdf1 = new Document();

            // Add a page to the document.
            Page sec = pdf1.Pages.Add();

            // Read the image file into a byte array.
            byte[] data;
            using (FileStream fs = File.OpenRead(inputPath))
            {
                data = new byte[fs.Length];
                int bytesRead = fs.Read(data, 0, data.Length);
                if (bytesRead != data.Length)
                {
                    Console.Error.WriteLine("Warning: Not all bytes were read from the image file.");
                }
            }

            // Create a memory stream from the image byte array.
            using (MemoryStream ms = new MemoryStream(data))
            {
                // Create an Aspose.Pdf.Image object and set its source stream.
                Aspose.Pdf.Image imageht = new Aspose.Pdf.Image
                {
                    ImageStream = ms
                };

                // Add the image to the page's paragraphs collection.
                sec.Paragraphs.Add(imageht);
            }

            // Save the PDF document to the output path.
            pdf1.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF conversion: {ex.Message}");
        }
    }
}