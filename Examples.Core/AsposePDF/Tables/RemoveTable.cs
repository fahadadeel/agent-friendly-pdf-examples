using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.Tables;

public class RemoveTable
{
    /// <summary>
    /// Removes the first table from a PDF document and saves the result.
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Define full paths for the input and output PDF files.
            string inputPath = Path.Combine(inputDir, "Table_input.pdf");
            string outputPath = Path.Combine(outputDir, "Table_out.pdf");

            // Load existing PDF document.
            Document pdfDocument = new Document(inputPath);

            // Create TableAbsorber object to find tables.
            TableAbsorber absorber = new TableAbsorber();

            // Visit first page with absorber.
            absorber.Visit(pdfDocument.Pages[1]);

            // Get first table on the page.
            if (absorber.TableList.Count > 0)
            {
                AbsorbedTable table = absorber.TableList[0];

                // Remove the table.
                absorber.Remove(table);
            }
            else
            {
                Console.WriteLine("No tables were found on the first page.");
            }

            // Save the modified PDF.
            pdfDocument.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while removing the table: {ex.Message}");
        }
    }
}