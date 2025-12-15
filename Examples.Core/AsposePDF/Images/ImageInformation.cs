using System;
using System.IO;
using Aspose.Pdf;
using System.Collections;

namespace Examples.Core.AsposePDF.Images;

/// <summary>
/// Demonstrates how to retrieve image information such as dimensions and resolution from a PDF page.
/// </summary>
public class ImageInformation
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // Resolve the directory that contains input files.
            string dataDir = Path.Combine(AppContext.BaseDirectory, "data", "inputs");
            if (!Directory.Exists(dataDir))
            {
                Console.Error.WriteLine($"Input directory not found: {dataDir}");
                return;
            }

            // Load the source PDF file.
            string inputPath = Path.Combine(dataDir, "ImageInformation.pdf");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            Document doc = new Document(inputPath);

            // Define the default resolution for image.
            int defaultResolution = 72;
            Stack graphicsState = new Stack();
            // Hold image names from the first page.
            ArrayList imageNames = new ArrayList(doc.Pages[1].Resources.Images.Names);
            // Insert an identity matrix to the stack.
            graphicsState.Push(new System.Drawing.Drawing2D.Matrix(1, 0, 0, 1, 0, 0));

            // Iterate over all operators on the first page.
            foreach (Operator op in doc.Pages[1].Contents)
            {
                // Cast operators to specific types.
                Aspose.Pdf.Operators.GSave opSaveState = op as Aspose.Pdf.Operators.GSave;
                Aspose.Pdf.Operators.GRestore opRestoreState = op as Aspose.Pdf.Operators.GRestore;
                Aspose.Pdf.Operators.ConcatenateMatrix opCtm = op as Aspose.Pdf.Operators.ConcatenateMatrix;
                Aspose.Pdf.Operators.Do opDo = op as Aspose.Pdf.Operators.Do;

                if (opSaveState != null)
                {
                    // Save previous state and push current state to the top of the stack.
                    graphicsState.Push(((System.Drawing.Drawing2D.Matrix)graphicsState.Peek()).Clone());
                }
                else if (opRestoreState != null)
                {
                    // Discard current state and restore previous one.
                    graphicsState.Pop();
                }
                else if (opCtm != null)
                {
                    System.Drawing.Drawing2D.Matrix cm = new System.Drawing.Drawing2D.Matrix(
                        (float)opCtm.Matrix.A,
                        (float)opCtm.Matrix.B,
                        (float)opCtm.Matrix.C,
                        (float)opCtm.Matrix.D,
                        (float)opCtm.Matrix.E,
                        (float)opCtm.Matrix.F);

                    // Multiply current matrix with the state matrix.
                    ((System.Drawing.Drawing2D.Matrix)graphicsState.Peek()).Multiply(cm);
                    continue;
                }
                else if (opDo != null)
                {
                    // Handle image drawing operator.
                    if (imageNames.Contains(opDo.Name))
                    {
                        System.Drawing.Drawing2D.Matrix lastCTM = (System.Drawing.Drawing2D.Matrix)graphicsState.Peek();
                        // Retrieve the image from resources.
                        XImage image = doc.Pages[1].Resources.Images[opDo.Name];

                        // Compute scaled dimensions.
                        double scaledWidth = Math.Sqrt(Math.Pow(lastCTM.Elements[0], 2) + Math.Pow(lastCTM.Elements[1], 2));
                        double scaledHeight = Math.Sqrt(Math.Pow(lastCTM.Elements[2], 2) + Math.Pow(lastCTM.Elements[3], 2));

                        // Original image dimensions.
                        double originalWidth = image.Width;
                        double originalHeight = image.Height;

                        // Compute resolution.
                        double resHorizontal = originalWidth * defaultResolution / scaledWidth;
                        double resVertical = originalHeight * defaultResolution / scaledHeight;

                        // Output information.
                        Console.Out.WriteLine(
                            string.Format(
                                Path.Combine(dataDir, $"image {opDo.Name} ({scaledWidth:.##}:{scaledHeight:.##}): res {resHorizontal:.##} x {resVertical:.##}")));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

// TODO: System.Drawing usage may require the System.Drawing.Common NuGet package on non‑Windows platforms.