using System;
using System.IO;
using System.Collections;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Annotations;

namespace Examples.Core.AsposePdfFacades.Annotations;

public class ExtractAnnotations
{
    /// <summary>
    /// Extracts specific annotations from a PDF document and writes their contents to the console.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Determine input directory relative to the application base directory.
            string inputDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            // Ensure the directory exists.
            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine($"Input directory not found: {inputDir}");
                return;
            }

            string pdfPath = Path.Combine(inputDir, "ExtractAnnotations.pdf");
            if (!File.Exists(pdfPath))
            {
                Console.WriteLine($"Input PDF not found: {pdfPath}");
                return;
            }

            // Create PdfAnnotationEditor and bind the PDF.
            var annotationEditor = new PdfAnnotationEditor();
            annotationEditor.BindPdf(pdfPath);

            // Define the annotation types to extract.
            string[] annotType = { AnnotationType.FreeText.ToString(), AnnotationType.Line.ToString() };

            // Extract annotations from pages 1 to 2.
            ArrayList annotList = (ArrayList)annotationEditor.ExtractAnnotations(1, 2, annotType);

            // Output the contents of each extracted annotation.
            for (int index = 0; index < annotList.Count; index++)
            {
                if (annotList[index] is Annotation annotation)
                {
                    Console.WriteLine(annotation.Contents);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}