using System;
using System.Drawing;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

public class TIFFtoPDFPerformanceImprovement
{
    /// <summary>
    /// Converts TIFF images from the input directory to a single PDF with performance improvements.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputDir = Path.Combine(baseDir, "data", "inputs");
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        try
        {
            // Get a list of TIFF image files.
            string[] files = Directory.GetFiles(inputDir, "*.tif");

            // Instantiate a Document object.
            Document doc = new Document();

            // Navigate through the files and add them to the PDF.
            foreach (string myFile in files)
            {
                // Load the TIFF file into a byte array.
                using var fs = new FileStream(myFile, FileMode.Open, FileAccess.Read);
                byte[] tmpBytes = new byte[fs.Length];
                fs.Read(tmpBytes, 0, Convert.ToInt32(fs.Length));

                // Create a MemoryStream from the byte array (kept alive until document is saved).
                MemoryStream mystream = new MemoryStream(tmpBytes);

                // Load the image using System.Drawing.Bitmap.
                using var bitmap = new Bitmap(mystream);

                // Create a new page in the PDF document.
                Page currpage = doc.Pages.Add();

                // Set margins so image will fit, etc.
                currpage.PageInfo.Margin.Top = 5;
                currpage.PageInfo.Margin.Bottom = 5;
                currpage.PageInfo.Margin.Left = 5;
                currpage.PageInfo.Margin.Right = 5;

                // Convert pixel dimensions to points (1 point = 1/72 inch).
                currpage.PageInfo.Width = (bitmap.Width / bitmap.HorizontalResolution) * 72;
                currpage.PageInfo.Height = (bitmap.Height / bitmap.VerticalResolution) * 72;

                // Create an image object from Aspose.Pdf.
                Aspose.Pdf.Image image1 = new Aspose.Pdf.Image();

                // Add the image into the page's paragraphs collection.
                currpage.Paragraphs.Add(image1);

                // Set IsBlackWhite property to true for performance improvement.
                image1.IsBlackWhite = true;

                // Set the ImageStream to the MemoryStream object.
                mystream.Position = 0;
                image1.ImageStream = mystream;

                // Set desired image scale.
                image1.ImageScale = 0.95F;
            }

            // Save the PDF to the output directory.
            string outputPath = Path.Combine(outputDir, "PerformanceImprovement_out.pdf");
            doc.Save(outputPath);
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during TIFF to PDF conversion: {ex.Message}");
        }
    }
}