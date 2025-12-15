using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates how to create a PDF document containing LaTeX content using Aspose.Pdf.
/// </summary>
public class UseLatexScript3
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory: data/outputs relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string outputPath = Path.Combine(outputDir, "Script_out.pdf");

            string s = @"
\usepackage{amsmath,amsthm}
\begin{document}
\begin{proof} The proof is a follows: 
\begin{align}
(x+y)^3&=(x+y)(x+y)^2
(x+y)(x^2+2xy+y^2)\\
&=x^3+3x^2y+3xy^3+x^3.\qedhere
\end{align}
\end{proof}
\end{document}";

            // Create a new PDF document.
            var doc = new Aspose.Pdf.Document();

            // Add a page to the document.
            var page = doc.Pages.Add();

            // Create a TeX fragment from the LaTeX string.
            var latex = new Aspose.Pdf.TeXFragment(s);

            // Add the fragment to the page.
            page.Paragraphs.Add(latex);

            // Save the document to the output path.
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in UseLatexScript3.Run: {ex.Message}");
        }
    }
}