using Aspose.Pdf;
using Aspose.Pdf.Devices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates how to create thumbnail images for each page of PDF files located in the
/// <c>data/inputs</c> directory and save them to <c>data/outputs</c>.
/// </summary>
public class CreateThumbnailImages
{
    /// <summary>
    /// Entry point for the example. Processes all PDF files in the input folder and generates
    /// JPEG thumbnails for each page.
    /// </summary>
    public static void Run()
    {
        // ExStart:CreateThumbnailImages
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory ?? Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs", "Thumbnails");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Retrieve names of all the PDF files in the input directory.
            string[] fileEntries = Directory.GetFiles(inputDir, "*.pdf");

            // Iterate through all the files.
            for (int counter = 0; counter < fileEntries.Length; counter++)
            {
                // Open document.
                Document pdfDocument = new Document(fileEntries[counter]);

                // Process each page.
                for (int pageCount = 1; pageCount <= pdfDocument.Pages.Count; pageCount++)
                {
                    string outputFileName = $"Thumbnail_{counter}_{pageCount}.jpg";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Create the thumbnail image.
                    using (FileStream imageStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        // Create Resolution object.
                        Resolution resolution = new Resolution(300);
                        // Adjust width/height as needed; using values from the legacy example.
                        JpegDevice jpegDevice = new JpegDevice(45, 59, resolution, 100);
                        // Convert a particular page and save the image to the stream.
                        jpegDevice.Process(pdfDocument.Pages[pageCount], imageStream);
                    }
                }
            }

            Console.WriteLine("PDF pages are converted to thumbnails successfully!");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while creating thumbnails: {ex.Message}");
        }
        // ExEnd:CreateThumbnailImages
    }
}