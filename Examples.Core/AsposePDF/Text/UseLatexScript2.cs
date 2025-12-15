using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates adding a LaTeX script inside a PDF using Aspose.Pdf.
/// </summary>
public class UseLatexScript2
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Output file path.
        string outputPath = Path.Combine(outputDir, "LatextScriptInPdf2_out.pdf");

        try
        {
            // Create a new Document object.
            Document doc = new Document();

            // Add a page to the document.
            Page page = doc.Pages.Add();

            // Create a table.
            Table table = new Table();

            // Add a row to the table.
            Row row = table.Rows.Add();

            // LaTeX script to be added.
            string latexText2 = @"\documentclass{article}
\begin{document}
Latex and the document class will normally take care of page layout issues for you. For submission to an academic publication, this entire topic will be out
\end{document}";

            // Add a cell containing the LaTeX script.
            Cell cell = row.Cells.Add();
            cell.Margin = new MarginInfo { Left = 20, Right = 20, Top = 20, Bottom = 20 };
            HtmlFragment text2 = new HtmlFragment(latexText2);
            cell.Paragraphs.Add(text2);

            // Add the table to the page.
            page.Paragraphs.Add(table);

            // Save the document.
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while creating the PDF: {ex.Message}");
        }
    }
}