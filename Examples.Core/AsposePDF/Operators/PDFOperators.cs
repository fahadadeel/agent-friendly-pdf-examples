using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Operators;

public class PDFOperators
{
    /// <summary>
    /// Demonstrates adding an image to a PDF page using low‑level PDF operators.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base path.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Input file paths.
            string pdfPath = Path.Combine(inputDir, "PDFOperators.pdf");
            string imagePath = Path.Combine(inputDir, "PDFOperators.jpg");

            // Open document
            Document pdfDocument = new Document(pdfPath);

            // Set coordinates
            int lowerLeftX = 100;
            int lowerLeftY = 100;
            int upperRightX = 200;
            int upperRightY = 200;

            // Get the page where image needs to be added
            Page page = pdfDocument.Pages[1];

            // Load image into stream
            using FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            // Add image to Images collection of Page Resources
            page.Resources.Images.Add(imageStream);

            // Using GSave operator: this operator saves current graphics state
            page.Contents.Add(new Aspose.Pdf.Operators.GSave());

            // Create Rectangle and Matrix objects
            Aspose.Pdf.Rectangle rectangle = new Aspose.Pdf.Rectangle(lowerLeftX, lowerLeftY, upperRightX, upperRightY);
            Matrix matrix = new Matrix(new double[] { rectangle.URX - rectangle.LLX, 0, 0, rectangle.URY - rectangle.LLY, rectangle.LLX, rectangle.LLY });

            // Using ConcatenateMatrix (concatenate matrix) operator: defines how image must be placed
            page.Contents.Add(new Aspose.Pdf.Operators.ConcatenateMatrix(matrix));

            // Retrieve the image that was just added
            XImage ximage = page.Resources.Images[page.Resources.Images.Count];

            // Using Do operator: this operator draws image
            page.Contents.Add(new Aspose.Pdf.Operators.Do(ximage.Name));

            // Using GRestore operator: this operator restores graphics state
            page.Contents.Add(new Aspose.Pdf.Operators.GRestore());

            // Output file path
            string outputPath = Path.Combine(outputDir, "PDFOperators_out.pdf");

            // Save updated document
            pdfDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing PDFOperators example: {ex.Message}");
        }
    }
}