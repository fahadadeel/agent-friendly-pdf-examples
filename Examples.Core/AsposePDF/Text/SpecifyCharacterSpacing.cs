using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates how to specify character spacing using various Aspose.Pdf text APIs.
/// </summary>
public class SpecifyCharacterSpacing
{
    /// <summary>
    /// Executes all character spacing examples.
    /// </summary>
    public static void Run()
    {
        try
        {
            UsingTextBuilderAndFragment();
            UsingTextBuilderAndParagraph();
            UsingTextStamp();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while running examples: {ex.Message}");
        }
    }

    public static void UsingTextBuilderAndFragment()
    {
        // ExStart:UsingTextBuilderAndFragment
        // Resolve output directory.
        string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
        Directory.CreateDirectory(outputDir);
        string outputPath = Path.Combine(outputDir, "CharacterSpacingUsingTextBuilderAndFragment_out.pdf");

        try
        {
            // Create Document instance
            Document pdfDocument = new Document();
            // Add page to pages collection of Document
            Page page = pdfDocument.Pages.Add();
            // Create TextBuilder instance
            TextBuilder builder = new TextBuilder(pdfDocument.Pages[1]);
            // Create text fragment instance with sample contents
            TextFragment wideFragment = new TextFragment("Text with increased character spacing");
            wideFragment.TextState.ApplyChangesFrom(new TextState("Arial", 12));
            // Specify character spacing for TextFragment
            wideFragment.TextState.CharacterSpacing = 2.0f;
            // Specify the position of TextFragment
            wideFragment.Position = new Position(100, 650);
            // Append TextFragment to TextBuilder instance
            builder.AppendText(wideFragment);
            // Save resulting PDF document.
            pdfDocument.Save(outputPath);
            Console.WriteLine("\nCharacter spacing specified successfully using Text builder and fragment.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in UsingTextBuilderAndFragment: {ex.Message}");
        }
        // ExEnd:UsingTextBuilderAndFragment
    }

    public static void UsingTextBuilderAndParagraph()
    {
        // ExStart:UsingTextBuilderAndParagraph
        // Resolve output directory.
        string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
        Directory.CreateDirectory(outputDir);
        string outputPath = Path.Combine(outputDir, "CharacterSpacingUsingTextBuilderAndParagraph_out.pdf");

        try
        {
            // Create Document instance
            Document pdfDocument = new Document();
            // Add page to pages collection of Document
            Page page = pdfDocument.Pages.Add();
            // Create TextBuilder instance
            TextBuilder builder = new TextBuilder(pdfDocument.Pages[1]);
            // Instantiate TextParagraph instance
            TextParagraph paragraph = new TextParagraph();
            // Create TextState instance to specify font name and size
            TextState state = new TextState("Arial", 12);
            // Specify the character spacing
            state.CharacterSpacing = 1.5f;
            // Append text to TextParagraph object
            paragraph.AppendLine("This is paragraph with character spacing", state);
            // Specify the position for TextParagraph
            paragraph.Position = new Position(100, 550);
            // Append TextParagraph to TextBuilder instance
            builder.AppendParagraph(paragraph);
            // Save resulting PDF document.
            pdfDocument.Save(outputPath);
            Console.WriteLine("\nCharacter spacing specified successfully using Text builder and paragraph.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in UsingTextBuilderAndParagraph: {ex.Message}");
        }
        // ExEnd:UsingTextBuilderAndParagraph
    }

    public static void UsingTextStamp()
    {
        // ExStart:UsingTextStamp
        // Resolve output directory.
        string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
        Directory.CreateDirectory(outputDir);
        string outputPath = Path.Combine(outputDir, "CharacterSpacingUsingTextStamp_out.pdf");

        try
        {
            // Create Document instance
            Document pdfDocument = new Document();
            // Add page to pages collection of Document
            Page page = pdfDocument.Pages.Add();
            // Instantiate TextStamp instance with sample text
            TextStamp stamp = new TextStamp("This is text stamp with character spacing");
            // Specify font name for Stamp object
            stamp.TextState.Font = FontRepository.FindFont("Arial");
            // Specify Font size for TextStamp
            stamp.TextState.FontSize = 12;
            // Specify character spacing as 1f
            stamp.TextState.CharacterSpacing = 1f;
            // Set the XIndent for Stamp
            stamp.XIndent = 100;
            // Set the YIndent for Stamp
            stamp.YIndent = 500;
            // Add textual stamp to page instance
            stamp.Put(page);
            // Save resulting PDF document.
            pdfDocument.Save(outputPath);
            Console.WriteLine("\nCharacter spacing specified successfully using text stamp.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in UsingTextStamp: {ex.Message}");
        }
        // ExEnd:UsingTextStamp
    }
}