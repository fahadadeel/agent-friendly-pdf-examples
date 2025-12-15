using Aspose.Pdf.Text;
using System;
using System.IO;

/// <summary>
/// Demonstrates measuring text width dynamically using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.Text;

public class GetWidthOfTextDynamically
{
    /// <summary>
    /// Executes the example.
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

            // Original helper replaced with direct path.
            string dataDir = inputDir;

            Font font = FontRepository.FindFont("Arial");
            TextState ts = new TextState
            {
                Font = font,
                FontSize = 14
            };

            if (Math.Abs(font.MeasureString("A", 14) - 9.337) > 0.001)
                Console.WriteLine("Unexpected font string measure!");

            if (Math.Abs(ts.MeasureString("z") - 7.0) > 0.001)
                Console.WriteLine("Unexpected font string measure!");

            for (char c = 'A'; c <= 'z'; c++)
            {
                double fnMeasure = font.MeasureString(c.ToString(), 14);
                double tsMeasure = ts.MeasureString(c.ToString());

                if (Math.Abs(fnMeasure - tsMeasure) > 0.001)
                    Console.WriteLine("Font and state string measuring doesn't match!");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in GetWidthOfTextDynamically.Run: {ex.Message}");
        }
    }
}