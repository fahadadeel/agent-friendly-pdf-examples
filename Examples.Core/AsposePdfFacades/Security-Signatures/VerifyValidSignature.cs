using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePdfFacades.SecuritySignatures;

public class VerifyValidSignature
{
    /// <summary>
    /// Verifies a digital signature in a PDF document.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input directory relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine($"Input directory not found: {inputDir}");
                return;
            }

            string pdfPath = Path.Combine(inputDir, "DigitallySign.pdf");
            if (!File.Exists(pdfPath))
            {
                Console.WriteLine($"Input file not found: {pdfPath}");
                return;
            }

            // Ensure output directory exists (required by requirements, though not used here).
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // ExStart:VerifyValidSignature
            PdfFileSignature pdfSign = new PdfFileSignature();
            pdfSign.BindPdf(pdfPath);
            if (pdfSign.VerifySignature("Signature1"))
            {
                Console.WriteLine("Signature Verified");
            }
            else
            {
                Console.WriteLine("Signature verification failed.");
            }
            // ExEnd:VerifyValidSignature
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}