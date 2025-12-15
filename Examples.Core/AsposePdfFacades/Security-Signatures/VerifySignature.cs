using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using System.Collections;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePdfFacades.SecuritySignatures;

/// <summary>
/// Demonstrates how to verify a digital signature in a PDF using Aspose.Pdf.Facades.
/// </summary>
public class VerifySignature
{
    /// <summary>
    /// Runs the signature verification example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve the input directory (data/inputs) relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            // Ensure the directory exists.
            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine($"Input directory not found: {inputDir}");
                return;
            }

            string pdfPath = Path.Combine(inputDir, "DigitallySign.pdf");
            if (!File.Exists(pdfPath))
            {
                Console.WriteLine($"Input PDF not found: {pdfPath}");
                return;
            }

            // ExStart:VerifySignature
            PdfFileSignature pdfSign = new PdfFileSignature();
            pdfSign.BindPdf(pdfPath);

            // Verify the signature named "Signature1".
            if (pdfSign.VerifySigned("Signature1"))
            {
                Console.WriteLine("PDF Signed");
            }
            else
            {
                Console.WriteLine("Signature not found or invalid.");
            }

            // Close the signature handler.
            pdfSign.Close();
            // ExEnd:VerifySignature
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Checks whether the PDF contains any digital signatures.
    /// </summary>
    public static void VerifyPDFSigned()
    {
        // Resolve the input directory (data/inputs) relative to the application base directory.
        string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
        string pdfPath = Path.Combine(inputDir, "DigitallySign.pdf");

        // ExStart:VerifyPDFSigned
        PdfFileSignature pdfSign = new PdfFileSignature();
        pdfSign.BindPdf(pdfPath);
        // Checks if the document contains any signatures.
        bool hasSignature = pdfSign.ContainsSignature();
        Console.WriteLine(hasSignature ? "Document contains signatures." : "No signatures found.");
        pdfSign.Close();
        // ExEnd:VerifyPDFSigned
    }
}