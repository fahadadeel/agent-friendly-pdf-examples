using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates rendering replaceable symbols in a PDF using Aspose.Pdf.
/// </summary>
public class RenderingReplaceableSymbols
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base path.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Output file path.
            string outputPath = Path.Combine(outputDir, "RenderingReplaceableSymbols_out.pdf");

            // Create a new PDF document.
            Document pdfApplicationDoc = new Document();
            Page applicationFirstPage = pdfApplicationDoc.Pages.Add();

            // Initialize new TextFragment with text containing required newline markers.
            TextFragment textFragment = new TextFragment("Applicant Name: " + Environment.NewLine + " Joe Smoe");

            // Set text fragment properties.
            textFragment.TextState.FontSize = 12;
            textFragment.TextState.Font = FontRepository.FindFont("TimesNewRoman");
            textFragment.TextState.BackgroundColor = Color.LightGray;
            textFragment.TextState.ForegroundColor = Color.Red;

            // Create TextParagraph object and add the TextFragment.
            TextParagraph par = new TextParagraph();
            par.AppendLine(textFragment);

            // Set paragraph position.
            par.Position = new Position(100, 600);

            // Use TextBuilder to add the paragraph to the page.
            TextBuilder textBuilder = new TextBuilder(applicationFirstPage);
            textBuilder.AppendParagraph(par);

            // Save the PDF document.
            pdfApplicationDoc.Save(outputPath);

            Console.WriteLine($"\nReplaceable symbols rendered successfully during PDF creation.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while executing RenderingReplaceableSymbols: {ex.Message}");
        }
    }
}