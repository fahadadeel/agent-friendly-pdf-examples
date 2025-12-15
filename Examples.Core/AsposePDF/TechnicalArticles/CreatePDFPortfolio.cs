using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.TechnicalArticles;

/// <summary>
/// Demonstrates how to create a PDF portfolio (collection) and add files to it using Aspose.Pdf.
/// </summary>
public class CreatePDFPortfolio
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

            // Instantiate a new PDF document.
            Document doc = new Document();

            // Create a new collection (portfolio) for the document.
            doc.Collection = new Collection();

            // Prepare file specifications for the files to be added to the portfolio.
            FileSpecification excel = new FileSpecification(Path.Combine(inputDir, "HelloWorld.xlsx"));
            FileSpecification word = new FileSpecification(Path.Combine(inputDir, "HelloWorld.docx"));
            FileSpecification image = new FileSpecification(Path.Combine(inputDir, "aspose-logo.jpg"));

            // Provide descriptions for the files.
            excel.Description = "Excel File";
            word.Description = "Word File";
            image.Description = "Image File";

            // Add the files to the document collection.
            doc.Collection.Add(excel);
            doc.Collection.Add(word);
            doc.Collection.Add(image);

            // Save the resulting PDF portfolio.
            string outputPath = Path.Combine(outputDir, "CreatePDFPortfolio_out.pdf");
            doc.Save(outputPath);

            Console.WriteLine($"PDF portfolio created successfully at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while creating the PDF portfolio: {ex.Message}");
        }
    }
}