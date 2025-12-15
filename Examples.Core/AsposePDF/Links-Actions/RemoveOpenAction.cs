using System;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Example demonstrating how to remove the open action from a PDF document using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Links_Actions;

public class RemoveOpenAction
{
    /// <summary>
    /// Removes the open action from the specified PDF and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directory (the directory where the application is running)
            string baseDir = AppContext.BaseDirectory;

            // Input and output directories relative to the application base
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Define input and output file paths
            string inputPath = Path.Combine(inputDir, "RemoveOpenAction.pdf");
            string outputPath = Path.Combine(outputDir, "RemoveOpenAction_out.pdf");

            // Open the PDF document
            Document document = new Document(inputPath);

            // Remove the document open action
            document.OpenAction = null;

            // Save the updated document
            document.Save(outputPath);

            Console.WriteLine("\nOpen action removed successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error removing open action: {ex.Message}");
        }
    }
}