using System;
using System.IO;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

/// <summary>
/// Demonstrates various features of the Aspose.Pdf FormEditor facade.
/// </summary>
public class FormEditorFeatures
{
    /// <summary>
    /// Executes the FormEditor feature example.
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

            // Define input and output file paths.
            string inputPath = Path.Combine(inputDir, "inFile.pdf");
            string outputPath = Path.Combine(outputDir, "FormEditorFeatures2_out.pdf");

            // Load the PDF document.
            var doc = new Aspose.Pdf.Document(inputPath);

            // Create an instance of FormEditor.
            var editor = new FormEditor(doc);

            // Add a text field.
            editor.AddField(FieldType.Text, "field1", 1, 300, 500, 350, 525);

            // Add a list box field.
            editor.AddField(FieldType.ListBox, "field2", 1, 300, 200, 350, 225);

            // Add list items.
            editor.AddListItem("field2", "item 1");
            editor.AddListItem("field2", "item 2");

            // Add a submit button.
            editor.AddSubmitBtn("submitbutton", 1, "Submit Form", "http://Testwebsite.com/testpage", 200, 200, 250, 225);

            // Delete a list item.
            editor.DelListItem("field2", "item 1");

            // Move a field to a new position.
            editor.MoveField("field1", 10, 10, 50, 50);

            // Remove an existing field.
            editor.RemoveField("field1");

            // Rename an existing field.
            editor.RenameField("field1", "newfieldname");

            // Reset all visual attributes.
            editor.ResetFacade();

            // Set the alignment style of a text field.
            editor.SetFieldAlignment("field1", FormFieldFacade.AlignLeft);

            // Set appearance of the field.
            editor.SetFieldAppearance("field1", AnnotationFlags.NoRotate);

            // Set field attributes (e.g., ReadOnly, Required).
            editor.SetFieldAttribute("field1", PropertyFlag.ReadOnly);

            // Set field limit.
            editor.SetFieldLimit("field1", 25);

            // Save the modified PDF.
            editor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing FormEditorFeatures: {ex.Message}");
        }
    }
}