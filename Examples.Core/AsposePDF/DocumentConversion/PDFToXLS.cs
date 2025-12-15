using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates PDF to Excel conversion using Aspose.Pdf.
/// </summary>
public class PDFToXLS
{
    /// <summary>
    /// Converts a PDF to XLS format.
    /// </summary>
    public static void Run()
    {
        try
        {
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "PDFToXLS_out.xls");

            // Load PDF document
            Document pdfDocument = new Document(inputPath);

            // Instantiate ExcelSaveOptions
            ExcelSaveOptions excelSave = new ExcelSaveOptions();

            // Save the output in XLS format
            pdfDocument.Save(outputPath, excelSave);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PDFToXLS.Run: {ex.Message}");
        }
    }

    /// <summary>
    /// Converts a PDF to XLSX format.
    /// </summary>
    public static void PDFtoXLSX()
    {
        try
        {
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "PDFToXLSX_out.xlsx");

            // Load PDF document
            Document pdfDocument = new Document(inputPath);

            // Instantiate ExcelSaveOptions and set format to XLSX
            ExcelSaveOptions excelSave = new ExcelSaveOptions();
            excelSave.Format = ExcelSaveOptions.ExcelFormat.XLSX;

            // Save the output in XLSX format
            pdfDocument.Save(outputPath, excelSave);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PDFToXLS.PDFtoXLSX: {ex.Message}");
        }
    }

    /// <summary>
    /// Converts a PDF to XLS while controlling column insertion.
    /// </summary>
    public static void ControlColumn()
    {
        try
        {
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "PDFToXLSControlColumn_out.xls");

            // Load PDF document
            Document pdfDocument = new Document(inputPath);

            // Instantiate ExcelSaveOptions and configure column behavior
            ExcelSaveOptions excelSave = new ExcelSaveOptions
            {
                InsertBlankColumnAtFirst = false
            };

            // Save the output in XLS format
            pdfDocument.Save(outputPath, excelSave);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PDFToXLS.ControlColumn: {ex.Message}");
        }
    }

    /// <summary>
    /// Exports all PDF pages to a single worksheet in the resulting XLS file.
    /// </summary>
    public static void ExportAllPagesToSingle()
    {
        try
        {
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "input.pdf");
            string outputPath = Path.Combine(outputDir, "PDFToXLSExportAllPagesToSingle_out.xls");

            // Load PDF document
            Document pdfDocument = new Document(inputPath);

            // Instantiate ExcelSaveOptions and set to minimize worksheets
            ExcelSaveOptions excelSave = new ExcelSaveOptions
            {
                MinimizeTheNumberOfWorksheets = true
            };

            // Save the output in XLS format
            pdfDocument.Save(outputPath, excelSave);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PDFToXLS.ExportAllPagesToSingle: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.