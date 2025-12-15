using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;
using System.Collections;

namespace Examples.Core.AsposePDF.Security_Signatures;

/// <summary>
/// Demonstrates digitally signing a PDF with a timestamp using Aspose.Pdf.
/// </summary>
public class DigitallySignWithTimeStamp
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // ExStart:DigitallySignWithTimeStamp
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPdfPath = Path.Combine(inputDir, "DigitallySign.pdf");
            // Output PDF file.
            string outputPdfPath = Path.Combine(outputDir, "DigitallySignWithTimeStamp_out.pdf");

            // Path to the PKCS#7 certificate (PFX) file.
            // TODO: Provide a valid .pfx file path.
            string pfxFile = string.Empty;

            using (Document document = new Document(inputPdfPath))
            {
                using (PdfFileSignature signature = new PdfFileSignature(document))
                {
                    // Initialize PKCS#7 with the certificate and its password.
                    PKCS7 pkcs = new PKCS7(pfxFile, "pfx_password");

                    // Timestamp server settings.
                    TimestampSettings timestampSettings = new TimestampSettings(
                        "https:\\your_timestamp_settings",
                        "user:password"); // User/Password can be omitted

                    pkcs.TimestampSettings = timestampSettings;

                    // Define the signature rectangle.
                    // NOTE: System.Drawing may not be fully supported on all platforms.
                    // TODO: Replace with a cross‑platform alternative if necessary.
                    System.Drawing.Rectangle rect = new System.Drawing.Rectangle(100, 100, 200, 100);

                    // Sign the first page (page number 1).
                    signature.Sign(
                        1,
                        "Signature Reason",
                        "Contact",
                        "Location",
                        true,
                        rect,
                        pkcs);

                    // Save the signed PDF.
                    signature.Save(outputPdfPath);
                }
            }

            Console.WriteLine($"Signed PDF saved to: {outputPdfPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during digital signing: {ex.Message}");
        }
        // ExEnd:DigitallySignWithTimeStamp
    }
}