using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;
using System;
using System.IO;

namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

/// <summary>
/// Demonstrates creating a tagged PDF with a logical structure tree.
/// </summary>
public class CreateStructureElementsTree
{
    /// <summary>
    /// Creates the PDF and saves it to the output directory.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve output directory relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            string outputPath = Path.Combine(outputDir, "StructureElementsTree.pdf");

            // Create a new PDF document.
            Document document = new Document();

            // Obtain the tagged content interface.
            ITaggedContent taggedContent = document.TaggedContent;

            // Set document metadata.
            taggedContent.SetTitle("Tagged Pdf Document");
            taggedContent.SetLanguage("en-US");

            // Get the root structure element.
            StructureElement rootElement = taggedContent.RootElement;

            // Build the logical structure tree.
            SectElement sect1 = taggedContent.CreateSectElement();
            rootElement.AppendChild(sect1);

            SectElement sect2 = taggedContent.CreateSectElement();
            rootElement.AppendChild(sect2);

            DivElement div11 = taggedContent.CreateDivElement();
            sect1.AppendChild(div11);

            DivElement div12 = taggedContent.CreateDivElement();
            sect1.AppendChild(div12);

            ArtElement art21 = taggedContent.CreateArtElement();
            sect2.AppendChild(art21);

            ArtElement art22 = taggedContent.CreateArtElement();
            sect2.AppendChild(art22);

            DivElement div211 = taggedContent.CreateDivElement();
            art21.AppendChild(div211);

            DivElement div212 = taggedContent.CreateDivElement();
            art21.AppendChild(div212);

            DivElement div221 = taggedContent.CreateDivElement();
            art22.AppendChild(div221);

            DivElement div222 = taggedContent.CreateDivElement();
            art22.AppendChild(div222);

            SectElement sect3 = taggedContent.CreateSectElement();
            rootElement.AppendChild(sect3);

            DivElement div31 = taggedContent.CreateDivElement();
            sect3.AppendChild(div31);

            // Save the tagged PDF document.
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error creating StructureElementsTree PDF: {ex.Message}");
        }
    }
}