using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.Pages.ConcatenateDocuments;

public class ConcatenateArrayOfFilesWithPath
{
    /// <summary>
    /// Concatenates two PDF files using file paths.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output paths.
            string input1 = GetInputPath("input.pdf");
            string input2 = GetInputPath("input2.pdf");
            string output = GetOutputPath("ConcatenateArrayOfFilesWithPath_out.pdf");

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(output)!);

            // Create PdfFileEditor object.
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Array of files.
            string[] filesArray = new[] { input1, input2 };

            // Concatenate files.
            pdfEditor.Concatenate(filesArray, output);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in Run: {ex.Message}");
        }
    }

    /// <summary>
    /// Concatenates two PDF files and writes the result intended for browser display.
    /// </summary>
    public static void RenderInBrowser()
    {
        try
        {
            string input1 = GetInputPath("input.pdf");
            string input2 = GetInputPath("input2.pdf");
            string output = GetOutputPath("RenderInBrowser_out.pdf");

            Directory.CreateDirectory(Path.GetDirectoryName(output)!);

            string[] filesArray = new[] { input1, input2 };
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Concatenate files.
            pdfEditor.Concatenate(filesArray, output);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in RenderInBrowser: {ex.Message}");
        }
    }

    /// <summary>
    /// Demonstrates concatenation while handling corrupted source files.
    /// </summary>
    public static void CorruptedFiles()
    {
        try
        {
            string input1 = GetInputPath("input.pdf");
            string input2 = GetInputPath("input2.pdf");
            string input3 = GetInputPath("input3.pdf");
            string output = GetOutputPath("CorruptedFiles_out.pdf");

            Directory.CreateDirectory(Path.GetDirectoryName(output)!);

            PdfFileEditor pfe = new PdfFileEditor
            {
                CorruptedFileAction = PdfFileEditor.ConcatenateCorruptedFileAction.ConcatenateIgnoringCorrupted
            };

            pfe.Concatenate(new[] { input1, input2, input3 }, output);

            if (pfe.CorruptedItems.Length > 0)
            {
                Console.WriteLine("Corrupted documents:");
                foreach (PdfFileEditor.CorruptedItem item in pfe.CorruptedItems)
                {
                    Console.WriteLine($"{item.Index} reason {item.Exception.Message}");
                }
            }
            else
            {
                Console.WriteLine("No corrupted documents");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in CorruptedFiles: {ex.Message}");
        }
    }

    private static string GetInputPath(string fileName) =>
        Path.Combine(AppContext.BaseDirectory, "data", "inputs", fileName);

    private static string GetOutputPath(string fileName) =>
        Path.Combine(AppContext.BaseDirectory, "data", "outputs", fileName);
}

// TODO: import or include helper class RunExamples from original source if needed.