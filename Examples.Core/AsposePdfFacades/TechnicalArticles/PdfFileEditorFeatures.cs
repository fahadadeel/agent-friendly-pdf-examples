using System;
using System.IO;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePdfFacades.TechnicalArticles;

public class PdfFileEditorFeatures
{
    /// <summary>
    /// Demonstrates various features of the Aspose.Pdf.Facades.PdfFileEditor class.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve base directories
            string baseInput = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string baseOutput = Path.Combine(AppContext.BaseDirectory, "data", "outputs");

            // Ensure output directory exists
            Directory.CreateDirectory(baseOutput);

            // Helper local functions
            string In(string fileName) => Path.Combine(baseInput, fileName);
            string Out(string fileName) => Path.Combine(baseOutput, fileName);

            // Create instance of PdfFileEditor class
            PdfFileEditor pdfEditor = new PdfFileEditor();

            // Append pages from input file to the port file and save in output file
            int start = 1;
            int end = 3;
            pdfEditor.Append(In("inFile.pdf"), In("portFile.pdf"), start, end, Out("outFile_Append.pdf"));

            // Concatenate two files and save in the third one
            pdfEditor.Concatenate(In("inFile1.pdf"), In("inFile2.pdf"), Out("outFile_Concat.pdf"));

            // Delete specified number of pages from the file
            int[] pages = new int[] { 1, 2, 4, 10 };
            pdfEditor.Delete(In("inFile.pdf"), pages, Out("outFile_Delete.pdf"));

            // Extract any pages from the file
            start = 0;
            end = 3;
            pdfEditor.OwnerPassword = "ownerpass";
            pdfEditor.Extract(In("inFile.pdf"), start, end, Out("outFile_Extract.pdf"));

            // Insert pages from another file into the output file at a specified position
            start = 2;
            end = 5;
            pdfEditor.Insert(In("inFile.pdf"), 4, In("portFile.pdf"), start, end, Out("outFile_Insert.pdf"));

            // Make booklet
            pdfEditor.MakeBooklet(In("inFile.Pdf"), Out("outFile_Booklet.Pdf"));

            // Make N-Ups
            pdfEditor.MakeNUp(In("inFile.pdf"), Out("nupOutFile.pdf"), 3, 2);

            // Split the front part of the file
            pdfEditor.SplitFromFirst(In("inFile.pdf"), 3, Out("outFile_SplitFromFirst.pdf"));

            // Split the rear part of the file
            pdfEditor.SplitToEnd(In("inFile.pdf"), 3, Out("outFile_SplitToEnd.pdf"));

            // Split to individual pages
            int fileNum = 1;
            MemoryStream[] outBuffer = pdfEditor.SplitToPages(In("inFile.pdf"));
            foreach (MemoryStream aStream in outBuffer)
            {
                string outPath = Out($"oneByOne_{fileNum}.pdf");
                using (FileStream outStream = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                {
                    aStream.WriteTo(outStream);
                }
                fileNum++;
            }

            // Split to several multi-page pdf documents
            fileNum = 1;
            int[][] numberofpage = new int[][] { new int[] { 1, 4 } };
            MemoryStream[] outBuffer2 = pdfEditor.SplitToBulks(In("inFile.pdf"), numberofpage);
            foreach (MemoryStream aStream in outBuffer2)
            {
                string outPath = Out($"bulk_{fileNum}.pdf");
                using (FileStream outStream = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                {
                    aStream.WriteTo(outStream);
                }
                fileNum++;
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error executing PdfFileEditorFeatures: {ex.Message}");
        }
    }
}