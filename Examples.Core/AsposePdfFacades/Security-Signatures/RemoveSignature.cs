using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;

namespace Examples.Core.AsposePdfFacades.Security_Signatures;

/// <summary>
/// Demonstrates how to remove digital signatures from PDF files using Aspose.Pdf.Facades.
/// </summary>
public class RemoveSignature
{
    /// <summary>
    /// Removes all signatures from a sample PDF and saves the result.
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

            // Input and output file paths.
            string inputPath = Path.Combine(inputDir, "DigitallySign.pdf");
            string outputPath = Path.Combine(outputDir, "RemoveSignature_out.pdf");

            // Create PdfFileSignature object and bind the PDF.
            PdfFileSignature pdfSign = new PdfFileSignature();
            pdfSign.BindPdf(inputPath);

            // Get list of signature names.
            IList<string> names = pdfSign.GetSignNames();

            // Remove all signatures.
            for (int i = 0; i < names.Count; i++)
            {
                pdfSign.RemoveSignature(names[i]);
            }

            // Save the updated PDF.
            pdfSign.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void Run_34561_tests()
    {
        try
        {
            // Resolve input and output directories.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // TODO: Replace with actual license file path if needed.
            new License().SetLicense(@"E:\Aspose.Pdf.lic");

            // File names (place these files in the data/inputs folder).
            string inSingleSignedFile = Path.Combine(inputDir, "PDFNEWNET_34561_SingleSigned.pdf");
            string outSingleUnsignedFile = Path.Combine(outputDir, "PDFNEWNET_34561_SingleUnSigned.pdf");
            string inOutSingleResignedFile = Path.Combine(outputDir, "PDFNEWNET_34561_SingleReSigned.pdf");

            PdfFileSignature pdfSignSingle = new PdfFileSignature();
            pdfSignSingle.BindPdf(inSingleSignedFile);
            IList<string> names = pdfSignSingle.GetSignNames();

            // PKCS7 certificate (place test1.pfx in the data/inputs folder).
            using Stream pfx = new FileStream(Path.Combine(inputDir, "test1.pfx"), FileMode.Open, FileAccess.Read);
            PKCS7 pcks = new PKCS7(pfx, "test1");

            string sigNameSingle = names.Count > 0 ? names[0] : null;
            if (!string.IsNullOrEmpty(sigNameSingle))
            {
                pdfSignSingle.RemoveSignature(sigNameSingle, false);
                pdfSignSingle.Save(outSingleUnsignedFile);

                PdfFileSignature pdfSignSingle2 = new PdfFileSignature();
                pdfSignSingle2.BindPdf(outSingleUnsignedFile);
                // TODO: Provide a valid image path for signature appearance if required.
                pdfSignSingle2.SignatureAppearance = Path.Combine(inputDir, "butterfly.jpg");
                pdfSignSingle2.Sign("Signature1", pcks);
                pdfSignSingle2.Save(inOutSingleResignedFile);
                pdfSignSingle2.BindPdf(inOutSingleResignedFile);
                Console.Write("Signature 1 check result : " + pdfSignSingle2.VerifySignature("Signature1") + " \n");
            }

            // Test file with multiple signatures.
            string outManyUnsignedFile = Path.Combine(outputDir, "PDFNEWNET_34561_ManyUnSigned.pdf");
            string inOutManyResignedFile = Path.Combine(outputDir, "PDFNEWNET_34561_ManyReSigned.pdf");

            PdfFileSignature pdfSignMany = new PdfFileSignature();
            pdfSignMany.BindPdf(inSingleSignedFile); // Assuming the same input file for demonstration.

            IList<string> sigNames = pdfSignMany.GetSignNames();
            foreach (string sigName in sigNames)
            {
                pdfSignMany.RemoveSignature(sigName, false);
            }

            pdfSignMany.Save(outManyUnsignedFile);

            PdfFileSignature pdfSignMany2 = new PdfFileSignature();
            pdfSignMany2.BindPdf(outManyUnsignedFile);
            pdfSignMany2.Sign("Signature1", pcks);
            pdfSignMany2.Save(inOutManyResignedFile);
            pdfSignMany2.BindPdf(inOutManyResignedFile);
            Console.Write("Signature 2 check result : " + pdfSignMany2.VerifySignature("Signature1") + " ");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}