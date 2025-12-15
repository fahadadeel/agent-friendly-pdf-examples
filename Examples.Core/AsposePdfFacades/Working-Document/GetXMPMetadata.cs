using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.WorkingDocument;

/// <summary>
/// Demonstrates how to read XMP metadata from a PDF document using Aspose.Pdf.Facades.
/// </summary>
public class GetXMPMetadata
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directory.
            string baseDir = AppContext.BaseDirectory;

            // Ensure output directory exists (data/outputs).
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Resolve input PDF path (data/inputs/input.pdf).
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create PdfXmpMetadata object.
            PdfXmpMetadata xmpMetaData = new PdfXmpMetadata();

            // Bind PDF file to the object.
            xmpMetaData.BindPdf(inputPath);

            // Get XMP Meta Data properties.
            Console.WriteLine(": {0}", xmpMetaData[DefaultMetadataProperties.CreateDate]?.ToString());
            Console.WriteLine(": {0}", xmpMetaData[DefaultMetadataProperties.MetadataDate]?.ToString());
            Console.WriteLine(": {0}", xmpMetaData[DefaultMetadataProperties.CreatorTool]?.ToString());
            Console.WriteLine(": {0}", xmpMetaData["customNamespace:UserPropertyName"]?.ToString());

            // Pause for console view (optional).
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}