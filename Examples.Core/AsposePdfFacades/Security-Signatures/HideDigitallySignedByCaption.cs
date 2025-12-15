using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;

/// <summary>
/// Demonstrates how to hide the "Digitally signed by" caption in a PDF signature using Aspose.Pdf.Facades.
/// </summary>
namespace Examples.Core.AsposePdfFacades.Security_Signatures;

public class HideDigitallySignedByCaption
{
    /// <summary>
    /// Executes the example.
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

            // Input files.
            string pfxPath = Path.Combine(inputDir, "SampleCertificate.pfx");
            string pdfInputPath = Path.Combine(inputDir, "input.pdf");
            string pdfOutputPath = Path.Combine(outputDir, "output.pdf");

            using (PdfFileSignature pdfSign = new PdfFileSignature())
            {
                pdfSign.BindPdf(pdfInputPath);

                // Create a rectangle for signature location.
                // Note: System.Drawing.Rectangle is used here; on non‑Windows platforms ensure the required runtime support.
                Rectangle rect = new Rectangle(310, 45, 200, 50);

                // Create PKCS#7 signature using the certificate.
                PKCS7 pkcs = new PKCS7(pfxPath, "idsrv3test");

                // Customize appearance to hide the default caption.
                SignatureCustomAppearance signatureCustomAppearance = new SignatureCustomAppearance
                {
                    FontSize = 6,
                    FontFamilyName = "Times New Roman",
                    DigitalSignedLabel = "Signed by me"
                };
                pkcs.CustomAppearance = signatureCustomAppearance;

                // Sign the PDF file (page 1, visible signature).
                pdfSign.Sign(1, true, rect, pkcs);

                // Save the signed PDF.
                pdfSign.Save(pdfOutputPath);
            }

            Console.WriteLine($"PDF signed successfully. Output saved to: {pdfOutputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during PDF signing: {ex.Message}");
        }
    }
}