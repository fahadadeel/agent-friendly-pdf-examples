using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Forms;

/// <summary>
/// Demonstrates how to retrieve values and properties of a form field using Aspose.Pdf.Facades.
/// </summary>
public class GetFormFieldValue
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

            // Path to the source PDF containing the form.
            string inputPath = Path.Combine(inputDir, "FormField.pdf");

            // Create Form object.
            Form pdfForm = new Form();

            // Open the document.
            pdfForm.BindPdf(inputPath);

            // Get form field facade for the field named "textfield".
            FormFieldFacade fieldFacade = pdfForm.GetFieldFacade("textfield");

            // Output facade values.
            Console.WriteLine("Alignment : {0} ", fieldFacade.Alignment);
            Console.WriteLine("Background Color : {0} ", fieldFacade.BackgroundColor);
            Console.WriteLine("Border Color : {0} ", fieldFacade.BorderColor);
            Console.WriteLine("Border Style : {0} ", fieldFacade.BorderStyle);
            Console.WriteLine("Border Width : {0} ", fieldFacade.BorderWidth);
            Console.WriteLine("Box : {0} ", fieldFacade.Box);
            Console.WriteLine("Caption : {0} ", fieldFacade.Caption);
            Console.WriteLine("Font Name : {0} ", fieldFacade.Font);
            Console.WriteLine("Font Size : {0} ", fieldFacade.FontSize);
            Console.WriteLine("Page Number : {0} ", fieldFacade.PageNumber);
            Console.WriteLine("Text Color : {0} ", fieldFacade.TextColor);
            Console.WriteLine("Text Encoding : {0} ", fieldFacade.TextEncoding);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while retrieving form field values: {ex.Message}");
        }
    }
}