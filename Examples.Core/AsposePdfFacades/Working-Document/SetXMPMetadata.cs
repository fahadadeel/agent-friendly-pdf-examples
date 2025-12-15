using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.WorkingDocument;

public class SetXMPMetadata
{
    /// <summary>
    /// Demonstrates how to set XMP metadata in a PDF document using Aspose.Pdf.Facades.
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

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "SetXMPMetadata.pdf");
            string outputPath = Path.Combine(outputDir, "SetXMPMetadata_out.pdf");

            // Create PdfXmpMetadata object.
            PdfXmpMetadata xmpMetaData = new PdfXmpMetadata();

            // Bind the PDF file to the object.
            xmpMetaData.BindPdf(inputPath);

            // Add create date.
            xmpMetaData.Add(DefaultMetadataProperties.CreateDate, DateTime.Now.ToString());

            // Change metadata date.
            xmpMetaData[DefaultMetadataProperties.MetadataDate] = DateTime.Now.ToString();

            // Add creator tool.
            xmpMetaData.Add(DefaultMetadataProperties.CreatorTool, "Creator tool name");

            // Remove modify date.
            xmpMetaData.Remove(DefaultMetadataProperties.ModifyDate);

            // Add user defined property.
            // Step #1: register namespace prefix and URI.
            xmpMetaData.RegisterNamespaceURI("customNamespace", "http://www.customNameSpaces.com/ns/");
            // Step #2: add user property with the prefix.
            xmpMetaData.Add("customNamespace:UserPropertyName", "UserPropertyValue");

            // Change user defined property.
            xmpMetaData["customNamespace:UserPropertyName"] = "UserPropertyValue2";

            // Save XMP metadata back into the PDF file.
            xmpMetaData.Save(outputPath);

            // Close the object.
            xmpMetaData.Close();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SetXMPMetadata.Run: {ex.Message}");
        }
    }
}