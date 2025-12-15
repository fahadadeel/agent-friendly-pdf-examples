using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Devices;
using System.Drawing;

namespace Examples.Core.AsposePDF.Images;

public class ImageToPDF
{
    /// <summary>
    /// Converts an image to a PDF document.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "aspose-logo.jpg");
            string outputPath = Path.Combine(outputDir, "ImageToPDF_out.pdf");

            // Instantiate Document object.
            var doc = new Document();

            // Add a page to the document.
            var page = doc.Pages.Add();

            // Load the source image file into a memory stream.
            using var fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            byte[] tmpBytes = new byte[fileStream.Length];
            fileStream.Read(tmpBytes, 0, (int)fileStream.Length);

            using var memoryStream = new MemoryStream(tmpBytes);
            using var bitmap = new Bitmap(memoryStream);

            // Set margins so the image will fit.
            page.PageInfo.Margin.Bottom = 0;
            page.PageInfo.Margin.Top = 0;
            page.PageInfo.Margin.Left = 0;
            page.PageInfo.Margin.Right = 0;

            // Adjust the page size to match the image dimensions.
            page.CropBox = new Aspose.Pdf.Rectangle(0, 0, bitmap.Width, bitmap.Height);

            // Create an image object and add it to the page.
            var image = new Aspose.Pdf.Image();
            page.Paragraphs.Add(image);

            // Reset the stream position and assign it to the image.
            memoryStream.Position = 0;
            image.ImageStream = memoryStream;

            // Save the resulting PDF file.
            doc.Save(outputPath);

            Console.WriteLine("\nImage converted to pdf successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error during ImageToPDF conversion: " + ex.Message);
        }
    }
}