using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Operators;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates adding raster images and DICOM images to PDF documents using Aspose.Pdf.
/// </summary>
public class AddImage
{
    /// <summary>
    /// Adds a JPEG image to an existing PDF page and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Input PDF and image files.
            string pdfInputPath = Path.Combine(inputDir, "AddImage.pdf");
            string imageInputPath = Path.Combine(inputDir, "aspose-logo.jpg");

            // Open the existing PDF document.
            Document pdfDocument = new Document(pdfInputPath);

            // Set coordinates for the image placement.
            int lowerLeftX = 100;
            int lowerLeftY = 100;
            int upperRightX = 200;
            int upperRightY = 200;

            // Get the first page where the image will be added.
            Page page = pdfDocument.Pages[1];

            // Load the image into a stream and add it to the page resources.
            using var imageStream = new FileStream(imageInputPath, FileMode.Open, FileAccess.Read);
            page.Resources.Images.Add(imageStream);

            // Save current graphics state.
            page.Contents.Add(new GSave());

            // Define the rectangle and transformation matrix for the image.
            Rectangle rectangle = new Rectangle(lowerLeftX, lowerLeftY, upperRightX, upperRightY);
            Matrix matrix = new Matrix(new double[]
            {
                rectangle.URX - rectangle.LLX, 0,
                0, rectangle.URY - rectangle.LLY,
                rectangle.LLX, rectangle.LLY
            });

            // Apply the matrix.
            page.Contents.Add(new ConcatenateMatrix(matrix));

            // Retrieve the added image and draw it.
            XImage ximage = page.Resources.Images[page.Resources.Images.Count];
            page.Contents.Add(new Do(ximage.Name));

            // Restore graphics state.
            page.Contents.Add(new GRestore());

            // Save the updated PDF to the output directory.
            string outputPath = Path.Combine(outputDir, "AddImage_out.pdf");
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nImage added successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddImage.Run: {ex.Message}");
        }
    }

    /// <summary>
    /// Adds a DICOM image to a new PDF document and saves the result.
    /// </summary>
    public static void AddDicomImage()
    {
        try
        {
            // Resolve input and output directories.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Input DICOM file.
            string dicomInputPath = Path.Combine(inputDir, "0002.dcm");

            using Document pdfDocument = new Document();
            pdfDocument.Pages.Add();

            // Create an Aspose.Pdf.Image configured for DICOM.
            Aspose.Pdf.Image image = new Aspose.Pdf.Image
            {
                FileType = ImageFileType.Dicom,
                ImageStream = new FileStream(dicomInputPath, FileMode.Open, FileAccess.Read)
            };

            pdfDocument.Pages[1].Paragraphs.Add(image);

            // Save the PDF containing the DICOM image.
            string outputPath = Path.Combine(outputDir, "PdfWithDicomImage_out.pdf");
            pdfDocument.Save(outputPath);

            Console.WriteLine($"\nDICOM image added successfully.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddImage.AddDicomImage: {ex.Message}");
        }
    }
}