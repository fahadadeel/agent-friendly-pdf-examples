using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePDF.Security_Signatures;

/// <summary>
/// Demonstrates how to digitally sign a PDF document using Aspose.Pdf.
/// </summary>
public class DigitallySign
{
    /// <summary>
    /// Executes the digital signing example.
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

            // Input and output file paths.
            string inFile = Path.Combine(inputDir, "DigitallySign.pdf");
            string outFile = Path.Combine(outputDir, "DigitallySign_out.pdf");
            string signatureImage = Path.Combine(inputDir, "aspose-logo.jpg");

            // Path to the PKCS#7 certificate file (empty in the original example).
            string pbxFile = string.Empty;

            // First pass: create a certified signature.
            using (Document document = new Document(inFile))
            {
                using (PdfFileSignature signature = new PdfFileSignature(document))
                {
                    PKCS7 pkcs = new PKCS7(pbxFile, "WebSales"); // Use PKCS7/PKCS7Detached objects
                    DocMDPSignature docMdpSignature = new DocMDPSignature(pkcs, DocMDPAccessPermissions.FillingInForms);
                    System.Drawing.Rectangle rect = new System.Drawing.Rectangle(100, 100, 200, 100);

                    // Set signature appearance.
                    signature.SignatureAppearance = signatureImage;

                    // Create a certification signature (type 1).
                    signature.Certify(1, "Signature Reason", "Contact", "Location", true, rect, docMdpSignature);

                    // Save the signed PDF.
                    signature.Save(outFile);
                }
            }

            // Second pass: verify the created signature.
            using (Document document = new Document(outFile))
            {
                using (PdfFileSignature signature = new PdfFileSignature(document))
                {
                    IList<string> sigNames = signature.GetSignNames();
                    if (sigNames.Count > 0) // Any signatures?
                    {
                        if (signature.VerifySigned(sigNames[0])) // Verify first one
                        {
                            if (signature.IsCertified) // Certified?
                            {
                                if (signature.GetAccessPermissions() == DocMDPAccessPermissions.FillingInForms) // Get access permission
                                {
                                    // Signature verified and permissions are as expected.
                                    // TODO: add any additional processing here.
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