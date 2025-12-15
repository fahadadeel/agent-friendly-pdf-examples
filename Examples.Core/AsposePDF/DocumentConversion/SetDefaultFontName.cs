using Aspose.Pdf;
using Aspose.Pdf.Devices;
using System;
using System.IO;

/// <summary>
/// Demonstrates how to set a default font name for PDF rendering using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.DocumentConversion;

public class SetDefaultFontName
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output paths relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        string inputPath = Path.Combine(inputDir, "input.pdf");
        string outputPath = Path.Combine(outputDir, "SetDefaultFontName.png");

        try
        {
            // Load the PDF document.
            using Document pdfDocument = new Document(inputPath);

            // Prepare the PNG device with desired resolution.
            Resolution resolution = new Resolution(300);
            // PngDevice does not implement IDisposable, so we instantiate it without a using statement.
            PngDevice pngDevice = new PngDevice(resolution);

            // Configure rendering options to use the specified default font.
            RenderingOptions renderingOptions = new RenderingOptions
            {
                DefaultFontName = "Arial"
            };
            pngDevice.RenderingOptions = renderingOptions;

            // Render the first page to a PNG file.
            using FileStream imageStream = new FileStream(outputPath, FileMode.Create);
            pngDevice.Process(pdfDocument.Pages[1], imageStream);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF conversion: {ex.Message}");
        }
    }
}