using System;
using System.IO;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

public class ConcatenateMultiplePDFUsingMemoryStream
{
    /// <summary>
    /// Concatenates two PDF files using memory streams and saves the result.
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

            // Input file paths.
            string inputPath1 = Path.Combine(inputDir, "inFile.pdf");
            string inputPath2 = Path.Combine(inputDir, "inFile2.pdf");

            // Output file path.
            string outputPath = Path.Combine(outputDir, "merged_out.pdf");

            // Read first PDF into a byte array.
            byte[] buffer1;
            using (FileStream fs1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read))
            {
                buffer1 = new byte[fs1.Length];
                int read = fs1.Read(buffer1, 0, buffer1.Length);
                // Optional: verify read == buffer1.Length
            }

            // Read second PDF into a byte array.
            byte[] buffer2;
            using (FileStream fs2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read))
            {
                buffer2 = new byte[fs2.Length];
                int read = fs2.Read(buffer2, 0, buffer2.Length);
            }

            // Concatenate using memory streams.
            using (MemoryStream pdfStream = new MemoryStream())
            using (MemoryStream fileStream1 = new MemoryStream(buffer1))
            using (MemoryStream fileStream2 = new MemoryStream(buffer2))
            {
                PdfFileEditor pdfEditor = new PdfFileEditor();
                pdfEditor.Concatenate(fileStream1, fileStream2, pdfStream);

                // Write the concatenated PDF to the output file.
                byte[] resultData = pdfStream.ToArray();
                using (FileStream output = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    output.Write(resultData, 0, resultData.Length);
                }
            }

            Console.WriteLine($"Merged PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF concatenation: {ex.Message}");
        }
    }
}