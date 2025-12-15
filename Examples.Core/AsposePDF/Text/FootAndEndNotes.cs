using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.Text;

public class FootAndEndNotes
{
    /// <summary>
    /// Executes all footnote and endnote examples.
    /// </summary>
    public static void Run()
    {
        AddFootNote();
        CustomLineStyleForFootNote();
        CustomizeFootNoteLabel();
        AddImageAndTable();
        CreateEndNotes();
    }

    public static void AddFootNote()
    {
        try
        {
            // Prepare directories
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "AddFootNote_out.pdf");

            // Create Document instance
            Document doc = new Document();
            // Add page to pages collection of PDF
            Page page = doc.Pages.Add();
            // Create GraphInfo object
            Aspose.Pdf.GraphInfo graph = new Aspose.Pdf.GraphInfo
            {
                LineWidth = 2,
                Color = Aspose.Pdf.Color.Red,
                DashArray = new int[] { 3 },
                DashPhase = 1
            };
            // Set footnote line style for page as graph
            page.NoteLineStyle = graph;
            // Create TextFragment instance
            TextFragment text = new TextFragment("Hello World")
            {
                FootNote = new Note("foot note for test text 1")
            };
            // Add TextFragment to paragraphs collection of first page of document
            page.Paragraphs.Add(text);
            // Create second TextFragment
            text = new TextFragment("Aspose.Pdf for .NET")
            {
                FootNote = new Note("foot note for test text 2")
            };
            // Add second text fragment to paragraphs collection of PDF file
            page.Paragraphs.Add(text);

            // Save resulting PDF document.
            doc.Save(outputPath);
            Console.WriteLine("\nFootNote added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in AddFootNote: " + ex.Message);
        }
    }

    public static void CustomLineStyleForFootNote()
    {
        try
        {
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "CustomLineStyleForFootNote_out.pdf");

            Document doc = new Document();
            Page page = doc.Pages.Add();
            Aspose.Pdf.GraphInfo graph = new Aspose.Pdf.GraphInfo
            {
                LineWidth = 2,
                Color = Aspose.Pdf.Color.Red,
                DashArray = new int[] { 3 },
                DashPhase = 1
            };
            page.NoteLineStyle = graph;

            TextFragment text = new TextFragment("Hello World")
            {
                FootNote = new Note("foot note for test text 1")
            };
            page.Paragraphs.Add(text);

            text = new TextFragment("Aspose.Pdf for .NET")
            {
                FootNote = new Note("foot note for test text 2")
            };
            page.Paragraphs.Add(text);

            doc.Save(outputPath);
            Console.WriteLine("\nCustom line style defined successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in CustomLineStyleForFootNote: " + ex.Message);
        }
    }

    public static void CustomizeFootNoteLabel()
    {
        try
        {
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "CustomizeFootNoteLabel_out.pdf");

            Document doc = new Document();
            Page page = doc.Pages.Add();
            Aspose.Pdf.GraphInfo graph = new Aspose.Pdf.GraphInfo
            {
                LineWidth = 2,
                Color = Aspose.Pdf.Color.Red,
                DashArray = new int[] { 3 },
                DashPhase = 1
            };
            page.NoteLineStyle = graph;

            TextFragment text = new TextFragment("Hello World")
            {
                FootNote = new Note("foot note for test text 1")
            };
            // Specify custom label for FootNote
            text.FootNote.Text = " Aspose(2015)";
            page.Paragraphs.Add(text);

            doc.Save(outputPath);
            Console.WriteLine("\nFootNote label customized successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in CustomizeFootNoteLabel: " + ex.Message);
        }
    }

    public static void AddImageAndTable()
    {
        try
        {
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "AddImageAndTable_out.pdf");

            Document doc = new Document();
            Page page = doc.Pages.Add();

            TextFragment text = new TextFragment("some text");
            page.Paragraphs.Add(text);

            text.FootNote = new Note();

            // Add image to footnote
            Aspose.Pdf.Image image = new Aspose.Pdf.Image
            {
                File = Path.Combine(inputDir, "aspose-logo.jpg"),
                FixHeight = 20
            };
            text.FootNote.Paragraphs.Add(image);

            // Add additional text fragment to footnote
            TextFragment footNote = new TextFragment("footnote text")
            {
                TextState = { FontSize = 20 },
                IsInLineParagraph = true
            };
            text.FootNote.Paragraphs.Add(footNote);

            // Add table to footnote
            Aspose.Pdf.Table table = new Aspose.Pdf.Table();
            table.Rows.Add().Cells.Add().Paragraphs.Add(new TextFragment("Row 1 Cell 1"));
            text.FootNote.Paragraphs.Add(table);

            doc.Save(outputPath);
            Console.WriteLine("\nTable and image added successfully to FootNote.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in AddImageAndTable: " + ex.Message);
        }
    }

    public static void CreateEndNotes()
    {
        try
        {
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "CreateEndNotes_out.pdf");

            Document doc = new Document();
            Page page = doc.Pages.Add();

            TextFragment text = new TextFragment("Hello World")
            {
                EndNote = new Note("sample End note")
            };
            // Specify custom label for EndNote
            text.EndNote.Text = " Aspose(2015)";
            page.Paragraphs.Add(text);

            doc.Save(outputPath);
            Console.WriteLine("\nEndNotes created successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in CreateEndNotes: " + ex.Message);
        }
    }
}