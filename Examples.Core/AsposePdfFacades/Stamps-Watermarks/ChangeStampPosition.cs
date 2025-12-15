using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.StampsWatermarks;

public class ChangeStampPosition
{
    /// <summary>
    /// Demonstrates how to change the position of a stamp in a PDF document using Aspose.Pdf.Facades.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths
            string inputPath = GetInputPath("ChangeStampPosition.pdf");
            string outputPath = GetOutputPath("ChangeStampPosition_out.pdf");

            // Instantiate PdfContentEditor object
            PdfContentEditor pdfContentEditor = new PdfContentEditor();

            // Bind input PDF file
            pdfContentEditor.BindPdf(inputPath);

            int pageId = 1;
            int stampIndex = 1;
            double x = 200;
            double y = 200;

            // Change the position of the stamp to new x and y position
            pdfContentEditor.MoveStamp(pageId, stampIndex, x, y);

            // Save the PDF file
            pdfContentEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Demonstrates how to change the position of a stamp by its ID.
    /// </summary>
    public static void ChangeStampPositionByID()
    {
        try
        {
            // Resolve input and output paths
            string inputPath = GetInputPath("ChangeStampPosition.pdf");
            string outputPath = GetOutputPath("ChangeStampPositionByID_out.pdf");

            // Instantiate PdfContentEditor object
            PdfContentEditor pdfContentEditor = new PdfContentEditor();

            // Bind input PDF file
            pdfContentEditor.BindPdf(inputPath);

            int pageId = 1;
            int stampId = 1;
            double x = 200;
            double y = 200;

            // Change the position of the stamp to new x and y position
            pdfContentEditor.MoveStamp(pageId, stampId, x, y);

            // Save the PDF file
            pdfContentEditor.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static string GetInputPath(string fileName)
    {
        // Base directory of the application
        string baseDir = AppContext.BaseDirectory;
        return Path.Combine(baseDir, "data", "inputs", fileName);
    }

    private static string GetOutputPath(string fileName)
    {
        string baseDir = AppContext.BaseDirectory;
        string outputDir = Path.Combine(baseDir, "data", "outputs");
        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);
        return Path.Combine(outputDir, fileName);
    }
}