using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates how to retrieve form fields located within a specific rectangular region of a PDF document.
/// </summary>
public class GetFieldsFromRegion
{
    /// <summary>
    /// Entry point for the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input directory relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string inputPath = Path.Combine(inputDir, "GetFieldsFromRegion.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Define the rectangle area (coordinates are in points).
            Rectangle rectangle = new Rectangle(35, 30, 500, 500);

            // Access the form within the document.
            Form form = doc.Form;

            // Retrieve fields that intersect the rectangle.
            Field[] fields = form.GetFieldsInRect(rectangle);

            // Display field names and values.
            foreach (Field field in fields)
            {
                Console.Out.WriteLine($"Field Name: {field.FullName} - Field Value: {field.Value}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}