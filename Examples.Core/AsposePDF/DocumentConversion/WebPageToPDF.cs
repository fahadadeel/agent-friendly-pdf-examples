using System;
using System.IO;
using System.Net;
using System.Text;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.DocumentConversion;

public class WebPageToPDF
{
    /// <summary>
    /// Converts a web page to a PDF document.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");

            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // The URL of the web page to convert.
            const string url = "https://en.wikipedia.org/wiki/Main_Page";

            // Create a request for the URL.
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Optional: set timeout (milliseconds) if needed.
            // request.Timeout = 10000;

            // Get the response.
            using var response = (HttpWebResponse)request.GetResponse();

            // Get the stream containing content returned by the server.
            using var dataStream = response.GetResponseStream();

            // Read the content.
            using var reader = new StreamReader(dataStream, Encoding.UTF8);
            string responseFromServer = reader.ReadToEnd();

            // Convert the HTML string to a memory stream.
            using var htmlStream = new MemoryStream(Encoding.UTF8.GetBytes(responseFromServer));

            // Load options with a base URL (required for relative resources).
            HtmlLoadOptions options = new HtmlLoadOptions("https://en.wikipedia.org/wiki/");

            // Load HTML into a PDF document.
            Document pdfDocument = new Document(htmlStream, options);

            // Set page orientation to landscape.
            options.PageInfo.IsLandscape = true;

            // Save output as PDF format.
            string outputPath = Path.Combine(outputDir, "WebPageToPDF_out.pdf");
            pdfDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}