using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.WorkingDocument;

public class SetViewerPreference
{
    /// <summary>
    /// Demonstrates how to change viewer preferences of a PDF document using Aspose.Pdf.Facades.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Path to the source PDF.
            string inputPath = Path.Combine(inputDir, "SetViewerPreference.pdf");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Initialize the content editor and bind the PDF.
            PdfContentEditor contentEditor = new PdfContentEditor();
            contentEditor.BindPdf(inputPath);

            // Change Viewer Preferences.
            contentEditor.ChangeViewerPreference(ViewerPreference.CenterWindow);
            contentEditor.ChangeViewerPreference(ViewerPreference.HideMenubar);
            contentEditor.ChangeViewerPreference(ViewerPreference.PageModeUseNone);

            // Save the modified PDF.
            string outputPath = Path.Combine(outputDir, "SetViewerPreference_out.pdf");
            contentEditor.Save(outputPath);

            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}