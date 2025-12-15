using System;
using System.IO;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates how to determine line breaks in a PDF document using Aspose.Pdf.
/// </summary>
public class DetermineLineBreak
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Create a new PDF document.
            var doc = new Aspose.Pdf.Document();
            var page = doc.Pages.Add();

            // Add several paragraphs with long text to demonstrate line breaking.
            for (int i = 0; i < 4; i++)
            {
                var text = new TextFragment(
                    "Lorem ipsum \r\ndolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
                text.TextState.FontSize = 20;
                page.Paragraphs.Add(text);
            }

            // Save the PDF to the output directory.
            string pdfPath = Path.Combine(outputDir, "DetermineLineBreak_out.pdf");
            doc.Save(pdfPath);

            // Retrieve notifications (e.g., line break information) from the first page.
            string notifications = doc.Pages[1].GetNotifications();

            // Write notifications to a text file in the output directory.
            string notificationsPath = Path.Combine(outputDir, "notifications_out.txt");
            File.WriteAllText(notificationsPath, notifications);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in DetermineLineBreak.Run: {ex.Message}");
        }
    }
}