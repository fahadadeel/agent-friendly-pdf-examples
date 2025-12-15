using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Drawing; // TODO: System.Drawing may be platform‑specific; verify compatibility on non‑Windows platforms.

namespace Examples.Core.AsposePDF.Security_Signatures;

/// <summary>
/// Demonstrates signing a PDF with a smart‑card certificate selected from the Windows certificate store
/// and then verifying the signature.
/// </summary>
public class SignWithSmartCardUsingPdfFileSignature
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

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Input files.
            string blankPdfPath = Path.Combine(inputDir, "blank.pdf");
            string demoImagePath = Path.Combine(inputDir, "demo.png");

            // Output file.
            string signedPdfPath = Path.Combine(outputDir, "externalSignature2.pdf");

            // Load the PDF document to be signed.
            Document doc = new Document(blankPdfPath);

            // Sign the document using a certificate selected from the Windows certificate store.
            using (PdfFileSignature pdfSign = new PdfFileSignature())
            {
                pdfSign.BindPdf(doc);

                // Open the current user's certificate store.
                using X509Store store = new X509Store(StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);

                // Let the user select a single certificate.
                X509Certificate2Collection selectedCertificates =
                    X509Certificate2UI.SelectFromCollection(
                        store.Certificates,
                        null,
                        null,
                        X509SelectionFlag.SingleSelection);

                if (selectedCertificates == null || selectedCertificates.Count == 0)
                {
                    Console.WriteLine("No certificate was selected.");
                    return;
                }

                // Create an external signature based on the selected certificate.
                ExternalSignature externalSignature = new ExternalSignature(selectedCertificates[0]);

                // Set the appearance image for the signature.
                pdfSign.SignatureAppearance = demoImagePath;

                // Apply the signature.
                pdfSign.Sign(
                    1,
                    "Reason",
                    "Contact",
                    "Location",
                    true,
                    new System.Drawing.Rectangle(100, 100, 200, 200), // AUTOFIX: specify System.Drawing.Rectangle explicitly
                    externalSignature);

                // Save the signed PDF.
                pdfSign.Save(signedPdfPath);
            }

            // Verify the signature(s) in the signed PDF.
            using (PdfFileSignature pdfSign = new PdfFileSignature(new Document(signedPdfPath)))
            {
                IList<string> sigNames = pdfSign.GetSignNames();
                for (int index = 0; index <= sigNames.Count - 1; index++)
                {
                    string name = sigNames[index];
                    bool signed = pdfSign.VerifySigned(name);
                    bool signatureValid = pdfSign.VerifySignature(name);

                    if (!signed || !signatureValid)
                    {
                        throw new ApplicationException($"Signature '{name}' could not be verified.");
                    }
                }
            }

            Console.WriteLine("PDF signed and verified successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}