using System;
using System.Collections;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.ManipulatePageProperties;

/// <summary>
/// Demonstrates how to manipulate page properties such as position, rotation, and zoom using Aspose.Pdf.Facades.
/// </summary>
public class SetPageProperties
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

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        string inputPath = Path.Combine(inputDir, "input.pdf");
        string outputPath = Path.Combine(outputDir, "SetPageProperties_out.pdf");

        try
        {
            // Open document
            PdfPageEditor pageEditor = new PdfPageEditor();
            pageEditor.BindPdf(inputPath);

            // Set page properties
            // Move origin from (0,0)
            pageEditor.MovePosition(100, 100);

            // Set page rotations (example values)
            Hashtable pageRotations = new Hashtable
            {
                { 1, 90 },
                { 2, 180 },
                { 3, 270 }
            };
            // The original example commented out the assignment; uncomment if needed.
            // pageEditor.PageRotations = pageRotations;

            // Set zoom where 1.0f = 100% zoom
            pageEditor.Zoom = 2.0f;

            // Save updated PDF file
            pageEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while manipulating page properties: {ex.Message}");
        }
    }
}