using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

public class PDFToTeX
{
    /// <summary>
    /// Converts a PDF document to LaTeX (TeX) format using Aspose.Pdf.
    /// Input files are read from the <c>data/inputs</c> directory relative to the application base path,
    /// and the resulting TeX file is written to the <c>data/outputs</c> directory.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Input PDF file path.
            string inputPdfPath = Path.Combine(inputDir, "PDFToTeX.pdf");
            if (!File.Exists(inputPdfPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPdfPath}");
                return;
            }

            // Create Document object.
            Document doc = new Document(inputPdfPath);

            // Instantiate LaTeX save option.
            TeXSaveOptions saveOptions = new TeXSaveOptions
            {
                // Set the output directory path for the save option object.
                OutDirectoryPath = outputDir
            };

            // Output TeX file path.
            string outputTexPath = Path.Combine(outputDir, "PDFToTeX_out.tex");

            // Save PDF file into LaTeX format.
            doc.Save(outputTexPath, saveOptions);

            Console.WriteLine($"Conversion completed successfully. Output saved to: {outputTexPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred during PDF to TeX conversion: {ex.Message}");
        }
    }
}