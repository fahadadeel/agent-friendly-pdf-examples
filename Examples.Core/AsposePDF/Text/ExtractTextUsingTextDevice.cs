using System;
using System.IO;
using System.Text;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Devices;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates extracting text from a PDF document using Aspose.Pdf's <see cref="TextDevice"/>.
/// </summary>
public class ExtractTextUsingTextDevice
{
    /// <summary>
    /// Executes the text extraction example.
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
            Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Output text file.
            string outputPath = Path.Combine(outputDir, "input_Text_Extracted_out.txt");

            // Open the PDF document.
            Document pdfDocument = new Document(inputPath);
            StringBuilder builder = new StringBuilder();

            // Iterate through each page and extract text.
            foreach (Page pdfPage in pdfDocument.Pages)
            {
                using MemoryStream textStream = new MemoryStream();

                // Create text device.
                TextDevice textDevice = new TextDevice();

                // Set text extraction options – use Pure formatting mode.
                TextExtractionOptions textExtOptions = new TextExtractionOptions(TextExtractionOptions.TextFormattingMode.Pure);
                textDevice.ExtractionOptions = textExtOptions;

                // Extract text from the current page into the memory stream.
                textDevice.Process(pdfPage, textStream);

                // The original example also processed the first page again; preserve that behavior.
                // Note: This may duplicate text for the first page.
                textDevice.Process(pdfDocument.Pages[1], textStream);

                // Retrieve extracted text from the memory stream.
                string extractedText = Encoding.Unicode.GetString(textStream.ToArray());

                builder.Append(extractedText);
            }

            // Write the accumulated text to the output file.
            File.WriteAllText(outputPath, builder.ToString());

            Console.WriteLine($"\nText extracted successfully using TextDevice.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during text extraction: {ex.Message}");
        }
    }
}