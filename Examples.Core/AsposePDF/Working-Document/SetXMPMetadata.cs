using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Working_Document;

/// <summary>
/// Demonstrates setting XMP metadata in a PDF document using Aspose.Pdf.
/// </summary>
public class SetXMPMetadata
{
    /// <summary>
    /// Sets basic XMP metadata and saves the resulting PDF.
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
            Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "SetXMPMetadata.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open document.
            Document pdfDocument = new Document(inputPath);

            // Set XMP metadata properties.
            pdfDocument.Metadata["xmp:CreateDate"] = DateTime.Now;
            pdfDocument.Metadata["xmp:Nickname"] = "Nickname";
            pdfDocument.Metadata["xmp:CustomProperty"] = "Custom Value";

            // Output PDF file.
            string outputPath = Path.Combine(outputDir, "SetXMPMetadata_out.pdf");

            // Save document.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nXMP metadata in a pdf file setup successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in SetXMPMetadata.Run: {ex.Message}");
        }
    }

    /// <summary>
    /// Registers a namespace prefix and sets additional XMP metadata, then saves the PDF.
    /// </summary>
    public static void SetPrefixMetadata()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "SetXMPMetadata.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open document.
            Document pdfDocument = new Document(inputPath);

            // Register namespace URI for the "xmp" prefix.
            pdfDocument.Metadata.RegisterNamespaceUri("xmp", "http://Ns.adobe.com/xap/1.0/");

            // Set additional XMP metadata.
            pdfDocument.Metadata["xmp:ModifyDate"] = DateTime.Now;

            // Output PDF file.
            string outputPath = Path.Combine(outputDir, "SetPrefixMetadata_out.pdf");

            // Save document.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"Prefix metadata set successfully. File saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in SetXMPMetadata.SetPrefixMetadata: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.