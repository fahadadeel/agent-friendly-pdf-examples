using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;
using System;
using System.Drawing;
using System.IO;

namespace Examples.Core.AsposePdfFacades.Security_Signatures;

/// <summary>
/// Demonstrates signing a PDF while suppressing location and reason fields.
/// </summary>
public class SuppressLocationAndReason
{
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
            string inPfxFile = Path.Combine(inputDir, "certificate.pfx");
            string inFile = Path.Combine(inputDir, "input.pdf");

            // Output file.
            string outFile = Path.Combine(outputDir, "output.pdf");

            using (PdfFileSignature pdfSign = new PdfFileSignature())
            {
                // Bind the source PDF.
                pdfSign.BindPdf(inFile);

                // Create a rectangle for the signature location.
                // NOTE: System.Drawing may require additional runtime support on non‑Windows platforms.
                Rectangle rect = new Rectangle(100, 100, 200, 100);

                // Create the PKCS#1 signature using the certificate.
                PKCS1 signature = new PKCS1(inPfxFile, "12345");

                // Sign the PDF file.
                // Parameters: pageNumber, signatureName, location, reason, isVisible, rectangle, signature.
                pdfSign.Sign(1, "", "Contact", "", true, rect, signature);

                // Save the signed PDF.
                pdfSign.Save(outFile);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}