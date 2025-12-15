using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace Examples.Core.AsposePDF.Security_Signatures;

public class ExtractingImage
{
    /// <summary>
    /// Extracts signature images from a PDF and saves them as JPEG files.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "ExtractingImage.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            using var pdfDocument = new Document(inputPath);
            foreach (Field field in pdfDocument.Form)
            {
                if (field is SignatureField sf)
                {
                    using Stream? imageStream = sf.ExtractImage();
                    if (imageStream != null)
                    {
                        // System.Drawing is platform‑specific; ensure the runtime supports it.
                        var image = System.Drawing.Image.FromStream(imageStream);
                        string outFile = Path.Combine(outputDir, "output_out.jpg");
                        image.Save(outFile, ImageFormat.Jpeg);
                        Console.WriteLine($"Image saved to {outFile}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}