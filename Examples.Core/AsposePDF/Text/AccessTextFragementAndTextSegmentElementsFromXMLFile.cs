using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

/// <summary>
/// Demonstrates accessing text fragments and text segment elements from an XML file using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Text;

public class AccessTextFragementAndTextSegmentElementsFromXMLFile
{
    /// <summary>
    /// Runs the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure directories exist.
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Input and output file names.
            string inXml = "40014.xml";
            string outFile = "40014_out.pdf";

            // Load XML into a new PDF document.
            Document doc = new Document();
            doc.BindXml(Path.Combine(inputDir, inXml));

            // Access objects by their IDs.
            Page page = (Page)doc.GetObjectById("mainSection");

            TextSegment segment = (TextSegment)doc.GetObjectById("boldHtml");
            segment = (TextSegment)doc.GetObjectById("strongHtml");

            // Save the resulting PDF.
            doc.Save(Path.Combine(outputDir, outFile));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing AccessTextFragementAndTextSegmentElementsFromXMLFile: {ex.Message}");
        }
    }
}