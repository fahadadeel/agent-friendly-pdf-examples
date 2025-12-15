using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates setting and retrieving field limits in PDF forms using Aspose.Pdf.
/// </summary>
public class SetFieldLimit
{
    /// <summary>
    /// Sets a maximum character limit on a text box field and saves the modified PDF.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Input PDF.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            // Output PDF.
            string outputPath = Path.Combine(outputDir, "SetFieldLimit_out.pdf");

            // Adding Field with limit.
            FormEditor form = new FormEditor();
            form.BindPdf(inputPath);
            form.SetFieldLimit("textbox1", 15);
            form.Save(outputPath);

            Console.WriteLine("\nField added successfully with limit.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SetFieldLimit.Run: {ex.Message}");
        }
    }

    /// <summary>
    /// Retrieves the maximum character limit of a text box field using the DOM API.
    /// </summary>
    public static void GetMaxFieldLimit()
    {
        try
        {
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string pdfPath = Path.Combine(inputDir, "FieldLimit.pdf");

            Document doc = new Document(pdfPath);
            if (doc.Form["textbox1"] is TextBoxField txtField)
            {
                Console.WriteLine("Limit: " + txtField.MaxLen);
            }
            else
            {
                Console.WriteLine("Field 'textbox1' not found or not a TextBoxField.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SetFieldLimit.GetMaxFieldLimit: {ex.Message}");
        }
    }

    /// <summary>
    /// Retrieves the maximum character limit of a text box field using the Facades API.
    /// </summary>
    public static void GetMaxFieldLimitUsingFacades()
    {
        try
        {
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string pdfPath = Path.Combine(inputDir, "FieldLimit.pdf");

            Aspose.Pdf.Facades.Form form = new Aspose.Pdf.Facades.Form();
            form.BindPdf(pdfPath);
            int limit = form.GetFieldLimit("textbox1");
            Console.WriteLine("Limit: " + limit);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in SetFieldLimit.GetMaxFieldLimitUsingFacades: {ex.Message}");
        }
    }
}