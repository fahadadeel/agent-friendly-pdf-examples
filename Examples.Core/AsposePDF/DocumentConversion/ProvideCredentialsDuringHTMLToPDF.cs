using System;
using System.IO;
using System.Net;
using System.Text;
using Aspose.Pdf;

/// <summary>
/// Demonstrates providing credentials during HTML to PDF conversion using Aspose.Pdf.
/// </summary>
namespace Examples.Core.AsposePDF.DocumentConversion;

public class ProvideCredentialsDuringHTMLToPDF
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // ExStart:ProvideCredentialsDuringHTMLToPDF
            // Resolve the data directory (original helper removed).
            string dataDir = Path.Combine(AppContext.BaseDirectory, "data"); // TODO: adjust data directory as needed

            // Resolve the output directory and ensure it exists.
            string outputDir = Path.Combine(AppContext.BaseDirectory, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Create a request for the URL.
            // NOTE: The original URL contained a space after "http://". Adjusted for validity.
            string requestUrl = "http://My.signchart.com/Report/PrintBook.asp?ProjectGuid=6FB9DBB0-"; // TODO: verify URL correctness
            WebRequest request = WebRequest.Create(requestUrl);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            using HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream containing content returned by the server.
            using Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            using StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            // Prepare a memory stream with the HTML content.
            using MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(responseFromServer));

            // Load options with base URL for external resources.
            string baseUrl = "http://My.signchart.com/"; // TODO: verify base URL correctness
            HtmlLoadOptions options = new HtmlLoadOptions(baseUrl);
            options.ExternalResourcesCredentials = CredentialCache.DefaultCredentials;

            // Load HTML content into a PDF document.
            Document pdfDocument = new Document(stream, options);
            // Save resultant file.
            string outputPath = Path.Combine(outputDir, "ProvideCredentialsDuringHTMLToPDF_out.pdf");
            pdfDocument.Save(outputPath);
            // ExEnd:ProvideCredentialsDuringHTMLToPDF
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}