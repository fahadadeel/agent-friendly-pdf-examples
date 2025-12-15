using System;
using System.IO;
using System.Collections;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.WorkingDocument;

/// <summary>
/// Demonstrates adding and removing JavaScript from an Aspose.Pdf document.
/// </summary>
public class AddRemoveJavaScriptToDoc
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
            Directory.CreateDirectory(outputDir);

            // Path for the generated PDF.
            string outputPath = Path.Combine(outputDir, "AddJavascript.pdf");

            // Create a new PDF document and add JavaScript functions.
            Document doc = new Document();
            doc.Pages.Add();
            doc.JavaScript["func1"] = "function func1() { hello(); }";
            doc.JavaScript["func2"] = "function func2() { hello(); }";
            doc.Save(outputPath);

            // Load the document back to demonstrate removal of JavaScript.
            Document doc1 = new Document(outputPath);
            IList keys = (IList)doc1.JavaScript.Keys;
            Console.WriteLine("=============================== ");
            foreach (string key in keys)
            {
                Console.WriteLine($"{key} ==> {doc1.JavaScript[key]}");
            }

            // Remove a specific JavaScript entry.
            doc1.JavaScript.Remove("func1");
            Console.WriteLine("Key 'func1' removed ");
            Console.WriteLine("=============================== ");

            Console.WriteLine("\nJavascript added/removed successfully to a document.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during AddRemoveJavaScriptToDoc execution: {ex.Message}");
        }
    }
}