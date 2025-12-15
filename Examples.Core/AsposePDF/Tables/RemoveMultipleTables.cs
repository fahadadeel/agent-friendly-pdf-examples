using Aspose.Pdf;
using Aspose.Pdf.Text;
using System;
using System.IO;

/// <summary>
/// Demonstrates how to remove all tables from a PDF document using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Tables;

public class RemoveMultipleTables
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "Table_input2.pdf");
            string outputPath = Path.Combine(outputDir, "Table2_out.pdf");

            // Load existing PDF document.
            Document pdfDocument = new Document(inputPath);

            // Create TableAbsorber object to find tables.
            TableAbsorber absorber = new TableAbsorber();

            // Visit second page (index 1) with absorber.
            absorber.Visit(pdfDocument.Pages[1]);

            // Get copy of table collection.
            AbsorbedTable[] tables = new AbsorbedTable[absorber.TableList.Count];
            absorber.TableList.CopyTo(tables, 0);

            // Loop through the copy of collection and remove tables.
            foreach (AbsorbedTable table in tables)
            {
                absorber.Remove(table);
            }

            // Save the modified document.
            pdfDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while removing tables: {ex.Message}");
        }
    }
}