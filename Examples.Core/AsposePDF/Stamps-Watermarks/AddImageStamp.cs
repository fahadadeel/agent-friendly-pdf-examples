using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

/// <summary>
/// Example class demonstrating image stamp operations with Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Stamps_Watermarks;

public class AddImageStamp
{
    /// <summary>
    /// Adds an image stamp to the first page of a PDF and saves the result.
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

            // Input files.
            string pdfPath = Path.Combine(inputDir, "AddImageStamp.pdf");
            string imgPath = Path.Combine(inputDir, "aspose-logo.jpg");

            // Open document.
            Document pdfDocument = new Document(pdfPath);

            // Create image stamp.
            ImageStamp imageStamp = new ImageStamp(imgPath)
            {
                Background = true,
                XIndent = 100,
                YIndent = 100,
                Height = 300,
                Width = 300,
                Rotate = Rotation.on270,
                Opacity = 0.5
            };

            // Add stamp to the first page.
            pdfDocument.Pages[1].AddStamp(imageStamp);

            // Save output document.
            string outPath = Path.Combine(outputDir, "AddImageStamp_out.pdf");
            pdfDocument.Save(outPath);

            Console.WriteLine($"\nImage stamp added successfully.\nFile saved at {outPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddImageStamp.Run: {ex.Message}");
        }
    }

    /// <summary>
    /// Demonstrates controlling image quality for a stamp.
    /// </summary>
    public static void ControlImageQuality()
    {
        try
        {
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string pdfPath = Path.Combine(inputDir, "AddImageStamp.pdf");
            string imgPath = Path.Combine(inputDir, "aspose-logo.jpg");

            Document pdfDocument = new Document(pdfPath);
            ImageStamp imageStamp = new ImageStamp(imgPath)
            {
                Quality = 10
            };

            pdfDocument.Pages[1].AddStamp(imageStamp);

            string outPath = Path.Combine(outputDir, "ControlImageQuality_out.pdf");
            pdfDocument.Save(outPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddImageStamp.ControlImageQuality: {ex.Message}");
        }
    }

    /// <summary>
    /// Adds an image stamp as a background inside a floating box.
    /// </summary>
    public static void AddImageStampAsBackgroundInFloatingBox()
    {
        try
        {
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string imgPath = Path.Combine(inputDir, "aspose-logo.jpg");

            // Create a new PDF document.
            Document doc = new Document();

            // Add a page.
            Page page = doc.Pages.Add();

            // Create a floating box.
            FloatingBox aBox = new FloatingBox(200, 100)
            {
                Left = 40,
                Top = 80,
                HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center,
                Border = new BorderInfo(BorderSide.All, Aspose.Pdf.Color.Red),
                BackgroundImage = new Image { File = imgPath },
                BackgroundColor = Aspose.Pdf.Color.Yellow
            };

            // Add text to the floating box.
            aBox.Paragraphs.Add(new TextFragment("main text"));

            // Add the floating box to the page.
            page.Paragraphs.Add(aBox);

            // Save the document.
            string outPath = Path.Combine(outputDir, "AddImageStampAsBackgroundInFloatingBox_out.pdf");
            doc.Save(outPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddImageStamp.AddImageStampAsBackgroundInFloatingBox: {ex.Message}");
        }
    }
}