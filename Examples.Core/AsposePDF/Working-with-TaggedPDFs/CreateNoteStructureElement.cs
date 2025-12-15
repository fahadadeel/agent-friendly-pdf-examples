using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.LogicalStructure;
using Aspose.Pdf.Tagged;

namespace Examples.Core.AsposePDF.Working_with_TaggedPDFs;

/// <summary>
/// Demonstrates creating note structure elements in a tagged PDF and validating PDF/UA compliance.
/// </summary>
public class CreateNoteStructureElement
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output directories relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string outputDir = Path.Combine(baseDir, "data", "outputs");

        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDir);

        string outFile = Path.Combine(outputDir, "45929_doc.pdf");
        string logFile = Path.Combine(outputDir, "45929_log.xml");

        try
        {
            // Create a new PDF document.
            Document document = new Document();
            ITaggedContent taggedContent = document.TaggedContent;

            // Set document metadata for tagged content.
            taggedContent.SetTitle("Sample of Note Elements");
            taggedContent.SetLanguage("en-US");

            // Add a paragraph element as the root container.
            ParagraphElement paragraph = taggedContent.CreateParagraphElement();
            taggedContent.RootElement.AppendChild(paragraph);

            // Add first note element (auto-generated ID).
            NoteElement note1 = taggedContent.CreateNoteElement();
            paragraph.AppendChild(note1);
            note1.SetText("Note with auto generate ID. ");

            // Add second note element with explicit ID.
            NoteElement note2 = taggedContent.CreateNoteElement();
            paragraph.AppendChild(note2);
            note2.SetText("Note with ID = 'note_002'. ");
            note2.SetId("note_002");

            // Add third note element with explicit ID.
            NoteElement note3 = taggedContent.CreateNoteElement();
            paragraph.AppendChild(note3);
            note3.SetText("Note with ID = 'note_003'. ");
            note3.SetId("note_003");

            // The following line would throw an exception because the ID already exists.
            // note3.SetId("note_002");

            // Clearing the ID would affect PDF/UA compliance.
            // note3.ClearId();

            // Save the tagged PDF document.
            document.Save(outFile);

            // Re-open the document to validate PDF/UA compliance.
            document = new Document(outFile);
            bool isPdfUaCompliance = document.Validate(logFile, PdfFormat.PDF_UA_1);
            Console.WriteLine(string.Format("PDF/UA compliance: {0}", isPdfUaCompliance));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while creating the tagged PDF: {ex.Message}");
        }
    }
}