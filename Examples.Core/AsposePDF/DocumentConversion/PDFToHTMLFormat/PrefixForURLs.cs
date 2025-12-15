using System;
using System.IO;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion.PDFToHTMLFormat;

/// <summary>
/// Demonstrates converting a PDF to HTML with custom URL prefixes for embedded images.
/// </summary>
public class PrefixForURLs
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base.
            string inputDir = GetInputDirectory();
            string outputDir = GetOutputDirectory();

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDir);

            // Load the source PDF.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            Document testDoc = new Document(inputPath);

            // Configure HTML save options.
            HtmlSaveOptions options = new HtmlSaveOptions
            {
                // This setting enables raster images to be saved as external PNG files referenced via SVG.
                RasterImagesSavingMode = HtmlSaveOptions.RasterImagesSavingModes.AsExternalPngFilesReferencedViaSvg,

                // Assign the custom resource saving strategy.
                CustomResourceSavingStrategy = new HtmlSaveOptions.ResourceSavingStrategy(Custom_processor_of_embedded_images)
            };

            // Save the PDF as HTML.
            string outputPath = Path.Combine(outputDir, "PrefixForURLs_out.html");
            testDoc.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // ------------------------------------------------------------------------
    // Helper: custom processing of embedded images.
    // ------------------------------------------------------------------------
    private static string Custom_processor_of_embedded_images(SaveOptions.ResourceSavingInfo resourceSavingInfo)
    {
        // 1) Non‑image resources are ignored by this custom processor.
        if (!(resourceSavingInfo is HtmlSaveOptions.HtmlImageSavingInfo))
        {
            resourceSavingInfo.CustomProcessingCancelled = true;
            return string.Empty;
        }

        // 2) Determine the target folder for saved images.
        string outputBase = GetOutputDirectory();
        string outDir = Path.Combine(outputBase, "output", "36297_files");
        Directory.CreateDirectory(outDir);

        // 3) Build the full path for the image file.
        string outPath = Path.Combine(outDir, Path.GetFileName(resourceSavingInfo.SupposedFileName));

        // 4) Write the image bytes to the target file.
        using (var reader = new BinaryReader(resourceSavingInfo.ContentStream))
        {
            byte[] bytes = reader.ReadBytes((int)resourceSavingInfo.ContentStream.Length);
            File.WriteAllBytes(outPath, bytes);
        }

        // 5) Return a custom URL that references the saved image.
        var asHtmlImageSavingInfo = (HtmlSaveOptions.HtmlImageSavingInfo)resourceSavingInfo;
        if (asHtmlImageSavingInfo.ParentType == HtmlSaveOptions.ImageParentTypes.SvgImage)
        {
            return "http://localhost:255/" + resourceSavingInfo.SupposedFileName;
        }
        else
        {
            return "http://localhost/GetImage/imageID=" + resourceSavingInfo.SupposedFileName;
        }
    }

    // ------------------------------------------------------------------------
    // Path resolution helpers.
    // ------------------------------------------------------------------------
    private static string GetInputDirectory()
    {
        // Input files are expected under <app base>/data/inputs
        string dir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
        return dir;
    }

    private static string GetOutputDirectory()
    {
        // Output files are written under <app base>/data/outputs
        string dir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
        return dir;
    }

    // TODO: import or include helper class RunExamples from original source if needed.
}