using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Devices;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates converting a PDF page to an EMF image using Aspose.Pdf.
/// </summary>
public class PageToEMF
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

        // Input and output file paths.
        string inputPath = Path.Combine(inputDir, "PageToEMF.pdf");
        string outputPath = Path.Combine(outputDir, "image_out.emf");

        try
        {
            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Create the output stream for the EMF image.
            using (FileStream imageStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                // Create Resolution object (300 DPI).
                Resolution resolution = new Resolution(300);

                // Create EMF device with specified width, height, and resolution.
                // Width = 500, Height = 700 (units are points).
                EmfDevice emfDevice = new EmfDevice(500, 700, resolution);

                // Convert the first page and save the image to the stream.
                emfDevice.Process(pdfDocument.Pages[1], imageStream);
            }

            Console.WriteLine("PDF page is converted to EMF successfully!");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error converting PDF page to EMF: {ex.Message}");
        }
    }
}