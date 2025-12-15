using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Tables;

public class AddTable
{
    /// <summary>
    /// Demonstrates adding a table to an existing PDF document.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "AddTable.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load source PDF document.
            Document doc = new Document(inputPath);

            // Initialize a new instance of the Table.
            Table table = new Table();

            // Set the table border color as LightGray (RGB 211,211,211).
            var lightGray = Color.FromRgb(211, 211, 211);
            table.Border = new BorderInfo(BorderSide.All, 0.5f, lightGray);
            table.DefaultCellBorder = new BorderInfo(BorderSide.All, 0.5f, lightGray);

            // Create a loop to add 9 rows (row_count from 1 to 9).
            for (int row_count = 1; row_count < 10; row_count++)
            {
                Row row = table.Rows.Add();
                row.Cells.Add($"Column ({row_count}, 1)");
                row.Cells.Add($"Column ({row_count}, 2)");
                row.Cells.Add($"Column ({row_count}, 3)");
            }

            // Add table object to first page of input document.
            doc.Pages[1].Paragraphs.Add(table);

            // Output PDF file path.
            string outputPath = Path.Combine(outputDir, "document_with_table_out.pdf");

            // Save updated document containing table object.
            doc.Save(outputPath);

            Console.WriteLine($"\nTable added successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}