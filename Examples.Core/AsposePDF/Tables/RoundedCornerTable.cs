using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Tables;

public class RoundedCornerTable
{
    /// <summary>
    /// Demonstrates how to create a table with rounded corners using Aspose.Pdf.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve the input directory (not used directly in this example but kept for consistency)
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
            }

            // Resolve the output directory (not used directly in this example but prepared for future extensions)
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new table instance
            Table tab1 = new Table();

            // Configure the border with a red color and rounded corners
            GraphInfo graph = new GraphInfo
            {
                Color = Color.Red
            };

            // Create a border that applies to all sides using the graph settings
            BorderInfo bInfo = new BorderInfo(BorderSide.All, graph)
            {
                RoundedBorderRadius = 15 // Radius of the rounded border
            };

            // Apply rounded corner style to the table
            tab1.CornerStyle = BorderCornerStyle.Round;
            tab1.Border = bInfo;

            // The table is now configured; further processing (e.g., adding rows, saving a PDF) can be done here.
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in RoundedCornerTable.Run: {ex.Message}");
        }
    }
}