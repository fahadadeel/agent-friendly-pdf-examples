using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

/// <summary>
/// Demonstrates adding extensible XMP metadata to a PDF using Aspose.Pdf.Facades.
/// </summary>
public class ExtensibleMetadataPlatform
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // ExStart:ExtensibleMetadataPlatform
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "FilledForm.pdf");
            string outputPath = Path.Combine(outputDir, "xmp_out.pdf");

            // Create an object of PdfXmpMetadata class
            var xmpMetaData = new PdfXmpMetadata();

            // Open input and output streams
            using var input = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using var output = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            // Set input file stream
            xmpMetaData.BindPdf(input);

            // Add base URL property to xmp metadata
            xmpMetaData.Add(DefaultMetadataProperties.BaseURL, "xmlns:pdf=http:// Ns.adobe.com/pdf/1.3/");

            // Add creation date property to xmp metadata
            xmpMetaData.Add(DefaultMetadataProperties.CreateDate, DateTime.Now.ToString());

            // Add Metadata Date property to xmp metadata
            xmpMetaData.Add(DefaultMetadataProperties.MetadataDate, DateTime.Now.ToString());

            // Add Creator Tool property to xmp metadata
            xmpMetaData.Add(DefaultMetadataProperties.CreatorTool, "Creator Tool Name");

            // Add Modify Date to xmp metadata
            xmpMetaData.Add(DefaultMetadataProperties.ModifyDate, DateTime.Now.ToString());

            // Add Nick Name to xmp metadata
            xmpMetaData.Add(DefaultMetadataProperties.Nickname, "Test");

            // Save xmp meta data in the pdf file
            xmpMetaData.Save(output);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in ExtensibleMetadataPlatform: {ex.Message}");
        }
        // ExEnd:ExtensibleMetadataPlatform
    }
}