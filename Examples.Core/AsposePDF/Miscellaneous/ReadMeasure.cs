using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePDF.Miscellaneous;

/// <summary>
/// Demonstrates reading measurement information from a line annotation in a PDF document.
/// </summary>
public class ReadMeasure
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

            // Ensure the output directory exists (even though this example does not write output).
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Path to the source PDF file.
            string inputPath = Path.Combine(inputDir, "ReadMeasure.pdf");

            // Load the PDF document.
            Document doc = new Document(inputPath);

            // Retrieve the first page's first line annotation.
            LineAnnotation lineAnno = doc.Pages[1].Annotations[1] as LineAnnotation;
            if (lineAnno == null)
            {
                Console.WriteLine("The expected line annotation was not found.");
                return;
            }

            // Output measurement details.
            Console.WriteLine(lineAnno.Measure.ScaleRatio);
            // The following members are based on the legacy example; verify property names against the Aspose.Pdf API.
            Console.WriteLine(lineAnno.Measure.AreaFormat[1].UnitLabel);
            // TODO: verify property name 'ConvresionFactor' (possible typo in legacy code)
            Console.WriteLine(lineAnno.Measure.AreaFormat[1].ConvresionFactor);
            Console.WriteLine(lineAnno.Measure.AreaFormat[1].FractionSeparator);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// TODO: import or include helper class RunExamples from original source if needed.