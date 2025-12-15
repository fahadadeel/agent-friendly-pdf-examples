using System;
using System.Drawing.Text;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.DocumentConversion;

public class PCLToPDF
{
    /// <summary>
    /// Converts a PCL file to PDF and saves the result.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure output directory exists.
            Directory.CreateDirectory(outputDir);

            // Load option for PCL files.
            LoadOptions loadopt = new PclLoadOptions();

            // Input PCL file path.
            string inputPath = Path.Combine(inputDir, "hidetext.pcl");

            // Create Document object from the PCL file.
            Document doc = new Document(inputPath, loadopt);

            // Output PDF file path.
            string outputPath = Path.Combine(outputDir, "PCLToPDF_out.pdf");

            // Save the resultant PDF document.
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Demonstrates loading a PCL file from a stream.
    /// </summary>
    public static void PCLstream()
    {
        try
        {
            // Resolve input directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");

            // Input PCL file path.
            string inputPath = Path.Combine(inputDir, "sample.pcl");

            using FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using MemoryStream memoryStream = new MemoryStream();

            PclLoadOptions pclLoadOptions = new PclLoadOptions
            {
                ConversionEngine = PclLoadOptions.ConversionEngines.LegacyEngine
            };

            fileStream.CopyTo(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            using Document document = new Document(memoryStream, pclLoadOptions);
            Console.WriteLine(document.Pages.Count);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}