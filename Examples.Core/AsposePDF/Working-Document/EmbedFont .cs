using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.WorkingDocument;

public class EmbedFont
{
    /// <summary>
    /// Embeds all fonts in a PDF document and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "EmbedFont_out.pdf");

            // Load an existing PDF file.
            Document doc = new Document(inputPath);

            // Iterate through all the pages.
            foreach (Page page in doc.Pages)
            {
                if (page.Resources.Fonts != null)
                {
                    foreach (Aspose.Pdf.Text.Font pageFont in page.Resources.Fonts)
                    {
                        if (!pageFont.IsEmbedded)
                            pageFont.IsEmbedded = true;
                    }
                }

                // Check for Form objects.
                foreach (XForm form in page.Resources.Forms)
                {
                    if (form.Resources.Fonts != null)
                    {
                        foreach (Aspose.Pdf.Text.Font formFont in form.Resources.Fonts)
                        {
                            if (!formFont.IsEmbedded)
                                formFont.IsEmbedded = true;
                        }
                    }
                }
            }

            // Save the modified PDF.
            doc.Save(outputPath);

            Console.WriteLine($"\nFont embedded successfully in a PDF file.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error embedding fonts: {ex.Message}");
        }
    }
}