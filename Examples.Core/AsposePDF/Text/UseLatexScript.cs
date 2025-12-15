using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates adding LaTeX script to a PDF using Aspose.Pdf.
/// </summary>
public class UseLatexScript
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine output directory relative to the application base directory.
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Create a new Document object.
            Document doc = new Document();

            // Add a page.
            Page page = doc.Pages.Add();

            // Create a table.
            Table table = new Table();

            // Add a row.
            Row row = table.Rows.Add();

            // Add a cell with LaTeX script.
            string latexText = "$123456789+\\sqrt{1}+\\int_a^b f(x)dx$";
            Cell cell = row.Cells.Add();
            cell.Margin = new MarginInfo { Left = 20, Right = 20, Top = 20, Bottom = 20 };

            // The second TeXFragment constructor bool parameter eliminates paragraph indents.
            TeXFragment texFragment = new TeXFragment(latexText, true);
            cell.Paragraphs.Add(texFragment);

            // Add the table to the page.
            page.Paragraphs.Add(table);

            // Save the document.
            string outputPath = Path.Combine(outputDir, "LatextScriptInPdf_out.pdf");
            doc.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in UseLatexScript.Run: {ex.Message}");
        }
    }
}