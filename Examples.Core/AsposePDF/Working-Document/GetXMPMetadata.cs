using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.WorkingDocument;

/// <summary>
/// Demonstrates how to read XMP metadata from a PDF document using Aspose.Pdf.
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
            // Resolve the input directory relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            Directory.CreateDirectory(inputDir); // Ensure the directory exists.

            // Path to the PDF file.
            string inputPath = Path.Combine(inputDir, "GetXMPMetadata.pdf");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Output selected XMP metadata properties.
            Console.WriteLine(pdfDocument.Metadata["xmp:CreateDate"]);
            Console.WriteLine(pdfDocument.Metadata["xmp:Nickname"]);
            Console.WriteLine(pdfDocument.Metadata["xmp:CustomProperty"]);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while reading XMP metadata: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.