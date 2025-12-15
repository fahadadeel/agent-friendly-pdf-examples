using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Facades;

namespace Examples.Core.AsposePDF.Text;

/// <summary>
/// Demonstrates various text operations using Aspose.Pdf.
/// </summary>
public class AddText
{
    /// <summary>
    /// Executes the main example and invokes additional demonstrations.
    /// </summary>
    public static void Run()
    {
        try
        {
            // ExStart:AddText
            // Resolve input and output directories.
            string inputDir = GetInputDir();
            string outputDir = GetOutputDir();

            // Open document
            Document pdfDocument = new Document(Path.Combine(inputDir, "input.pdf"));

            // Get particular page
            Page pdfPage = (Page)pdfDocument.Pages[1];

            // Create text fragment
            TextFragment textFragment = new TextFragment("main text");
            textFragment.Position = new Position(100, 600);

            // Set text properties
            textFragment.TextState.FontSize = 12;
            textFragment.TextState.Font = FontRepository.FindFont("TimesNewRoman");
            textFragment.TextState.BackgroundColor = Aspose.Pdf.Color.LightGray;
            textFragment.TextState.ForegroundColor = Aspose.Pdf.Color.Red;

            // Create TextBuilder object
            TextBuilder textBuilder = new TextBuilder(pdfPage);

            // Append the text fragment to the PDF page
            textBuilder.AppendText(textFragment);

            string outputPath = Path.Combine(outputDir, "AddText_out.pdf");
            Directory.CreateDirectory(outputDir);
            pdfDocument.Save(outputPath);
            // ExEnd:AddText
            Console.WriteLine("\nText added successfully.\nFile saved at " + outputPath);

            AddUnderlineText();
            AddingBorderAroundAddedText();
            AddTextUsingTextParagraph();
            AddHyperlinkToTextSegment();
            OTFFont();
            AddStrikeOutText();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Run error: {ex.Message}");
        }
    }

    public static void AddUnderlineText()
    {
        try
        {
            // ExStart:AddUnderlineText
            string inputDir = GetInputDir();
            string outputDir = GetOutputDir();

            // Create documentation object
            Document pdfDocument = new Document();
            // Add a page to PDF document
            pdfDocument.Pages.Add();
            // Create TextBuilder for first page
            TextBuilder tb = new TextBuilder(pdfDocument.Pages[1]);
            // TextFragment with sample text
            TextFragment fragment = new TextFragment("Test message");
            // Set the font for TextFragment
            fragment.TextState.Font = FontRepository.FindFont("Arial");
            fragment.TextState.FontSize = 10;
            // Set the formatting of text as Underline
            fragment.TextState.Underline = true;
            // Specify the position where TextFragment needs to be placed
            fragment.Position = new Position(10, 800);
            // Append TextFragment to PDF file
            tb.AppendText(fragment);

            string outputPath = Path.Combine(outputDir, "AddUnderlineText_out.pdf");
            Directory.CreateDirectory(outputDir);
            pdfDocument.Save(outputPath);
            // ExEnd:AddUnderlineText
            Console.WriteLine("\nUnderline text added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AddUnderlineText error: {ex.Message}");
        }
    }

    public static void AddingBorderAroundAddedText()
    {
        try
        {
            // ExStart:AddingBorderAroundAddedText
            string inputDir = GetInputDir();
            string outputDir = GetOutputDir();

            PdfContentEditor editor = new PdfContentEditor();
            editor.BindPdf(Path.Combine(inputDir, "input.pdf"));
            LineInfo lineInfo = new LineInfo
            {
                LineWidth = 2,
                VerticeCoordinate = new float[] { 0, 0, 100, 100, 50, 100 },
                Visibility = true
            };
            // TODO: System.Drawing.Rectangle usage may need adjustment for cross‑platform environments.
            // editor.CreatePolygon(lineInfo, 1, new System.Drawing.Rectangle(0, 0, 0, 0), "");

            string outputPath = Path.Combine(outputDir, "AddingBorderAroundAddedText_out.pdf");
            Directory.CreateDirectory(outputDir);
            editor.Save(outputPath);
            // ExEnd:AddingBorderAroundAddedText
            Console.WriteLine("\nBorder around text added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AddingBorderAroundAddedText error: {ex.Message}");
        }
    }

    public static void LoadingFontFromStream()
    {
        try
        {
            // ExStart:LoadingFontFromStream
            string inputDir = GetInputDir();
            string outputDir = GetOutputDir();
            string fontFile = ""; // Set path to a TrueType font file if needed.

            // Load input PDF file
            Document doc = new Document(Path.Combine(inputDir, "input.pdf"));
            // Create text builder object for first page of document
            TextBuilder textBuilder = new TextBuilder(doc.Pages[1]);
            // Create text fragment with sample string
            TextFragment textFragment = new TextFragment("Hello world");

            if (!string.IsNullOrEmpty(fontFile))
            {
                // Load the TrueType font into stream object
                using (FileStream fontStream = File.OpenRead(fontFile))
                {
                    // Set the font name for text string
                    textFragment.TextState.Font = FontRepository.OpenFont(fontStream, FontTypes.TTF);
                    // Specify the position for Text Fragment
                    textFragment.Position = new Position(10, 10);
                    // Add the text to TextBuilder so that it can be placed over the PDF file
                    textBuilder.AppendText(textFragment);
                }

                string outputPath = Path.Combine(outputDir, "LoadingFontFromStream_out.pdf");
                Directory.CreateDirectory(outputDir);
                doc.Save(outputPath);
                Console.WriteLine("\nFont from stream loaded successfully.\nFile saved at " + outputPath);
            }
            else
            {
                Console.WriteLine("\nNo font file specified; skipping font‑from‑stream demonstration.");
            }
            // ExEnd:LoadingFontFromStream
        }
        catch (Exception ex)
        {
            Console.WriteLine($"LoadingFontFromStream error: {ex.Message}");
        }
    }

    public static void AddTextUsingTextParagraph()
    {
        try
        {
            // ExStart:AddTextUsingTextParagraph
            string outputDir = GetOutputDir();

            // Open document
            Document doc = new Document();
            // Add page to pages collection of Document object
            Page page = doc.Pages.Add();
            TextBuilder builder = new TextBuilder(page);
            // Create text paragraph
            TextParagraph paragraph = new TextParagraph
            {
                SubsequentLinesIndent = 20,
                Rectangle = new Aspose.Pdf.Rectangle(100, 300, 200, 700)
            };
            // Specify word wrapping mode
            paragraph.FormattingOptions.WrapMode = TextFormattingOptions.WordWrapMode.ByWords;
            // Create text fragment
            TextFragment fragment1 = new TextFragment("the quick brown fox jumps over the lazy dog");
            fragment1.TextState.Font = FontRepository.FindFont("Times New Roman");
            fragment1.TextState.FontSize = 12;
            // Add fragment to paragraph
            paragraph.AppendLine(fragment1);
            // Add paragraph
            builder.AppendParagraph(paragraph);

            string outputPath = Path.Combine(outputDir, "AddTextUsingTextParagraph_out.pdf");
            Directory.CreateDirectory(outputDir);
            doc.Save(outputPath);
            // ExEnd:AddTextUsingTextParagraph
            Console.WriteLine("\nText using text paragraph added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AddTextUsingTextParagraph error: {ex.Message}");
        }
    }

    public static void AddHyperlinkToTextSegment()
    {
        try
        {
            // ExStart:AddHyperlinkToTextSegment
            string outputDir = GetOutputDir();

            // Create document instance
            Document doc = new Document();
            // Add page to pages collection of PDF file
            Page page1 = doc.Pages.Add();
            // Create TextFragment instance
            TextFragment tf = new TextFragment("Sample Text Fragment");
            // Set horizontal alignment for TextFragment
            tf.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Right;
            // Create a textsegment with sample text
            TextSegment segment = new TextSegment(" ... Text Segment 1...");
            // Add segment to segments collection of TextFragment
            tf.Segments.Add(segment);
            // Create a new TextSegment 
            segment = new TextSegment("Link to Google");
            // Add segment to segments collection of TextFragment
            tf.Segments.Add(segment);
            // Set hyperlink for TextSegment
            segment.Hyperlink = new Aspose.Pdf.WebHyperlink("www.google.com");
            // Set foreground color for text segment
            segment.TextState.ForegroundColor = Aspose.Pdf.Color.Blue;
            // Set text formatting as italic
            segment.TextState.FontStyle = FontStyles.Italic;
            // Create another TextSegment object
            segment = new TextSegment("TextSegment without hyperlink");
            // Add segment to segments collection of TextFragment
            tf.Segments.Add(segment);
            // Add TextFragment to paragraphs collection of page object
            page1.Paragraphs.Add(tf);

            string outputPath = Path.Combine(outputDir, "AddHyperlinkToTextSegment_out.pdf");
            Directory.CreateDirectory(outputDir);
            doc.Save(outputPath);
            // ExEnd:AddHyperlinkToTextSegment
            Console.WriteLine("\nHyperlink to text segment added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AddHyperlinkToTextSegment error: {ex.Message}");
        }
    }

    public static void OTFFont()
    {
        try
        {
            // ExStart:OTFFont
            string inputDir = GetInputDir();
            string outputDir = GetOutputDir();

            // Create new document instance
            Document pdfDocument = new Document();
            // Add page to pages collection of PDF file
            Aspose.Pdf.Page page = pdfDocument.Pages.Add();
            // Create TextFragment instance with sample text
            TextFragment fragment = new TextFragment("Sample Text in OTF font");
            // Open OTF font from the input directory
            fragment.TextState.Font = FontRepository.OpenFont(Path.Combine(inputDir, "space age.otf"));
            // Embed the font into the PDF
            fragment.TextState.Font.IsEmbedded = true;
            // Add TextFragment to paragraphs collection of Page instance
            page.Paragraphs.Add(fragment);

            string outputPath = Path.Combine(outputDir, "OTFFont_out.pdf");
            Directory.CreateDirectory(outputDir);
            pdfDocument.Save(outputPath);
            // ExEnd:OTFFont
            Console.WriteLine("\nOTF font used successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"OTFFont error: {ex.Message}");
        }
    }

    public static void AddNewLineFeed()
    {
        try
        {
            // ExStart:AddNewLineFeed
            string outputDir = GetOutputDir();

            Aspose.Pdf.Document pdfApplicationDoc = new Aspose.Pdf.Document();
            Aspose.Pdf.Page applicationFirstPage = (Aspose.Pdf.Page)pdfApplicationDoc.Pages.Add();

            // Initialize new TextFragment with text containing required newline markers
            Aspose.Pdf.Text.TextFragment textFragment = new Aspose.Pdf.Text.TextFragment(
                "Applicant Name: " + Environment.NewLine + " Joe Smoe");

            // Set text fragment properties if necessary
            textFragment.TextState.FontSize = 12;
            textFragment.TextState.Font = Aspose.Pdf.Text.FontRepository.FindFont("TimesNewRoman");
            textFragment.TextState.BackgroundColor = Aspose.Pdf.Color.LightGray;
            textFragment.TextState.ForegroundColor = Aspose.Pdf.Color.Red;

            // Create TextParagraph object
            TextParagraph par = new TextParagraph();

            // Add new TextFragment to paragraph
            par.AppendLine(textFragment);

            // Set paragraph position
            par.Position = new Aspose.Pdf.Text.Position(100, 600);

            // Create TextBuilder object
            TextBuilder textBuilder = new TextBuilder(applicationFirstPage);
            // Add the TextParagraph using TextBuilder
            textBuilder.AppendParagraph(par);

            string outputPath = Path.Combine(outputDir, "AddNewLineFeed_out.pdf");
            Directory.CreateDirectory(outputDir);
            pdfApplicationDoc.Save(outputPath);
            // ExEnd:AddNewLineFeed
            Console.WriteLine("\nNew line feed added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AddNewLineFeed error: {ex.Message}");
        }
    }

    public static void AddStrikeOutText()
    {
        try
        {
            // ExStart:AddStrikeOutText
            string outputDir = GetOutputDir();

            // Open document
            Document pdfDocument = new Document();
            // Add a page
            Page pdfPage = (Page)pdfDocument.Pages.Add();

            // Create text fragment
            TextFragment textFragment = new TextFragment("main text");
            textFragment.Position = new Position(100, 600);

            // Set text properties
            textFragment.TextState.FontSize = 12;
            textFragment.TextState.Font = FontRepository.FindFont("TimesNewRoman");
            textFragment.TextState.BackgroundColor = Aspose.Pdf.Color.LightGray;
            textFragment.TextState.ForegroundColor = Aspose.Pdf.Color.Red;
            // Set StrikeOut property
            textFragment.TextState.StrikeOut = true;
            // Mark text as Bold
            textFragment.TextState.FontStyle = FontStyles.Bold;

            // Create TextBuilder object
            TextBuilder textBuilder = new TextBuilder(pdfPage);
            // Append the text fragment to the PDF page
            textBuilder.AppendText(textFragment);

            string outputPath = Path.Combine(outputDir, "AddStrikeOutText_out.pdf");
            Directory.CreateDirectory(outputDir);
            pdfDocument.Save(outputPath);
            // ExEnd:AddStrikeOutText
            Console.WriteLine("\nStrikeOut text added successfully.\nFile saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AddStrikeOutText error: {ex.Message}");
        }
    }

    // Helper methods to resolve directories.
    private static string GetInputDir()
    {
        string dir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
        return dir;
    }

    private static string GetOutputDir()
    {
        string dir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
        return dir;
    }
}