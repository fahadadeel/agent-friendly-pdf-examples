using System;
using System.IO;
using Aspose.Pdf;

/// <summary>
/// Demonstrates how to determine the color type of each page in a PDF document using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Pages;

public class DeterminePageColor
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input PDF path relative to the application base directory.
            string inputPath = Path.Combine(AppContext.BaseDirectory, "data", "inputs", "input.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open source PDF file
            Document pdfDocument = new Document(inputPath);

            // Iterate through all the pages of the PDF file
            for (int pageCount = 1; pageCount <= pdfDocument.Pages.Count; pageCount++)
            {
                // Get the color type information for particular PDF page
                ColorType pageColorType = pdfDocument.Pages[pageCount].ColorType;

                switch (pageColorType)
                {
                    case ColorType.BlackAndWhite:
                        Console.WriteLine("Page # -" + pageCount + " is Black and white..");
                        break;
                    case ColorType.Grayscale:
                        Console.WriteLine("Page # -" + pageCount + " is Gray Scale...");
                        break;
                    case ColorType.Rgb:
                        // Original code used an overload with an extra argument; kept for compatibility.
                        Console.WriteLine("Page # -" + pageCount + " is RGB..", pageCount);
                        break;
                    case ColorType.Undefined:
                        Console.WriteLine("Page # -" + pageCount + " Color is undefined..");
                        break;
                    default:
                        Console.WriteLine("Page # -" + pageCount + " has an unrecognized color type.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while determining page colors: {ex.Message}");
        }
    }
}