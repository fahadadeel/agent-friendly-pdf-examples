using System;
using System.IO;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

/// <summary>
/// Demonstrates how to justify text in a PDF form field using Aspose.Pdf.Facades.
/// </summary>
public class JustifyText
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output paths relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputPath = Path.Combine(baseDir, "data", "inputs", "Input1.pdf");
        string outputDir = Path.Combine(baseDir, "data", "outputs");
        string outputPath = Path.Combine(outputDir, "JustifyText_out.pdf");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        try
        {
            // Open the source PDF.
            using var source = File.OpenRead(inputPath);
            using var memoryStream = new MemoryStream();

            // Create Form object and bind the source PDF.
            var form = new Form();
            form.BindPdf(source);

            // Fill the text field.
            form.FillField("Text1", "Thank you for using Aspose");

            // Save the modified document to a memory stream.
            form.Save(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            // Open the destination file stream.
            using var dest = File.Open(outputPath, FileMode.Create, FileAccess.Write);

            // Create FormEditor object and bind the PDF from the memory stream.
            var formEditor = new FormEditor();
            formEditor.BindPdf(memoryStream);

            // Set text alignment to justified.
            formEditor.Facade.Alignment = FormFieldFacade.AlignJustified;

            // Apply the decoration to the form field.
            formEditor.DecorateField();

            // Save the resultant PDF.
            formEditor.Save(dest);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while justifying text: {ex.Message}");
        }
    }
}