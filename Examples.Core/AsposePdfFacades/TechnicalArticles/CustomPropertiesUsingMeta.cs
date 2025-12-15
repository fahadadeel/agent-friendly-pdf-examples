using System;
using System.IO;
using System.Collections;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

public class CustomPropertiesUsingMeta
{
    /// <summary>
    /// Demonstrates retrieving and setting custom PDF properties using Aspose.Pdf.Facades.PdfFileInfo.
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
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Input PDF file path.
            string inputPath = Path.Combine(inputDir, "inFile1.pdf");

            // Create instance of PdfFileInfo object.
            PdfFileInfo fInfo = new PdfFileInfo(inputPath);

            // Retrieve all existing custom attributes.
            Hashtable hTable = new Hashtable(fInfo.Header);

            IDictionaryEnumerator enumerator = hTable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                string output = enumerator.Key.ToString() + " " + enumerator.Value;
                Console.WriteLine(output);
            }

            // Set new custom attribute as meta info.
            fInfo.SetMetaInfo("CustomAttribute", "test value");

            // Get custom attribute from meta info by specifying attribute/property name.
            string value = fInfo.GetMetaInfo("CustomAttribute");
            Console.WriteLine($"CustomAttribute = {value}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in CustomPropertiesUsingMeta.Run: {ex.Message}");
        }
    }
}