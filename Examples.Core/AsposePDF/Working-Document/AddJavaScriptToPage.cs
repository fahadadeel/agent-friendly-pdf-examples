using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.WorkingDocument;

/// <summary>
/// Demonstrates adding JavaScript actions to a PDF document and its pages using Aspose.Pdf.
/// </summary>
public class AddJavaScriptToPage
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

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the existing PDF document.
            Document doc = new Document(inputPath);

            // Adding JavaScript at Document Level.
            // Instantiate JavascriptAction with the desired JavaScript statement.
            JavascriptAction javaScript = new JavascriptAction("this.print({bUI:true,bSilent:false,bShrinkToFit:true});");

            // Assign JavascriptAction object to the document's OpenAction.
            doc.OpenAction = javaScript;

            // Adding JavaScript at Page Level (page index is 1‑based in Aspose.Pdf).
            // Ensure the document has at least 2 pages.
            if (doc.Pages.Count >= 2)
            {
                doc.Pages[2].Actions.OnOpen = new JavascriptAction("app.alert('page 1 opened')");
                doc.Pages[2].Actions.OnClose = new JavascriptAction("app.alert('page 1 closed')");
            }
            else
            {
                Console.WriteLine("The document does not contain a second page; page‑level JavaScript will not be added.");
            }

            // Output PDF file path.
            string outputPath = Path.Combine(outputDir, "JavaScript-Added_out.pdf");

            // Save the modified PDF document.
            doc.Save(outputPath);

            Console.WriteLine($"\nJavascript added successfully to a page.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}