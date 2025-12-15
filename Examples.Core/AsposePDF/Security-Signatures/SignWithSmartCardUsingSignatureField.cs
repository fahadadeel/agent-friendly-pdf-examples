using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Examples.Core.AsposePDF.SecuritySignatures;

public class SignWithSmartCardUsingSignatureField
{
    /// <summary>
    /// Demonstrates signing a PDF with a smart card certificate selected from the Windows certificate store.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        // Input and working file paths.
        string sourcePdf = Path.Combine(inputDir, "blank.pdf");
        string workingPdf = Path.Combine(outputDir, "externalSignature1.pdf");

        try
        {
            // Copy the source PDF to the working location.
            File.Copy(sourcePdf, workingPdf, true);

            // Open the PDF for read/write operations.
            using (FileStream fs = new FileStream(workingPdf, FileMode.Open, FileAccess.ReadWrite))
            {
                using (Document doc = new Document(fs))
                {
                    // Create a signature field on the first page.
                    SignatureField field1 = new SignatureField(doc.Pages[1], new Rectangle(100, 400, 10, 10));

                    // Open the current user's certificate store.
                    using X509Store store = new X509Store(StoreLocation.CurrentUser);
                    store.Open(OpenFlags.ReadOnly);

                    // Let the user select a single certificate.
                    X509Certificate2Collection selected = X509Certificate2UI.SelectFromCollection(
                        store.Certificates,
                        null,
                        null,
                        X509SelectionFlag.SingleSelection);

                    if (selected == null || selected.Count == 0)
                    {
                        Console.WriteLine("No certificate selected.");
                        return;
                    }

                    // Create an external signature based on the selected certificate.
                    ExternalSignature externalSignature = new ExternalSignature(selected[0])
                    {
                        Authority = "Me",
                        Reason = "Reason",
                        ContactInfo = "Contact"
                    };

                    // Configure the signature field and sign.
                    field1.PartialName = "sig1";
                    doc.Form.Add(field1, 1);
                    field1.Sign(externalSignature);

                    // Save changes back to the same stream (workingPdf).
                    doc.Save();
                }
            }

            // Verify the signature.
            using (PdfFileSignature pdfSign = new PdfFileSignature(new Document(workingPdf)))
            {
                IList<string> sigNames = pdfSign.GetSignNames();
                for (int i = 0; i < sigNames.Count; i++)
                {
                    string name = sigNames[i];
                    if (!pdfSign.VerifySigned(name) || !pdfSign.VerifySignature(name))
                    {
                        throw new ApplicationException($"Signature '{name}' not verified.");
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