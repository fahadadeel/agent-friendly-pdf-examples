using System.IO;
using System;
using System.Drawing.Imaging;
using System.Drawing;
using Aspose.Pdf.Facades;
using System.Collections;

namespace Examples.Core.AsposePdfFacades.Security_Signatures;

/// <summary>
/// Demonstrates how to remove usage rights from a digitally signed PDF using Aspose.Pdf.Facades.
/// </summary>
public class RemoveRights
{
    /// <summary>
    /// Executes the removal of usage rights.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "data", "inputs", "DigitallySign.pdf");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "RemoveRights_out.pdf");

            using (PdfFileSignature pdfSign = new PdfFileSignature())
            {
                pdfSign.BindPdf(inputPath);
                if (pdfSign.ContainsUsageRights())
                {
                    pdfSign.RemoveUsageRights();
                }

                // Save the modified document.
                pdfSign.Document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}