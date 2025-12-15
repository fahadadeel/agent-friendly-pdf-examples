using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.SecuritySignatures;

/// <summary>
/// Demonstrates extracting signature certificates from a PDF document using Aspose.Pdf.
/// </summary>
public class ExtractSignatureInfo
{
    /// <summary>
    /// Runs the example.
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

            string inputPath = Path.Combine(inputDir, "ExtractSignatureInfo.pdf");
            string outputCerPath = Path.Combine(outputDir, "input.cer");

            using var pdfDocument = new Document(inputPath);
            foreach (Field field in pdfDocument.Form)
            {
                if (field is SignatureField sf)
                {
                    Stream? cerStream = sf.ExtractCertificate();
                    if (cerStream != null)
                    {
                        // Properly nest the using statements to ensure disposal.
                        using (cerStream)
                        {
                            using var fs = new FileStream(outputCerPath, FileMode.Create, FileAccess.Write);
                            cerStream.CopyTo(fs);
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