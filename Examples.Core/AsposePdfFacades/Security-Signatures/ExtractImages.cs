using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Aspose.Pdf.Facades;
using System.Collections;

// TODO: import or include helper class RunExamples from original source if needed

namespace Examples.Core.AsposePdfFacades.Security_Signatures;

public class ExtractImages
{
    /// <summary>
    /// Extracts images from digital signatures in a PDF file.
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

            string inputPath = Path.Combine(inputDir, "DigitallySign.pdf");
            string outputPath = Path.Combine(outputDir, "ExtractImages_out.jpg");

            // Load the PDF document.
            var doc = new Aspose.Pdf.Document(inputPath);

            using (PdfFileSignature signature = new PdfFileSignature(doc))
            {
                if (signature.ContainsSignature())
                {
                    foreach (string sigName in signature.GetSignNames())
                    {
                        using (Stream imageStream = signature.ExtractImage(sigName))
                        {
                            if (imageStream != null)
                            {
                                using (Image image = Bitmap.FromStream(imageStream))
                                {
                                    image.Save(outputPath, ImageFormat.Jpeg);
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}