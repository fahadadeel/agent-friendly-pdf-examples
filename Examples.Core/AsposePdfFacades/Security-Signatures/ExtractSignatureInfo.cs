using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;

/// <summary>
/// Demonstrates extracting signature information from a PDF using Aspose.Pdf.Facades.
/// </summary>
namespace Examples.Core.AsposePdfFacades.Security_Signatures;

public class ExtractSignatureInfo
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "DigitallySign.pdf");

            // Output certificate file name (placeholder, adjust as needed).
            string certFileName = "certificate.cer";
            string certOutputPath = Path.Combine(outputDir, certFileName);

            using var pdfFileSignature = new PdfFileSignature();
            pdfFileSignature.BindPdf(inputPath);

            IList<string> sigNames = pdfFileSignature.GetSignNames();
            if (sigNames.Count > 0)
            {
                string sigName = sigNames[0] as string;
                // Preserving original logic: extract only when the signature name is null or empty.
                if (string.IsNullOrEmpty(sigName))
                {
                    Stream? cerStream = pdfFileSignature.ExtractCertificate(sigName);
                    if (cerStream != null)
                    {
                        using (cerStream)
                        {
                            // Read all bytes from the certificate stream.
                            using var memory = new MemoryStream();
                            cerStream.CopyTo(memory);
                            byte[] bytes = memory.ToArray();

                            // Write the certificate to the output file.
                            using var fs = new FileStream(certOutputPath, FileMode.Create, FileAccess.Write);
                            fs.Write(bytes, 0, bytes.Length);
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