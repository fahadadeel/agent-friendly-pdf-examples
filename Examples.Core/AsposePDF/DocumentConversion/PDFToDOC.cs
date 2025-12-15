using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

/// <summary>
/// Demonstrates PDF to DOC/DOCX conversion using Aspose.Pdf.
/// </summary>
public class PDFToDOC
{
    /// <summary>
    /// Converts a PDF file to DOC format.
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

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "PDFToDOC.pdf");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the PDF document.
            Document pdfDocument = new Document(inputPath);

            // Output DOC file.
            string outputPath = Path.Combine(outputDir, "PDFToDOC_out.doc");

            // Save as DOC.
            pdfDocument.Save(outputPath, SaveFormat.Doc);

            Console.WriteLine($"PDF successfully converted to DOC: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF to DOC conversion: {ex.Message}");
        }
    }

    /// <summary>
    /// Converts a PDF file to DOC format using advanced save options.
    /// </summary>
    public static void SaveUsingSaveOptions()
    {
        try
        {
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "PDFToDOC.pdf");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            Document pdfDocument = new Document(inputPath);

            // Configure save options.
            DocSaveOptions saveOptions = new DocSaveOptions
            {
                Mode = DocSaveOptions.RecognitionMode.Flow,
                RelativeHorizontalProximity = 2.5f,
                RecognizeBullets = true
            };

            string outputPath = Path.Combine(outputDir, "saveOptionsOutput_out.doc");
            pdfDocument.Save(outputPath, saveOptions);

            Console.WriteLine($"PDF successfully converted to DOC with options: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF to DOC conversion with options: {ex.Message}");
        }
    }

    /// <summary>
    /// Converts a PDF file to DOCX format.
    /// </summary>
    public static void ConvertToDOCX()
    {
        try
        {
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "PDFToDOC.pdf");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            Document pdfDocument = new Document(inputPath);

            DocSaveOptions saveOptions = new DocSaveOptions
            {
                Format = DocSaveOptions.DocFormat.DocX
            };

            string outputPath = Path.Combine(outputDir, "ConvertToDOCX_out.docx");
            pdfDocument.Save(outputPath, saveOptions);

            Console.WriteLine($"PDF successfully converted to DOCX: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF to DOCX conversion: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.