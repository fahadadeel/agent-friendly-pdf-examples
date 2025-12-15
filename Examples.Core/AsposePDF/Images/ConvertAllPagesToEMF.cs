using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Devices;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates converting all pages of a PDF document to EMF images.
/// </summary>
public class ConvertAllPagesToEMF
{
    /// <summary>
    /// Executes the conversion.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input PDF file path.
            string pdfPath = Path.Combine(inputDir, "ConvertAllPagesToEMF.pdf");

            if (!File.Exists(pdfPath))
            {
                Console.WriteLine($"Input file not found: {pdfPath}");
                return;
            }

            // Open document
            Document pdfDocument = new Document(pdfPath);

            for (int pageCount = 1; pageCount <= pdfDocument.Pages.Count; pageCount++)
            {
                string outputPath = Path.Combine(outputDir, $"image{pageCount}_out.emf");

                // Create Resolution object
                Resolution resolution = new Resolution(300);
                // Width, Height, Resolution
                using (FileStream imageStream = new FileStream(outputPath, FileMode.Create))
                {
                    EmfDevice emfDevice = new EmfDevice(500, 700, resolution);
                    // Convert a particular page and save the image to stream
                    emfDevice.Process(pdfDocument.Pages[pageCount], imageStream);
                }
            }

            Console.WriteLine("PDF pages are converted to EMF successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during PDF to EMF conversion: {ex.Message}");
        }
    }
}