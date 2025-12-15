using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.WorkingDocument;

public class SetExpiryDate
{
    /// <summary>
    /// Demonstrates how to set a JavaScript expiry date action on a PDF document.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine output directory and ensure it exists.
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Output file path.
            string outputPath = Path.Combine(outputDir, "SetExpiryDate_out.pdf");

            // Instantiate Document object.
            Document doc = new Document();

            // Add a page.
            doc.Pages.Add();

            // Add a text fragment.
            doc.Pages[1].Paragraphs.Add(new TextFragment("Hello World..."));

            // Create JavaScript action to set PDF expiry date.
            JavascriptAction javaScript = new JavascriptAction(
                "var year=2017;"
                + "var month=5;"
                + "today = new Date(); today = new Date(today.getFullYear(), today.getMonth());"
                + "expiry = new Date(year, month);"
                + "if (today.getTime() > expiry.getTime())"
                + "app.alert('The file is expired. You need a new one.');");

            // Set JavaScript as PDF open action.
            doc.OpenAction = javaScript;

            // Save the PDF document.
            doc.Save(outputPath);

            Console.WriteLine($"\nPDF expiry date setup successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during SetExpiryDate example: {ex.Message}");
        }
    }
}