using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Forms;

/// <summary>
/// Demonstrates how to set a caption for a radio button field in a PDF form using Aspose.Pdf.
/// </summary>
public class SetRadioButtonCaption
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Input and output file paths.
        string inputPath = Path.Combine(inputDir, "RadioButtonField.pdf");
        string outputPath = Path.Combine(outputDir, "RadioButtonField_out.pdf");

        try
        {
            // Load source PDF form using the Facades API.
            Aspose.Pdf.Facades.Form formFacade = new Aspose.Pdf.Facades.Form(inputPath);

            // Load the same PDF document for manipulation.
            Document pdfDocument = new Document(inputPath);

            foreach (var item in formFacade.FieldNames)
            {
                Console.WriteLine(item);

                // Retrieve radio button options (not used further in this example).
                Dictionary<string, string> radioOptions = formFacade.GetButtonOptionValues(item);

                if (item.Contains("radio1"))
                {
                    // Access the radio button field from the document.
                    RadioButtonField radioField = pdfDocument.Form[item] as RadioButtonField;
                    if (radioField == null)
                        continue;

                    // Create a new radio button option (placeholder – not added to the field in this example).
                    RadioButtonOptionField optionField = new RadioButtonOptionField
                    {
                        OptionName = "Yes",
                        PartialName = "Yesname"
                    };

                    // Prepare a text fragment to be added near the radio button.
                    TextFragment updatedFragment = new TextFragment("test123");
                    updatedFragment.TextState.Font = FontRepository.FindFont("Arial");
                    updatedFragment.TextState.FontSize = 10;
                    updatedFragment.TextState.LineSpacing = 6.32f;

                    // Create a paragraph and position it relative to the radio button rectangle.
                    TextParagraph paragraph = new TextParagraph
                    {
                        Position = new Position(radioField.Rect.LLX, radioField.Rect.LLY + updatedFragment.TextState.FontSize)
                    };
                    paragraph.FormattingOptions.WrapMode = TextFormattingOptions.WordWrapMode.ByWords;
                    paragraph.AppendLine(updatedFragment);

                    // Append the paragraph to the first page of the document.
                    TextBuilder textBuilder = new TextBuilder(pdfDocument.Pages[1]);
                    textBuilder.AppendParagraph(paragraph);

                    // Remove an existing option from the radio button field.
                    radioField.DeleteOption("item1");
                }
            }

            // Save the modified PDF.
            pdfDocument.Save(outputPath);
            Console.WriteLine($"Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}