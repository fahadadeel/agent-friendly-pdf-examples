using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Tables;

public class ManipulateTable
{
    /// <summary>
    /// Demonstrates how to manipulate a table in an existing PDF document using Aspose.Pdf.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            string outputPath = Path.Combine(outputDir, "ManipulateTable_out.pdf");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load existing PDF file.
            Document pdfDocument = new Document(inputPath);

            // Create TableAbsorber object to find tables.
            TableAbsorber absorber = new TableAbsorber();

            // Visit first page with absorber.
            absorber.Visit(pdfDocument.Pages[1]);

            // Get access to first table on page, its first cell and text fragments in it.
            // Note: Indexes are zero‑based; the original example accesses TextFragments[1].
            TextFragment fragment = absorber.TableList[0].RowList[0].CellList[0].TextFragments[1];

            // Change text of the selected text fragment.
            fragment.Text = "hi world";

            // Save the modified PDF.
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nTable manipulated successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}