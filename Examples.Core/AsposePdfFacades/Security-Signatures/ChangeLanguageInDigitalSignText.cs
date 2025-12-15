using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;
using System;
using System.Globalization;
using System.IO;
using System.Drawing;

namespace Examples.Core.AsposePdfFacades.Security_Signatures;

/// <summary>
/// Demonstrates how to change the language of the digital signature text in a PDF document using Aspose.Pdf.
/// </summary>
public class ChangeLanguageInDigitalSignText
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Input and output file paths.
            string inPfxFile = Path.Combine(inputDir, "certificate.pfx");
            string inFile = Path.Combine(inputDir, "input.pdf");
            string outFile = Path.Combine(outputDir, "output.pdf");

            // Bind the PDF document and apply the digital signature.
            using (PdfFileSignature pdfSign = new PdfFileSignature())
            {
                pdfSign.BindPdf(inFile);

                // Create a rectangle for the signature location.
                // NOTE: System.Drawing is platform‑specific; ensure the target runtime supports it.
                Rectangle rect = new Rectangle(310, 45, 200, 50);

                // Create the PKCS#7 signature.
                PKCS7 pkcs = new PKCS7(inPfxFile, "12345");
                pkcs.Reason = "Pruebas Firma";
                pkcs.ContactInfo = "Contacto Pruebas";
                pkcs.Location = "Población (Provincia)";
                pkcs.Date = DateTime.Now;

                // Customize the appearance with localized labels.
                SignatureCustomAppearance signatureCustomAppearance = new SignatureCustomAppearance
                {
                    DateSignedAtLabel = "Fecha",
                    DigitalSignedLabel = "Digitalmente firmado por",
                    ReasonLabel = "Razón",
                    LocationLabel = "Localización",
                    FontFamilyName = "Arial",
                    FontSize = 10d,
                    Culture = CultureInfo.InvariantCulture,
                    DateTimeFormat = "yyyy.MM.dd HH:mm:ss"
                };
                pkcs.CustomAppearance = signatureCustomAppearance;

                // Sign the PDF file (page 1, append mode).
                pdfSign.Sign(1, true, rect, pkcs);

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