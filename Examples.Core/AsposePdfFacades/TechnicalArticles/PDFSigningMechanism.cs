using System;
using System.IO;
using System.Collections;
using Aspose.Pdf;                     // AUTOFIX
using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

public class PDFSigningMechanism
{
    /// <summary>
    /// Demonstrates signing a PDF document using Aspose.Pdf.Facades.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Input files.
            string inFilePath = Path.Combine(inputDir, "inFile.pdf");
            string certFilePath = Path.Combine(inputDir, "inFile2.pdf");
            string appearancePath = Path.Combine(inputDir, "aspose-logo.jpg");

            // Output file.
            string signedOutputPath = Path.Combine(outputDir, "Signed_out.pdf");

            // Create PdfFileSignature object and bind input PDF file.
            PdfFileSignature pdfSign = new PdfFileSignature(inFilePath);

            // Create a rectangle for signature location.
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(100, 100, 200, 100);

            // Set signature appearance.
            pdfSign.SignatureAppearance = appearancePath;

            // Create the signature (PKCS#1) using the certificate file.
            PKCS1 signature = new PKCS1(certFilePath, "password");

            // Sign the document (page 1).
            pdfSign.Sign(1, "Signature Reason", "Alice", "Odessa", true, rect, signature);

            // Save the signed document.
            pdfSign.Save(signedOutputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PDFSigningMechanism.Run: {ex.Message}");
        }
    }

    /// <summary>
    /// Adds signature fields to a PDF and signs them.
    /// </summary>
    public static void AddSignatureFields()
    {
        try
        {
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // ---------- Add signature fields ----------
            string inFilePath = Path.Combine(inputDir, "inFile.pdf");
            Document doc = new Document(inFilePath);

            FormEditor editor = new FormEditor(doc);
            editor.AddField(FieldType.Signature, "Signature from Alice", 1, 10, 10, 110, 110);
            editor.AddField(FieldType.Signature, "Signature from John", 1, 120, 150, 220, 250);
            editor.AddField(FieldType.Signature, "Signature from Smith", 1, 300, 200, 400, 300);

            string fieldsOutputPath = Path.Combine(outputDir, "AddSignatureFields_1_out.pdf");
            editor.Save(fieldsOutputPath);

            // ---------- Sign a specific field ----------
            string inFile2Path = Path.Combine(inputDir, "inFile2.pdf");
            PdfFileSignature pdfSign = new PdfFileSignature(inFile2Path);
            pdfSign.Sign("Signature from John", "Signature Reason", "John", "Kharkov",
                new PKCS1(Path.Combine(inputDir, "inFile1.pdf"), "password"));

            string signedFieldsOutputPath = Path.Combine(outputDir, "AddSignatureFields_2_out.pdf");
            pdfSign.Save(signedFieldsOutputPath);

            // ---------- Add a second signature ----------
            string filledFormPath = Path.Combine(inputDir, "FilledForm.pdf");
            Document doc3 = new Document(filledFormPath);
            PdfFileSignature pdfSign2 = new PdfFileSignature(filledFormPath);
            pdfSign2.Sign("Signature from Alice", "Signature Reason", "Alice", "Odessa",
                new PKCS1(Path.Combine(inputDir, "FilledForm - 2.pfx"), "password"));

            string secondSignedOutputPath = Path.Combine(outputDir, "AddSignatureFields_3_out.pdf");
            pdfSign2.Save(secondSignedOutputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PDFSigningMechanism.AddSignatureFields: {ex.Message}");
        }
    }

    /// <summary>
    /// Verifies signatures present in a PDF document.
    /// </summary>
    public static void VerifySignatures()
    {
        try
        {
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string inFilePath = Path.Combine(inputDir, "inFile.pdf");

            PdfFileSignature pdfVerify = new PdfFileSignature();
            pdfVerify.BindPdf(inFilePath);

            bool isSigned = pdfVerify.ContainsSignature();
            Console.WriteLine($"Document contains signature: {isSigned}");

            bool isSignatureVerified = pdfVerify.VerifySignature("Signature1");
            Console.WriteLine($"Signature 'Signature1' verified: {isSignatureVerified}");

            bool isSignatureVerified2 = pdfVerify.VerifySignature("Signature from Alice");
            Console.WriteLine($"Signature 'Signature from Alice' verified: {isSignatureVerified2}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in PDFSigningMechanism.VerifySignatures: {ex.Message}");
        }
    }
}